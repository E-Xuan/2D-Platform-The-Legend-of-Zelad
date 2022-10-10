﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
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
            int x = 48;
            int y = 48;
            FileStream fileStream = File.Open(levelName, FileMode.OpenOrCreate, FileAccess.Read);
            while (FindStartLine(fileStream) != 255)
            {
                while (GenerateEntity(x, y, fileStream) != -1)
                {
                    x += 48;
                }
                x = 48;
                y += 48;
            }
        }

        private int FindStartLine(FileStream fileStream)
        {
            char err = (char)((fileStream.ReadByte() + 256) % 256);
            while (!(err == 255 || err == '>'))
            {
                err = (char)((fileStream.ReadByte() + 256) % 256);
            }
            return err;
        }

        private int GenerateEntity(int x, int y, FileStream fileStream)
        {
            
            char err = (char)((fileStream.ReadByte() + 256) % 256);
            ISprite entity = null;
            if (err == '<')
                return -1;
            switch (err)
            {
                #region mario
                case 'M':
                    Mario.GetMario().Pos = new Vector2(x, y);
                    Mario.GetMario().UpdateBBox();
                    entity = Mario.GetMario();
                    break;
                #endregion
                #region enemies
                case 'G':
                    entity = EnemySpriteFactory.getFactory().CreateGoomba(new Vector2(x, y));
                    break;
                case 'k':
                    entity = EnemySpriteFactory.getFactory().CreateGreenKoopa(new Vector2(x, y));
                    break;
                case 'K':
                    entity = EnemySpriteFactory.getFactory().CreateRedKoopa(new Vector2(x, y));
                    break;
                #endregion
                #region blocks
                case '?':
                    entity = BlockSpriteFactory.getFactory().CreateQuestionBlock(new Vector2(x, y), true);
                    break;
                case '!':
                    entity = BlockSpriteFactory.getFactory().CreateMQuestionBlock(new Vector2(x, y), true);
                    break;
                case '@':
                    entity = BlockSpriteFactory.getFactory().CreateFQuestionBlock(new Vector2(x, y), true);
                    break;
                case '#':
                    entity = BlockSpriteFactory.getFactory().CreateSQuestionBlock(new Vector2(x, y), true);
                    break;
                case '$':
                    entity = BlockSpriteFactory.getFactory().Create5CQuestionBlock(new Vector2(x, y), true);
                    break;
                case '%':
                    entity = BlockSpriteFactory.getFactory().CreateUQuestionBlock(new Vector2(x, y), true);
                    break;


                case 'h':
                    entity = BlockSpriteFactory.getFactory().CreateQuestionBlock(new Vector2(x, y), false);
                    break;
                case 'b':
                    entity = BlockSpriteFactory.getFactory().CreateBrickBlock(new Vector2(x, y));
                    break;
                case 'g':
                    entity = BlockSpriteFactory.getFactory().CreateGroundBlock(new Vector2(x, y));
                    break;
                case 's':
                    entity = BlockSpriteFactory.getFactory().CreateStairBlock(new Vector2(x, y));
                    break;
                case 'u':
                    entity = BlockSpriteFactory.getFactory().CreateUsedBlock(new Vector2(x, y));
                    break;
                #endregion
                #region items
                case 'm':
                    entity = ItemSpriteFactory.getFactory().createSMushroom(new Vector2(x, y));
                    break;
                case 'f':
                    entity = ItemSpriteFactory.getFactory().createFlower(new Vector2(x, y));
                    break;
                case 'S':
                    entity = ItemSpriteFactory.getFactory().createStar(new Vector2(x, y));
                    break;
                case 'c':
                    entity = ItemSpriteFactory.getFactory().createCoin(new Vector2(x, y));
                    break;
                case 'U':
                    entity = ItemSpriteFactory.getFactory().createUPMushroom(new Vector2(x, y));
                    break;
                #endregion

                default:
                    return err;
            }
            Game1.SpriteList.Add(entity);
            return err;
        }
       

    }
}
