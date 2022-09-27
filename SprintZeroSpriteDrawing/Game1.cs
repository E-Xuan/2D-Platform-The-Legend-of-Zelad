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
using SprintZeroSpriteDrawing.States.BlockState;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;

namespace SprintZeroSpriteDrawing
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        #region Dictionaries
        private Dictionary<Keys, ICommand> keyBoardCommand = new Dictionary<Keys, ICommand>();
        private Dictionary<Buttons, ICommand> gamePadCommand = new Dictionary<Buttons, ICommand>();
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
        UsedBlock UBlock;
        #endregion

        #region Mario States
        ICommand mCommand;
        (int powerup, int action) State;
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
            mCommand = new MarioCommand(Player);

            #region sprites

            #region obstacle sprites
         
           // HitQBlock = new QuestionBlock(null, new Vector2(1,1), new Vector2(30,110));
            SBlock = new StairBlock(null, new Vector2(1,1), new Vector2(30,50));
            GBlock = new GroundBlock(null, new Vector2(1,1), new Vector2(30,90));

            
           // spriteList.Add("Obstacles/HitQuestionBlock(Overworld)", HitQBlock);
            spriteList.Add("Obstacles/StairBlock", SBlock);
            spriteList.Add("Obstacles/GroundBlock(Overworld)", GBlock);
            #endregion

            //MarioSpriteFactory.getSpriteFactory().State
            Player = new Mario(MarioSpriteFactory.getSpriteFactory().swapSprite(), MarioSpriteFactory.getSpriteFactory().swapSheetSize(), new Vector2(300, 300));

            #endregion

            #region Command Mapping
            keyboardController.UpdateBinding(Keys.Q, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);
            //keyboardController.UpdateBinding(Keys.I, new CmdTogVis(QBlock), BindingType.PRESSED); 
            keyBoardCommand.Add(Keys.B, new ICommand(BBlock));
            keyBoardCommand.Add(Keys.H, new ICommand(IBlock));


          /* 
            keyboardController.UpdateBinding(Keys.Y, MarioCommand.SetPowerup(1),BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.U, mCommand.SetPowerup(2), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.I, MarioCommand.SetPowerup(3), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.O, MarioCommand.SetPowerup(4), BindingType.PRESSED);

            keyBoardCommand.Add(Keys.W, MarioCommand.SetAction(1), BindingType.PRESSED);
            keyBoardCommand.Add(Keys.Up, MarioCommand.SetAction(1), BindingType.PRESSED);

            keyBoardCommand.Add(Keys.S, MarioCommand.SetAction(1), BindingType.PRESSED);
            keyBoardCommand.Add(Keys.Down, MarioCommand.SetAction(1), BindingType.PRESSED);

            keyBoardCommand.Add(Keys.A, MarioCommand.SetAction(1), BindingType.PRESSED);
            keyBoardCommand.Add(Keys.Left, MarioCommand.SetAction(1), BindingType.PRESSED);

            keyBoardCommand.Add(Keys.D, MarioCommand.SetAction(1), BindingType.PRESSED);
            keyBoardCommand.Add(Keys.Right, MarioCommand.SetAction(1), BindingType.PRESSED);
          */

            gamepadController.UpdateBinding(Buttons.Start, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);

            #endregion

            base.Initialize();
        }
          

        protected override void LoadContent()
        {
            //Loading the images, and creating the sprites too
            //ItemSpriteFactory.Sprite.LoadContent(Content);

            ItemSpriteFactory.getFactory().LoadContent(Content);
            FireFlower = (FireFlower)ItemSpriteFactory.getFactory().createFlower(new Vector2(4, 2), new Vector2(300, 100));
            spriteList.Add("Items/FireFlower", FireFlower);

            Coin = (Coins)ItemSpriteFactory.getFactory().createCoin(new Vector2(2, 2), new Vector2(350, 100));
            spriteList.Add("Items/Coins", Coin);

            SMushroom = (SuperMushroom)ItemSpriteFactory.getFactory().createSMushroom(new Vector2(1, 1), new Vector2(400, 100));
            spriteList.Add("Items/SuperMushroom", SMushroom);

            UPMushroom = (OneUPMushroom)ItemSpriteFactory.getFactory().createUPMushroom(new Vector2(1, 1), new Vector2(450, 100));
            spriteList.Add("Items/1UPMushroom", UPMushroom);

            Star = (Starman)ItemSpriteFactory.getFactory().createStar(new Vector2(2, 2), new Vector2(500, 100));
            spriteList.Add("Items/Starman", Star);

            #region BlockContent
            BlockSpriteFactory.getFactory().LoadContent(Content);
            BBlock = (BrickBlock)BlockSpriteFactory.getFactory().CreateBrickBlock(new Vector2(300, 500));
            spriteList.Add("Obstacles/BrickBlock(Overworld)", BBlock);
            QBlock = (QuestionBlock)BlockSpriteFactory.getFactory().CreateQuestionBlock(new Vector2(400, 500));
            spriteList.Add("Obstacles/QuestionBlock(Overworld)", QBlock);
            IBlock = (InvisibleBlock)BlockSpriteFactory.getFactory().CreateHiddenBlock(new Vector2(600, 500));
            spriteList.Add("Obstacles/InvisibleBlock", IBlock);
            UBlock = (UsedBlock)BlockSpriteFactory.getFactory().CreateUsedBlock(new Vector2(500, 500));
            spriteList.Add("Obstacles/UsedBlock", UBlock);
            #endregion


            keyboardController.UpdateBinding(Keys.I, new QBlockCmd(QBlock), BindingType.PRESSED); /*NOT WORK*/
           
            MarioSpriteFactory.getSpriteFactory().LoadContent(Content);
            Player = (Mario)MarioSpriteFactory.getSpriteFactory().createMario(new Vector2(300, 300));
            spriteList.Add("SmallMario/SmallIdle", Player);

            keyboardController.UpdateBinding(Keys.A, new IntCmd(new KeyValuePair<Action<int>, int>(Player.MoveX, -10)), BindingType.HELD);
            keyboardController.UpdateBinding(Keys.D, new IntCmd(new KeyValuePair<Action<int>, int>(Player.MoveX, 10)), BindingType.HELD);


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