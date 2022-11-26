using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;
using SprintZeroSpriteDrawing.Sprites.SpriteFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ItemSprites
{
    public class BombPool
    {
        public Queue<Bomb> bombs = new Queue<Bomb>();
        public static int BombsMax = 8;
        public static Vector2 position;
        private static BombPool _bombPool;
        public BombPool(Bomb bomb)
        {
            bombs.Enqueue(bomb);
            while(bombs.Count < BombsMax)
                bombs.Enqueue((Bomb)ItemSpriteFactory.getFactory().CreateBomb(position));

        }
        public static BombPool GetBombPool()
        {
            if (_bombPool == null)
            {
                _bombPool = new BombPool((Bomb)ItemSpriteFactory.getFactory().CreateBomb(position));
            }
            return _bombPool;
        }
        public void Release(Bomb bomb)
        {
            bombs.Enqueue(bomb);
        }
        public Bomb Get()
        {
            Bomb bomb;
            if (bombs.Count > 0)
            {
                bomb = bombs.Dequeue();
                if(Mario.GetMario().GetDirection() > 0)
                {
                    bomb.Pos = new Vector2(Mario.GetMario().Pos.X + 100, Mario.GetMario().Pos.Y);
                }
                else
                {
                    bomb.Pos = new Vector2(Mario.GetMario().Pos.X - 100, Mario.GetMario().Pos.Y);
                }

                return bomb;
            }
            else
            {
                return null;
            }
        }
    }
}

