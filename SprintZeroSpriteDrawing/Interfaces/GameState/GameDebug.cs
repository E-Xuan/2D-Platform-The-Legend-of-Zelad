using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.GameMode;

namespace SprintZeroSpriteDrawing.Interfaces.GameState
{
    public class GameDebug : IGameState
    {
        public GameDebug(Mode nMode) : base(nMode)
        {
        }

        public override void Enter()
        {
            CurrState = State.DEBUG;
        }

        public override void ChangeState(int state)
        {
            switch ((State)state)
            {
                case State.COLLISIONS:
                    Exit();
                    mode.State = new GameCollisions(mode);
                    break;
                case State.NORMAL:
                    Exit();
                    mode.State = new GameNormal(mode);
                    break;
            }
        }
    }
}
