﻿using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Collision.CollisionManager;

namespace SprintZeroSpriteDrawing.Sprites.ItemSprites
{
    public class SuperMushroom : Item
    {
        public SuperMushroom(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            CollideableType = CType.LEVELUP;
            
        }
        public override void Update()
        {
            base.Update();
            
            if (State.CurrState == Interfaces.ItemState.State.EMERGING)
            {
                Velocity = new Vector2(1, 0);
                Acceleration = new Vector2(0, (float).065);
                CollisionManager.getCM().RegMoving(this);
            }
        }
    }
}
