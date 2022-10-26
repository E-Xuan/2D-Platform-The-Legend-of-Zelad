using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;

namespace SprintZeroSpriteDrawing.Interfaces.ProjectileState
{
    public class ProjectileAppear : IProjectileState
    {
        public ProjectileAppear(Projectile nProjectile) : base(nProjectile)
        {

        }
 
        public override void Enter()
        {
            CurrState = State.APPEAR;
            projectile.IsVis = true;
            projectile.Velocity = new Vector2(6, (float)2.5);
            projectile.Acceleration = new Vector2((float)0.065, (float).065);
        }

        public override void ChangeState(int state)
        {
            switch ((State)state)
            {
                case State.DISAPPEAR:
                    Exit();
                    projectile.State = new ProjectileDisappear(projectile);
                    break;
            }
        }
    }
}

