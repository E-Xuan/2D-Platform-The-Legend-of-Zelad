using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Collision
{
    public class CollisionDetector
    {
        int velocity = 5;
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
