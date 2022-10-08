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
