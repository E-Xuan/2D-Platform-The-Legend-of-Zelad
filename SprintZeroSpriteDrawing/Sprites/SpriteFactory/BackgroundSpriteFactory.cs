using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.BlockState;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class BackgroundSpriteFactory
    {
        public Vector2 nPos { get; set; }
        public Vector2 SheetSize;

        public Texture2D BackgroundSpriteSheet;

        private static BackgroundSpriteFactory sprite;

        public static BackgroundSpriteFactory getFactory()
        {
            if (sprite == null)
            {
                sprite = new BackgroundSpriteFactory();
            }
            return sprite;
        }

        public void LoadContent(ContentManager content)
        {
            BackgroundSpriteSheet = content.Load<Texture2D>("Background/bg_Cloud_Mt");
        }
        public ISprite CreateBackground(Vector2 nPos)
        {
            var background = new GroundBlock(BackgroundSpriteSheet, new Vector2(1, 1), nPos);
            return background;
        }
    }
}
