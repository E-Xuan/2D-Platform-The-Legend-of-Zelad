﻿using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public class BombExplosion : IToolState
    {
        public BombExplosion(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.BOMBEXPLOSION;
            tool.CollideableType = Entitiy.CType.EXPBOMB;
            tool.Velocity = new Vector2(0, 0);
            tool.Acceleration = new Vector2(0, 0);
            tool.StartFrame = 1;
            tool.IsVis = true;
            tool.AutoFrame = true;

        }
        public override void Update()
        {
            base.Update();
            //CollisionManager.getCM().DeRegEntity(tool);
            CollisionManager.getCM().DeRegMoving(tool);
            if (tool.Frame == 3)
            {
                Game1.SpriteList.Remove(tool);
                CollisionManager.getCM().DeRegEntity(tool);

            }
        }
    }
}