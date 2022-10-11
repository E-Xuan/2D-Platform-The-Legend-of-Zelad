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

        public static CollisionDetector getCD()
        {
            return CD;
        }
        public Direction DetectColDirection(ICollideable FirstObject, ICollideable SecondObject)
        {
            Rectangle Intersection = Rectangle.Intersect(FirstObject.BBox, SecondObject.BBox);
            if (!Intersection.IsEmpty)
            {
                if(Intersection.Height > Intersection.Width && FirstObject.BBox.X < SecondObject.BBox.X)
                {
                    return Direction.LEFT;
                }
                if(Intersection.Height > Intersection.Width && FirstObject.BBox.X > SecondObject.BBox.X)
                {
                    return Direction.RIGHT;
                }
                if(Intersection.Width > Intersection.Height && FirstObject.BBox.Y < SecondObject.BBox.Y)
                {
                    return Direction.TOP;
                }
                if(Intersection.Width > Intersection.Height && FirstObject.BBox.Y > SecondObject.BBox.Y)
                {
                    return Direction.BOTTOM;
                }
            }
            return Direction.NULL;
        }
    }
}
