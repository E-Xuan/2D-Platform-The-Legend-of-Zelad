using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Collision.ItemCollision
{
    internal class StarmanCollision : ICommand
    {
        public StarmanCollision(object nRef) : base(nRef)
        {
        }
    }
}
