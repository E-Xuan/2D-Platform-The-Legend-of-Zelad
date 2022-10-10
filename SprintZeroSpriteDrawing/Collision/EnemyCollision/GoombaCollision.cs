using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Collision.EnemyCollision
{
    internal class GoombaCollision : ICommand
    {
        public GoombaCollision(object nRef) : base(nRef)
        {
        }
    }
}
