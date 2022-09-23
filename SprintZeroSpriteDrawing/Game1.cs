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
        SpriteSNA Orwell;
        SpriteMNA SawyerMNA;
        SpriteSA SawyerSA;
        SpriteMA SawyerMA;
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
            Orwell = new SpriteSNA(null, new Vector2(500, 500));
            SawyerMNA = new Sawyer(null, new Vector2(1000, 500));
            SawyerSA = new SpriteSA(null, new Vector2(2, 2), new Vector2(500, 1000));
            SawyerMA = new SawyerB(null, new Vector2(2, 2), new Vector2(1000, 1000));

            #endregion

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Loading the images, and creating the sprites too
            //test
            Orwell.Sprite = Content.Load<Texture2D>("orwell");
            SawyerMNA.Sprite = Content.Load<Texture2D>("sawyer");
            SawyerSA.SetSprite(Content.Load<Texture2D>("sawyerA"));
            SawyerMA.SetSprite(Content.Load<Texture2D>("sawyerA"));


            //Loading Obstacle Sprites


            //Starting the sprite batch on our new graphics device
            //move init and loading of textures?

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