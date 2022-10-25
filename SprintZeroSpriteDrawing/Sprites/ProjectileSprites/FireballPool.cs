using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ProjectileSprites
{
    public class FireballPool<Fireball> where Fireball : new()
    {
        private readonly ConcurrentBag<Fireball> fireballs = new ConcurrentBag<Fireball>();
        private int MAX = 10;
        private int counter = 0;

        private void Release(Fireball fireball)
        {
            if(counter < MAX)
            {
                fireballs.Add(fireball);
                counter++;
            }
        }
        public Fireball Get()
        {
            Fireball fireball;
            if (fireballs.TryTake(out fireball))
            {
                counter--;
                return fireball;
            }
            else
            {
                Fireball nFireball = new Fireball();
                fireballs.Add(nFireball);
                counter++;
                return nFireball;
            }
        }
    }
}
