using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SprintZeroSpriteDrawing.Collision
{
    // Add the grid and create the map
    // Map <new Vecrtor2(x, y), Values will be the items stored in each sepreate grid>
    public class CollisionDetector
    {
        private static CollisionDetector CD;
        int velocity = 5;

        List<ICollideable>[,] list = new List<ICollideable>[(int)(Game1.SCREENSIZE.X / 48), (int)(Game1.SCREENSIZE.Y/48)];


        public CollisionDetector(List<ICollideable> spriteList)
        {
            foreach(ICollideable sprite in spriteList)
            {
                list[(int)(sprite.Pos.X / 48), (int)(sprite.Pos.Y / 48)].Add(sprite);
            }
        }

        public static CollisionDetector getCD()
        {
            return CD;
        }

        public bool IsTouchingLeft(Rectangle firstObject, Rectangle secondObject)
        {
            
            return firstObject.Right + velocity > secondObject.Left && 
                firstObject.Left < secondObject.Left &&
                firstObject.Bottom > secondObject.Top &&
                firstObject.Top < secondObject.Bottom;
        }
        public bool IsTouchingRight(Rectangle firstObject, Rectangle secondObject)
        {
            return firstObject.Left + velocity > secondObject.Right &&
                firstObject.Right < secondObject.Right &&
                firstObject.Bottom > secondObject.Top &&
                firstObject.Top < secondObject.Bottom;
        }
        public bool ISTouchingTop(Rectangle firstObject, Rectangle secondObject)
        {
            return firstObject.Bottom + velocity > secondObject.Top &&
                firstObject.Top < secondObject.Top &&
                firstObject.Right > secondObject.Left &&
                firstObject.Left < secondObject.Right;
        }
        public bool ISTouchingDown(Rectangle firstObject, Rectangle secondObject)
        {
            return firstObject.Top + velocity > secondObject.Bottom &&
                firstObject.Bottom < secondObject.Bottom &&
                firstObject.Right > secondObject.Left &&
                firstObject.Left < secondObject.Right;
        }
    }
}
