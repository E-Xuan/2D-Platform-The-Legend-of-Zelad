using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces
{
    public interface IBlockState
    {
        bool Used { get; }
        void BeTriggered();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
