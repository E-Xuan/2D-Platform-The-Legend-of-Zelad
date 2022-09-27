using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class ItemSpriteFactory
    {
        public Vector2 nPos { get; set; }
        public Vector2 SheetSize;

        public Texture2D Coin;
        public Texture2D FireFlower;
        public Texture2D SMushroom;
        public Texture2D UPMushroom;
        public Texture2D Star;

        private static ItemSpriteFactory sprite = new ItemSpriteFactory();
        public static ItemSpriteFactory Sprite
        {
            get { return sprite; }
        }

        public void LoadContent(ContentManager content)
        {
            Coin = content.Load<Texture2D>("Items/Coins");
            FireFlower = content.Load<Texture2D>("Items/FireFlower");
            SMushroom = content.Load<Texture2D>("Items/SuperMushroom");
            UPMushroom = content.Load<Texture2D>("Items/1UPMushroom");
            Star = content.Load<Texture2D>("Items/Starman");
        }

        public ISprite createCoin()
        {
            return new Coins(Coin, SheetSize, nPos);
        }
        public ISprite createFlower()
        {
            return new FireFlower(FireFlower, SheetSize, nPos);
        }
        public ISprite createUPMushroom()
        {
            return new OneUPMushroom(UPMushroom, SheetSize, nPos);
        }
        public ISprite createSMushroom()
        {
            return new SuperMushroom(SMushroom, SheetSize, nPos);
        }
        public ISprite createStar()
        {
            return new Starman(Star, SheetSize, nPos);
        }
    }
}

