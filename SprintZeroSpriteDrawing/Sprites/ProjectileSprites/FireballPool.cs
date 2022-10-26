using SprintZeroSpriteDrawing.Sprites.SpriteFactory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;

namespace SprintZeroSpriteDrawing.Sprites.ProjectileSprites
{
    public class FireballPool
    {
        public Queue<Fireball> fireballs = new Queue<Fireball>();
        public readonly int MAX = 2;
        public int counter = 0;
        public int mode;

        private static FireballPool _fireballPool;
        public static FireballPool GetFireballPool()
        {
            if (_fireballPool == null)
            {
                _fireballPool = new FireballPool((Fireball)ProjectileSpriteFactory.getSpriteFactory().CreateFireball(Mario.GetMario().Pos));
            }
            return _fireballPool;
        }

        public FireballPool(Fireball fireball)
        {
            fireballs.Enqueue(fireball);
            fireballs.Enqueue(fireball);
        }

        private void Release(Fireball fireball)
        {
            if(counter < MAX)
            {
                fireballs.Enqueue(fireball);
                counter++;
            }
        }

        
        public Fireball Get()
        {
            Fireball fireball;
            if (fireballs.Count > 0)
            {
                fireball = fireballs.Dequeue();
                counter--;
                return fireball; 
            }
            else
            {

                return null;
                
            }
        }
    }
}
