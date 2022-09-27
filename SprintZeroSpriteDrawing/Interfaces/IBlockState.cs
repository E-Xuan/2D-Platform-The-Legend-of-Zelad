using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces
{
    public enum State
    {
        UNTAPPED,
        TAPPED
    }
    public interface IBlockState
    {
        void Collide();
        void Update();
        //State GetState();
    }
}
