﻿using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SprintZeroSpriteDrawing.Sprites
{

    /// <summary>
    /// This is a moving, animated, sprite class that is
    /// used to build the most complicated and visually interesting
    /// sprites, such as the main character and complex enemies
    /// </summary>
    internal class Coins : ISprite
    {
        public bool IsVis { get; set; }
        public Texture2D Sprite { get; set; }
        public Vector2 Pos { get; set; }
        public int Frame { get; set; }
        public int Subframe { get; set; }
        public int SubframeLimit { get; set; }
        public bool AutoFrame { get; set; }
        private int LastFrame;
        private Vector2 SheetSize;
        private Vector2 FrameSize;
        public Coins(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos)
        {
            SubframeLimit = 20;
            AutoFrame = true;
            Sprite = nSprite;
            Pos = nPos;
            SheetSize = nSheetSize;
            LastFrame = (int)(SheetSize.X * SheetSize.Y);
            if (nSprite != null)
                FrameSize = new Vector2(nSprite.Width / SheetSize.X, nSprite.Height / SheetSize.Y);
        }
        public void SetSprite(Texture2D nSprite)
        {
            Sprite = nSprite;
            FrameSize = new Vector2(nSprite.Width / SheetSize.X, nSprite.Height / SheetSize.Y);
        }

        public int NextFrame()
        {
            return Frame++;
        }

        public int Draw(SpriteBatch batch)
        {
            if (IsVis)
            {
                Rectangle Rect = new Rectangle((int)(Frame % (int)SheetSize.X * FrameSize.X), (int)(Frame / (int)SheetSize.X * FrameSize.Y),
                    (int)FrameSize.X, (int)FrameSize.Y);
                batch.Draw(Sprite, Pos, Rect, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
                if (AutoFrame)
                    Subframe++;
                if (Subframe == SubframeLimit)
                {
                    Subframe = 0;
                    Frame = (Frame + 1) % LastFrame;
                }
                return Frame;
            }
            return -2;
        }
        virtual public void Update()
        {
            //OVERRIDE ME
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
        public void SetVis(int nIsVis)
        {
            IsVis = nIsVis > 0;
        }
        public void TogVis(int nIsVis)
        {
            IsVis = !IsVis;
        }
    }
}