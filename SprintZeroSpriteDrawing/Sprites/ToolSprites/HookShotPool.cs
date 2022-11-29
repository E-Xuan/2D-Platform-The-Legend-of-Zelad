using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.ItemSprites.EquippableItem;
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
    public class HookShotPool
    {
        public Queue<Hook_Shot> hookShots = new Queue<Hook_Shot>();
        public static int HookShotMax = 1;
        public static Vector2 position;
        private static HookShotPool _hookShotPool;
        public HookShotPool(Hook_Shot hookShot)
        {
            hookShots.Enqueue(hookShot);
            while (hookShots.Count < HookShotMax)
                hookShots.Enqueue((Hook_Shot)ItemSpriteFactory.getFactory().CreateHookShot(position));

        }
        public static HookShotPool GetHookShotPool()
        {
            if (_hookShotPool == null)
            {
                _hookShotPool = new HookShotPool((Hook_Shot)ItemSpriteFactory.getFactory().CreateHookShot(position));
            }
            return _hookShotPool;
        }
        public void Collect()
        {
            Hook_Shot hookShot;
            if(hookShots.Count > 0)
            {
                hookShot = hookShots.Peek();
            }
            else
            {
                hookShot = (Hook_Shot)ItemSpriteFactory.getFactory().CreateHookShot(position);
            }
            hookShots.Enqueue(hookShot);
        }

        public Hook_Shot Get()
        {
            Hook_Shot hookShot;
            if (hookShots.Count > 0)
            {
                hookShot = hookShots.Dequeue();
                if (Mario.GetMario().GetDirection() > 0)
                {
                    hookShot.Pos = new Vector2(Mario.GetMario().Pos.X + 100, Mario.GetMario().Pos.Y);
                }
                else
                {
                    hookShot.Pos = new Vector2(Mario.GetMario().Pos.X - 100, Mario.GetMario().Pos.Y);
                }
                return hookShot;
            }
            else
            {
                return null;
            }
        }
    }
}
