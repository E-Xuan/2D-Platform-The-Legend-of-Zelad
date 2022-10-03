﻿using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.States.BlockState
{
    public class StarState
    {
        public ISprite sprite;
        public bool triggered;
        public Vector2 nPos;
        public Vector2 SheetSize;
        public bool Used { get { return triggered; } }

        public StarState()
        {
            this.sprite = ItemSpriteFactory.getFactory().createStar(SheetSize, nPos);
            triggered = false;
        }

        public void Collide()
        {
            if (triggered == false)
            {
                /*Need to a small bump up*/
                triggered = true;
            }
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch);
        }
    }
}
