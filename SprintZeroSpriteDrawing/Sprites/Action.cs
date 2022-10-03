using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites
{
    internal class Action
    {
        public Texture2D Sprite { get; set; }
        public Vector2 Pos { get; set; }
        public Action(Texture2D nSprite, Vector2 nPos) 
        { 
            Sprite = nSprite;
            Pos = nPos;
        }
        
        public void MoveSprite(Vector2 displacement)
        {
            Pos = Vector2.Add(Pos, displacement);
        }
        public void MoveX(int pixels)
        {
            Pos = Vector2.Add(Pos, new Vector2(pixels, 0));
        }
        public void MoveY(int pixels)
        {
            Pos = Vector2.Add(Pos, new Vector2(0, pixels));
        }
    }
}
