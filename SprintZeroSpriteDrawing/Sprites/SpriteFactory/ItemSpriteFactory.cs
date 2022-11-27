using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
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
        public Texture2D Pirana;
        public Texture2D Bomb;

        private static ItemSpriteFactory sprite;
        public static ItemSpriteFactory getFactory()
        {
            if (sprite == null)
            {
                sprite = new ItemSpriteFactory();
            }
            return sprite;
        }

        public void LoadContent(ContentManager content)
        {
            Coin = content.Load<Texture2D>("Items/Coins");
            FireFlower = content.Load<Texture2D>("Items/FireFlower");
            SMushroom = content.Load<Texture2D>("Items/SuperMushroom");
            UPMushroom = content.Load<Texture2D>("Items/1UPMushroom");
            Star = content.Load<Texture2D>("Items/Starman");
            Pirana = content.Load<Texture2D>("Enemy/Piranha");
            Bomb = content.Load<Texture2D>("Tools/Bomb");
        }

        public ISprite createCoin(Vector2 nPos)
        {
            return new Coins(Coin, new Vector2(2, 2), nPos);
        }
        public ISprite createFlower(Vector2 nPos)
        {
            return new FireFlower(FireFlower, new Vector2(4, 2), nPos);
        }
        public ISprite createUPMushroom(Vector2 nPos)
        {
            return new OneUPMushroom(UPMushroom, new Vector2(1, 1), nPos);
        }
        public ISprite createSMushroom(Vector2 nPos)
        {
            return new SuperMushroom(SMushroom, new Vector2(1, 1), nPos);
        }
        public ISprite createStar(Vector2 nPos)
        {
            return new Starman(Star, new Vector2(2, 2), nPos);
        }
        public ISprite CreatePiranaPlant(Vector2 nPos)
        {
            return new PiranaPlant(Pirana, new Vector2(2, 1), nPos);
        }
        public ISprite CreateBomb(Vector2 nPos)
        {
            return new Bomb(Bomb, new Vector2(2, 2), nPos);
        }
    }
}

