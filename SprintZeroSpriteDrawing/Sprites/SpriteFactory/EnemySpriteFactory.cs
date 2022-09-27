﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class EnemySpriteFactory
    {
        public Vector2 nPos { get; set; }
        public Vector2 SheetSize;

        public Texture2D Goomba;
        public Texture2D GreenKoopa;
        public Texture2D RedKoopa;

        private static EnemySpriteFactory sprite;
        public static EnemySpriteFactory getFactory()
        {
             if (sprite == null)
             {
                sprite = new EnemySpriteFactory();
             }
            return sprite;
        }

        public void LoadContent(ContentManager content)
        {
            Goomba = content.Load<Texture2D>("Enemy/Goomba");
            GreenKoopa = content.Load<Texture2D>("Enemy/KoopaTroopa");
            RedKoopa = content.Load<Texture2D>("Enemy/KoopaTroopa");
        }

        public ISprite createGoomba(Vector2 nPos)
        {
            return new Goomba(Goomba, new Vector2(2, 1), nPos);
        }
        public ISprite createGreenKoopa(Vector2 nPos)
        {
            return new GreenKoopa(GreenKoopa, new Vector2(2, 2), nPos);
        }
        public ISprite createRedKoopa(Vector2 nPos)
        {
            return new RedKoopa(GreenKoopa, new Vector2(2, 2), nPos);
        }
    }
}

