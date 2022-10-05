using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;

namespace SprintZeroSpriteDrawing.LevelLoader
{
    public class LevelLoader
    {
        private static LevelLoader loader;

        public static LevelLoader GetLevelLoader()
        {
            if (loader == null)
                loader = new LevelLoader();
            return loader;
        }
        public void LoadLevel(String levelName)
        {
            FileStream fileStream = File.Open(levelName, FileMode.Open, FileAccess.Read);
            char err = (char)((fileStream.ReadByte() + 256) % 256);

            while (err != 255)
            {
                err = (char)((fileStream.ReadByte() + 256) % 256);
                Console.Write(err);
            }
        }

        private void GenerateEntity(char entityChar, int x, int y)
        {
            Random UUIDGen = new Random();
            ISprite entity = null;
            switch (entityChar)
            {
                case 'g':
                    entity = BlockSpriteFactory.getFactory().CreateGroundBlock(new Vector2(x, y));
                    break;
                case 's':
                    entity = BlockSpriteFactory.getFactory().CreateStairBlock(new Vector2(x, y));
                    break;
            }
            Game1.SpriteList.Add(UUIDGen.Next().ToString(), entity);
        }

    }
}
