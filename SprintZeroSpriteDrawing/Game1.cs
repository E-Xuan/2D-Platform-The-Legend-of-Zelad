using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites;
using SprintZeroSpriteDrawing.Controllers;
using SprintZeroSpriteDrawing.Commands;
using System.Collections.Generic;
using System;

namespace SprintZeroSpriteDrawing
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private IController<Keys> keyboardController;
        private IController<Buttons> gamepadController;

        #region sprites
        //This is the sprite batch that all of my sprites are drawing to, it gets passed around
        private SpriteBatch sBatch;
        //Glorified Arial font for the control list
        private SpriteFont HUDFont;
        //Sprites and their names, could use UUID's if I wanted to, but I like names its unnecessary tho
        private Dictionary<string, ISprite> spriteList = new Dictionary<string, ISprite>();
   
        SpriteMA SawyerMA;
        ISprite SMushroom;
        ISprite Coin;
        ISprite FireFlower;
        ISprite UPMushroom;
        ISprite Star;
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
            _graphics.PreferredBackBufferWidth = 2880;
            _graphics.PreferredBackBufferHeight = 1620;
            _graphics.ApplyChanges();

            #region sprites
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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Loading the images, and creating the sprites too
            Coin.Sprite = Content.Load<Texture2D>("Items/Coins");
            FireFlower.Sprite = Content.Load<Texture2D>("Items/FireFlower");
            SMushroom.Sprite = Content.Load<Texture2D>("Items/SuperMushroom");
            UPMushroom.Sprite = Content.Load<Texture2D>("Items/1UPMushroom");
            Star.Sprite = Content.Load<Texture2D>("Items/Starman");


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