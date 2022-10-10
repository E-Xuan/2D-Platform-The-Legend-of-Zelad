using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Collision.ItemCollision
{
    internal class CoinsCollision : ICommand
    {
        public CoinsCollision(object nRef) : base(nRef)
        {
        }
    }
}
