using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using System.Collections.Generic;
using System;

namespace SprintZeroSpriteDrawing.Sprites.ItemSprites
{
    public class Starman : Item
    {
        private bool emerge = false;
        public Starman(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(BounceWalled, 0)), Direction.SIDE, CType.NEUTRAL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Floored, 0)), Direction.BOTTOM, CType.NEUTRAL));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(BounceWalled, 0)), Direction.TOP, CType.NEUTRAL));
        }
        public override void Update()
        {
            base.Update();

            if (State.CurrState == Interfaces.ItemState.State.EMERGING && !emerge)
            {
                Velocity = new Vector2(3, 0);
                Acceleration = new Vector2(0, (float).065);
                CollisionManager.getCM().RegMoving(this);
                emerge = true;
            }
        }
    }
}
