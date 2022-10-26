using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;

namespace SprintZeroSpriteDrawing.Interfaces.ItemState
{
    public class Emerging : IItemState
    {
        public Emerging(Item nItem) : base(nItem)
        {
            CurrState = State.EMERGING;
        }
        public override void Enter()
        {
            item.Velocity = new Vector2(0, (float)-2.1);
            item.Acceleration = new Vector2(0, (float)0.065);
            CollisionManager.getCM().RegMoving(item);
        }
        public override void Exit()
        {
        }
        public override void Update()
        {
            base.Update();
            if(item.Velocity.Y >= 2.1)
                ChangeState((int)State.IDLE);
        }
    }
}
