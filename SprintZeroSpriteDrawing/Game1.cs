using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites;
using SprintZeroSpriteDrawing.Controllers;
using SprintZeroSpriteDrawing.Commands;
using System.Collections.Generic;
using System;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using System.Numerics;
using System.Threading.Tasks.Dataflow;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Sprites.MarioPowerUpSprites;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;

namespace SprintZeroSpriteDrawing
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        #region Dictionaries
        Dictionary<Keys, ICommand> keyBoardCommand;
        Dictionary<Buttons, ICommand> gamePadCommand;
        #endregion

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
        private Dictionary<string, ISprite> spriteList = new Dictionary<string, ISprite>();
   
        SpriteMA SawyerMA;

        #region Items
        ISprite SMushroom;
        ISprite Coin;
        ISprite FireFlower;
        ISprite UPMushroom;
        ISprite Star;
        #endregion

        #region Blocks
        ISprite BBlock;
        ISprite QBlock;
        ISprite HitQBlock;
        #endregion

        #region Mario States
        ISprite DeadMario;
        ISprite SmallMario;
        ISprite BigMario;
        ISprite FireMario;

        ISprite Running;
        ISprite Crouching;
        ISprite Jumping;
        ISprite Idle;
        #endregion

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
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            #region sprites

            #region item sprites
            FireFlower = new FireFlower(null, new Vector2(2, 4), new Vector2(10, 10));
            Coin = new Coins(null, new Vector2(2, 2), new Vector2(10, 30));
            SMushroom = new SuperMushroom(null, new Vector2(1, 1), new Vector2(10, 50));
            UPMushroom = new OneUPMushroom(null, new Vector2(1, 1), new Vector2(10, 70));
            Star = new Starman(null, new Vector2(2, 2), new Vector2(10, 90));

            spriteList.Add("Coins", Coin);
            spriteList.Add("FireFlower", FireFlower);
            spriteList.Add("SuperMushroom", SMushroom);
            spriteList.Add("1UPMushroom", UPMushroom);
            spriteList.Add("Starman", Star);
            #endregion

            #region obstacle sprites

            BBlock = new BrickBlock(null, new Vector2(1, 1), new Vector2(30, 10));
            //QBlock = new QuestionBlock(null, new Vector2(2,2), new Vector2(30, 30));
            //HitQBlock = new QuestionBlock(null, new Vector2(1,1), new Vector2(30,110));
            //SBlock = new StairBlock(null, new Vecto2r(1,1), new Vector2(30,50));
            //IBlock = new InvisibleBlock(null, new Vector2(1,1), new Vector2(30,70));
            //GBlock = new GroundBlock(null, new Vector2(1,1), new Vector2(30,90));

            spriteList.Add("BrickBlock(Overworld)", BBlock);
            //spriteList.Add("QuestionBlock(Overworld)", QBlock);
            //spriteList.Add("HitQuestionBlock(Overworld)", HitQBlock);
            //spriteList.Add("StairBlock", SBlock);
            //spriteList.Add("BrickBlock(Overworld)", IBlock);
            //spriteList.Add("GroundBlock(Overworld)", GBlock);
            #endregion


            #endregion

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Loading the images, and creating the sprites too

            #region Item Pictures
            Coin.Sprite = Content.Load<Texture2D>("Items/Coins");
            FireFlower.Sprite = Content.Load<Texture2D>("Items/FireFlower");
            SMushroom.Sprite = Content.Load<Texture2D>("Items/SuperMushroom");
            UPMushroom.Sprite = Content.Load<Texture2D>("Items/1UPMushroom");
            Star.Sprite = Content.Load<Texture2D>("Items/Starman");
            #endregion

            BlockSpriteFactory.Sprite.LoadContent(Content);


            #region Controllers
            keyboardController = new KeyboardController();
            gamepadController = new GamepadController();
            #endregion


            #region Command Mapping
            keyBoardCommand.Add(Keys.Y, new ICommand(SmallMario));
            keyBoardCommand.Add(Keys.U, new ICommand(BigMario));
            keyBoardCommand.Add(Keys.I, new ICommand(FireMario));
            keyBoardCommand.Add(Keys.O, new ICommand(DeadMario));

            keyBoardCommand.Add(Keys.W, new ICommand(Jumping));
            keyBoardCommand.Add(Keys.Up, new ICommand(Jumping));

            keyBoardCommand.Add(Keys.S, new ICommand(Crouching));
            keyBoardCommand.Add(Keys.Down, new ICommand(Crouching));

            keyBoardCommand.Add(Keys.A, new ICommand(Running));
            keyBoardCommand.Add(Keys.Left, new ICommand(Running));
            keyBoardCommand.Add(Keys.D, new ICommand(Running));
            keyBoardCommand.Add(Keys.Right, new ICommand(Running));
            #endregion

            //Starting the sprite batch on our new graphics device
            //move init and loading of textures?
            sBatch = new SpriteBatch(GraphicsDevice);

            //Loading the fonts
            HUDFont = Content.Load<SpriteFont>("Fonts/Arial");

        }

        protected override void Update(GameTime gameTime)
        {
            //This could again be moved into a collection and iterated over, but I'm lazy

            //keyboardController.UpdateInput();
            //gamepadController.UpdateInput();

            //iterate over all of the sprites and run their update methods every iteration
            foreach (KeyValuePair<string, ISprite> spriteEntry in spriteList)
            {
                spriteEntry.Value.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            sBatch.Begin(); //Uses AlphaBlend by default, which allows the sprites to easily blend with backgrounds they match with
            //Iterate over the sprite entry list again and draw each sprite
            foreach (KeyValuePair <string, ISprite> spriteEntry in spriteList)
            {
                spriteEntry.Value.Draw(sBatch);
            }
            //Write text onto the screen in a nice method
            sBatch.DrawString(HUDFont, "W/A: non-moving, non-animated\n E/B: non-moving, animated\n R/X: moving, non-animated\n T/Y: moving, animated\n Q/Start: quit", new Vector2(50, 0), Color.Black);
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