using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZeroSpriteDrawing.Sprites
{
    internal class Animation
    {
        public Texture2D Sprite { get; set; }
        public int Frame { get; set; }
        public int Subframe { get; set; }
        public int SubframeLimit { get; set; }
        public bool AutoFrame { get; set; }
        public int StartFrame { get; set; }
        public int LastFrame { get; set; }
        private Vector2 SheetSize;
        private Vector2 FrameSize;

        public Animation(Texture2D nSprite, Vector2 nSheetSize)
        { 
            SheetSize = nSheetSize;
            SubframeLimit = 20;
            AutoFrame = true;
            Sprite = nSprite;
            SheetSize = nSheetSize;
            StartFrame = 0;
            LastFrame = (int)(SheetSize.X * SheetSize.Y);
            if (nSprite != null)
                FrameSize = new Vector2(nSprite.Width / SheetSize.X, nSprite.Height / SheetSize.Y);

        }
        public int NextFrame()
        {
            return Frame++;
        }
    }
}
