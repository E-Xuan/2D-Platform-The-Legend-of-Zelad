﻿using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using SprintZeroSpriteDrawing.GameMode;

namespace SprintZeroSpriteDrawing.Interfaces.GameState
{
    public enum State
    {
        NORMAL,
        DEBUG,
        COLLISIONS
    }

    
    public class IGameState
    {
        protected Mode mode;
        public State CurrState { get; set; }
        

        public IGameState(Mode nMode)
        {
            mode = nMode;
            Enter();
        }

        public virtual void Update() { }
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location) { }
        public virtual void Enter() { }
        public virtual void Exit(){ }
        public virtual void ChangeState(int state) { }
    }
}