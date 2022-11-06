using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.LevelLoader;
using SprintZeroSpriteDrawing.Controllers;
using SprintZeroSpriteDrawing.Commands;
using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState;
using SprintZeroSpriteDrawing.GameMode;
using SprintZeroSpriteDrawing.Collision;
using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;
using SprintZeroSpriteDrawing.Sprites.SpriteFactory;
using SprintZeroSpriteDrawing.States.MarioState;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace SprintZeroSpriteDrawing
{
    
    public class Game1 : Game
    {
        public static GraphicsDeviceManager Graphics { get; set; }
        #region Controller
        private IController<Keys> keyboardController;
        private IController<Buttons> gamepadController;
        private IController<Keys> quitpauseController;
        #endregion

        #region sprites
        //This is the sprite batch that all of my sprites are drawing to, it gets passed around
        private SpriteBatch sBatch;
        //Glorified Arial font for the control list
        private SpriteFont HUDFont;
        //Sprites and their names, could use UUID's if I wanted to, but I like names its unnecessary tho
        public static List<ISprite> SpriteList = new List<ISprite>();
        #endregion
        public static Vector2 LEVELSIZE = new Vector2(1920,1080);
        public static Camera _Camera2D;
        public static int counter = 0;
        public static bool isTimeCounting = true;
        public static bool DEBUGBBOX = false;
        public static bool PAUSE = false;
        public Game1()
        {
            //starting the graphics device for monogame
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            keyboardController = new KeyboardController();
            gamepadController = new GamepadController();
            quitpauseController = new QuitPauseController();
            Graphics.PreferredBackBufferWidth = (int)LEVELSIZE.X;
            Graphics.PreferredBackBufferHeight = (int)LEVELSIZE.Y;
            Graphics.ApplyChanges();

            _Camera2D = new Camera(GraphicsDevice.Viewport);
            #region Command Mapping

            quitpauseController.UpdateBinding(Keys.Q, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.R, new LevelReset(this), BindingType.PRESSED);
            gamepadController.UpdateBinding(Buttons.Start, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);

            #endregion

            base.Initialize();
        }
          

        protected override void LoadContent()
        {
            //Loading the images, and creating the sprites too
            BackgroundSpriteFactory.getFactory().LoadContent(Content);
            ItemSpriteFactory.getFactory().LoadContent(Content);
            BlockSpriteFactory.getFactory().LoadContent(Content);
            EnemySpriteFactory.getFactory().LoadContent(Content);
            MarioSpriteFactory.getSpriteFactory().LoadContent(Content);
            ProjectileSpriteFactory.getSpriteFactory().LoadContent(Content);
            Mario.LoadContent(Content);
            // set game binding
            BindingCmd.SetGameBinding(keyboardController, gamepadController, quitpauseController);
            //Starting the sprite batch on our new graphics device
            //move init and loading of textures?
            sBatch = new SpriteBatch(GraphicsDevice);
            //Loading the fonts
            HUDFont = Content.Load<SpriteFont>("Fonts/Arial");
            //MusicPlayer.GetMusicPlayer().LoadSongs(Content);
            Restart();
        }

        public void Restart()
        {
            SpriteList = new List<ISprite>();
            Mario.GetMario().StatePowerup = new SmallMario(Mario.GetMario());
            LevelLoader.LevelLoader.GetLevelLoader().LoadLevel("Level/test.txt");
            CollisionManager.getCM().Init();
            CollisionManager.getCM().RegMoving(Mario.GetMario());
            Mario.GetMario().resetTimer();
            counter = 0;
        }

        protected override void Update(GameTime gameTime)
        {
            //This could again be moved into a collection and iterated over, but I'm lazy
            quitpauseController.UpdateInput();
            if (!PAUSE)
            {
                timeCount(gameTime, Mario.GetMario());
                Mode.GetMode().Update();
                //iterate over all of the sprites and run their update methods every iteration
                foreach (ISprite spriteEntry in SpriteList.ToImmutableList())
                {
                    spriteEntry.Update();
                }
                CollisionManager.getCM().Update();
                base.Update(gameTime);
                keyboardController.UpdateInput();
                gamepadController.UpdateInput();
                //MusicPlayer.GetMusicPlayer().Play();
            }
            _Camera2D.LookAt(Mario.GetMario().Pos);
            _Camera2D.Limits = new Rectangle(0, 0, 10100, 1080);
            //BackgroundSpriteFactory.getFactory().BackgroundSpriteSheet
            //Danish Tilt
            //_Camera2D.Rotation = (float)(Math.PI / 16);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            sBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            sBatch.Draw(BackgroundSpriteFactory.getFactory().BackgroundSpriteSheet, new Vector2(0, 478), new Rectangle((int)(_Camera2D.Position.X * 0.5f), (int)(_Camera2D.Position.Y*0.5f), BackgroundSpriteFactory.getFactory().BackgroundSpriteSheet.Width,
               BackgroundSpriteFactory.getFactory().BackgroundSpriteSheet.Height), Color.White);
            sBatch.End();

            sBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _Camera2D.GetViewMatrix(new Vector2(1f)));
            foreach (ISprite spriteEntry in SpriteList)
            {
                spriteEntry.Draw(sBatch);
            }
            //Write text onto the screen in a nice method
            sBatch.End();

            //Uses AlphaBlend by default, which allows the sprites to easily blend with backgrounds they match with
            //Iterate over the sprite entry list again and draw each sprite

            base.Draw(gameTime);
            
        }
        private void ExitWithCode(int errCode) {
            Console.WriteLine(errCode);
            Exit();
        }
        public static void DebugBBox(int errCode)
        {
            DEBUGBBOX = !DEBUGBBOX;
        }
        public static void PauseGame(int errCode)
        {
            PAUSE = !PAUSE;
        }
        public void timeCount(GameTime gameTime, Mario mario)
        {
            if (isTimeCounting)
            {
                counter += gameTime.ElapsedGameTime.Milliseconds;
                if (counter >= 1000)
                {
                    mario.Time--;
                    counter = 0;
                }
            }
            if (mario.Time == 0)
            {
                isTimeCounting = false;
                Mario.GetMario().ChangePowerup(4); // Mario dies
            }
        }
    }
}