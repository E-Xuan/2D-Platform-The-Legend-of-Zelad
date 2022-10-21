using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Background
{
    public class Layer
    {
        public Layer(Camera2D camera2D)
        {
            _Camera2D = camera2D;
            Parallax = Vector2.One;
            Sprites = new List<ICollideable>();
        }

        public Vector2 Parallax { get; set; }
        public List<ICollideable> Sprites { get; private set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _Camera2D.GetViewMatrix(Parallax));
            foreach (ICollideable sprite in Sprites)
                sprite.Draw(spriteBatch);
            spriteBatch.End();
        }

        private readonly Camera2D _Camera2D;
    }
}
