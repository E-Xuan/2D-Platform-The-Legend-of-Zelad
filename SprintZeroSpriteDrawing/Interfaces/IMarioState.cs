using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace SprintZeroSpriteDrawing.Interfaces
{
    public interface IMarioState
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
       

        
    }
}
