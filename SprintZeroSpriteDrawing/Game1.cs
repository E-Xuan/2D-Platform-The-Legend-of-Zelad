using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites;
using SprintZeroSpriteDrawing.Controllers;
using SprintZeroSpriteDrawing.Commands;
using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using System.Numerics;
using System.Threading.Tasks.Dataflow;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System.Reflection.Metadata;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState;

namespace SprintZeroSpriteDrawing
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        
        #region Controller
        private IController<Keys> keyboardController;
        private IController<Buttons> gamepadController;
        #endregion

        #region sprites
        //This is the sprite batch that all of my sprites are drawing to, it gets passed around
        private SpriteBatch sBatch;
        //Glorified Arial font for the control list
        private SpriteFont HUDFont;
        //Sprites and their names, could use UUID's if I wanted to, but I like names its unnecessary tho
        public static Dictionary<string, ISprite> SpriteList = new Dictionary<string, ISprite>();
        #endregion

        #region Items
        SuperMushroom SMushroom;
        Coins Coin;
        FireFlower FireFlower;
        OneUPMushroom UPMushroom;
        Starman Star;
        #endregion
        

        #region Mario States
        
        Mario Player;
        ISprite DeadMario;
        ISprite SmallMario;
        ISprite BigMario;
        ISprite FireMario;

        ISprite Running;
        ISprite Crouching;
        ISprite Jumping;
        ISprite Idle;

       

        #endregion

        public Game1()
        {
            //starting the graphics device for monogame
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            keyboardController = new KeyboardController();
            gamepadController = new GamepadController();
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();


            #region sprites

            #region obstacle sprites


            // SpriteList.Add("Obstacles/HitQuestionBlock(Overworld)", HitQBlock);
            #endregion
            

            #endregion

            #region Command Mapping
            keyboardController.UpdateBinding(Keys.Q, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);
            //keyBoardCommand.Add(Keys.B, new ICommand(BBlock));
            //keyBoardCommand.Add(Keys.H, new ICommand(IBlock));

            
            #endregion

            gamepadController.UpdateBinding(Buttons.Start, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);

            base.Initialize();
        }
          

        protected override void LoadContent()
        {
            //Loading the images, and creating the sprites too

            #region ItemContent
            ItemSpriteFactory.getFactory().LoadContent(Content);
            SpriteList.Add("Items/FireFlower", ItemSpriteFactory.getFactory().createFlower(new Vector2(4, 2), new Vector2(250, 200)));
            SpriteList.Add("Items/Coins", ItemSpriteFactory.getFactory().createCoin(new Vector2(2, 2), new Vector2(350, 200)));
            SpriteList.Add("Items/SuperMushroom", ItemSpriteFactory.getFactory().createSMushroom(new Vector2(1, 1), new Vector2(450, 200)));
            SpriteList.Add("Items/1UPMushroom", ItemSpriteFactory.getFactory().createUPMushroom(new Vector2(1, 1), new Vector2(550, 200)));
            SpriteList.Add("Items/Starman", ItemSpriteFactory.getFactory().createStar(new Vector2(2, 2), new Vector2(650, 200)));
            #endregion

            #region BlockContent
            BlockSpriteFactory.getFactory().LoadContent(Content);
            SpriteList.Add("Obstacles/StairBlock", BlockSpriteFactory.getFactory().CreateStairBlock(new Vector2(700, 500)));
            SpriteList.Add("Obstacles/GroundBlock(Overworld)", BlockSpriteFactory.getFactory().CreateGroundBlock(new Vector2(800, 500)));
            SpriteList.Add("BBlock", BlockSpriteFactory.getFactory().CreateBrickBlock(new Vector2(300, 500)));
            SpriteList.Add("QBlock", BlockSpriteFactory.getFactory().CreateQuestionBlock(new Vector2(400, 500)));
            SpriteList.Add("IBlock", BlockSpriteFactory.getFactory().CreateHiddenBlock(new Vector2(600, 500)));
            SpriteList.Add("Obstacles/UsedBlock", BlockSpriteFactory.getFactory().CreateUsedBlock(new Vector2(500, 500)));
            #endregion

            #region EnemyContent
            EnemySpriteFactory.getFactory().LoadContent(Content);
            SpriteList.Add("Goomba", EnemySpriteFactory.getFactory().createGoomba(new Vector2(100, 100)));
            SpriteList.Add("GreenKoopa", EnemySpriteFactory.getFactory().createGreenKoopa(new Vector2(200, 100)));
            SpriteList.Add("RedKoopa", EnemySpriteFactory.getFactory().createRedKoopa(new Vector2(300, 100)));
            #endregion

            #region MarioContent
            MarioSpriteFactory.getSpriteFactory().LoadContent(Content);
            
            SpriteList.Add("Mario", MarioSpriteFactory.getSpriteFactory().createMario(new Vector2(300, 300)));
            #endregion
            // set game binding
            BindingCmd.SetGameBinding(SpriteList, keyboardController, gamepadController);

            //Starting the sprite batch on our new graphics device
            //move init and loading of textures?
            sBatch = new SpriteBatch(GraphicsDevice);

            //Loading the fonts
            HUDFont = Content.Load<SpriteFont>("Fonts/Arial");
            
        }

        protected override void Update(GameTime gameTime)
        {
            //This could again be moved into a collection and iterated over, but I'm lazy

            keyboardController.UpdateInput();
            gamepadController.UpdateInput();

            //iterate over all of the sprites and run their update methods every iteration
            foreach (KeyValuePair<string, ISprite> spriteEntry in SpriteList.ToImmutableSortedDictionary())
            {
                spriteEntry.Value.Update();
            }

            ((Mario)SpriteList["Mario"]).Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
 
            sBatch.Begin(); //Uses AlphaBlend by default, which allows the sprites to easily blend with backgrounds they match with
            //Iterate over the sprite entry list again and draw each sprite
            foreach (KeyValuePair <string, ISprite> spriteEntry in SpriteList)
            {
                spriteEntry.Value.Draw(sBatch);
            }
            //Write text onto the screen in a nice method
            //sBatch.DrawString(HUDFont, "W/A: non-moving, non-animated\n E/B: non-moving, animated\n R/X: moving, non-animated\n T/Y: moving, animated\n Q/Start: quit", new Vector2(50, 0), Color.Black);
            sBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        private void ExitWithCode(int errCode) {
            Console.WriteLine(errCode);
            Exit();
        }
    }
}