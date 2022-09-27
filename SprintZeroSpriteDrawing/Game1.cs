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
using System.Reflection.Metadata;

using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;

namespace SprintZeroSpriteDrawing
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        #region Dictionaries
        Dictionary<Keys, ICommand> keyBoardCommand = new Dictionary<Keys, ICommand>();
        Dictionary<Buttons, ICommand> gamePadCommand = new Dictionary<Buttons, ICommand>();
        private Dictionary<Keys, ICommand> kCommandList = new Dictionary<Keys, ICommand>();
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
   
        #region Items
        SuperMushroom SMushroom;
        Coins Coin;
        FireFlower FireFlower;
        OneUPMushroom UPMushroom;
        Starman Star;
        #endregion

        #region Blocks
        BrickBlock BBlock;
        QuestionBlock QBlock;
        QuestionBlock HitQBlock;
        InvisibleBlock IBlock;
        StairBlock SBlock;
        GroundBlock GBlock;
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
            keyboardController = new KeyboardController();
            gamepadController = new GamepadController();
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 320;
            _graphics.ApplyChanges();

            #region sprites

            #region item sprites
            FireFlower = new FireFlower(null, new Vector2(2, 4), new Vector2(10, 10));
            Coin = new Coins(null, new Vector2(2, 2), new Vector2(10, 30));
            SMushroom = new SuperMushroom(null, new Vector2(1, 1), new Vector2(10, 50));
            UPMushroom = new OneUPMushroom(null, new Vector2(1, 1), new Vector2(10, 70));
            Star = new Starman(null, new Vector2(2, 2), new Vector2(10, 90));
            spriteList.Add("Items/Coins", Coin);
            spriteList.Add("Items/FireFlower", FireFlower);
            spriteList.Add("Items/SuperMushroom", SMushroom);
            spriteList.Add("Items/1UPMushroom", UPMushroom);
            spriteList.Add("Items/Starman", Star);
            #endregion

            #region obstacle sprites

            QBlock = new QuestionBlock(null, new Vector2(2,2), new Vector2(30, 30));
            HitQBlock = new QuestionBlock(null, new Vector2(1,1), new Vector2(30,110));
            SBlock = new StairBlock(null, new Vector2(1,1), new Vector2(30,50));
            IBlock = new InvisibleBlock(null, new Vector2(1,1), new Vector2(30,70)); 
            GBlock = new GroundBlock(null, new Vector2(1,1), new Vector2(30,90));

            spriteList.Add("Obstacles/QuestionBlock(Overworld)", QBlock);
            spriteList.Add("Obstacles/HitQuestionBlock(Overworld)", HitQBlock);
            spriteList.Add("Obstacles/StairBlock", SBlock);
            spriteList.Add("Obstacles/IBlock(Overworld)", IBlock);
            spriteList.Add("Obstacles/GroundBlock(Overworld)", GBlock);
            #endregion

            #endregion

            #region Command Mapping
            keyboardController.UpdateBinding(Keys.Q, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);
            keyBoardCommand.Add(Keys.B, new ICommand(BBlock));
            keyBoardCommand.Add(Keys.H, new ICommand(IBlock));

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

            gamepadController.UpdateBinding(Buttons.Start, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);

            #endregion

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Loading the images, and creating the sprites too
            ItemSpriteFactory.Sprite.LoadContent(Content);

            BlockSpriteFactory.getFactory().LoadContent(Content);
            BBlock = (BrickBlock)BlockSpriteFactory.getFactory().CreateBrickBlock(new Vector2(500, 500));
            spriteList.Add("Obstacles/BrickBlock(Overworld)", BBlock);



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