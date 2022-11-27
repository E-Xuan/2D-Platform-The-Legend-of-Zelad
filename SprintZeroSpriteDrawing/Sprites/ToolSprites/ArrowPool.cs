using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ToolSprites
{
    public class ArrowPool
    {
        public Queue<Arrow> arrows = new Queue<Arrow>();
        public static int ArrowsMax = 10;
        public static Vector2 position;
        private static ArrowPool _arrowPool;
        public ArrowPool(Arrow arrow)
        {
            arrows.Enqueue(arrow);
            while (arrows.Count < ArrowsMax)
                arrows.Enqueue((Arrow)ItemSpriteFactory.getFactory().CreateArrow(position));

        }
        public static ArrowPool GetArrowPool()
        {
            if (_arrowPool == null)
            {
                _arrowPool = new ArrowPool((Arrow)ItemSpriteFactory.getFactory().CreateArrow(position));
            }
            return _arrowPool;
        }
        public void Collect()
        {
            Arrow arrow;
            if(arrows.Count > 0)
            {
                arrow = arrows.Peek();
            }
            else
            {
                arrow = (Arrow)ItemSpriteFactory.getFactory().CreateArrow(position);
            }
            arrows.Enqueue(arrow);
        }

        public Arrow Get()
        {
            Arrow arrow;
            if (arrows.Count > 0)
            {
                arrow = arrows.Dequeue();
                if (Mario.GetMario().GetDirection() > 0)
                {
                    arrow.Pos = new Vector2(Mario.GetMario().Pos.X + 100, Mario.GetMario().Pos.Y);
                }
                else
                {
                    arrow.Pos = new Vector2(Mario.GetMario().Pos.X - 100, Mario.GetMario().Pos.Y);
                }
                return arrow;
            }
            else
            {
                return null;
            }
        }
    }
}
