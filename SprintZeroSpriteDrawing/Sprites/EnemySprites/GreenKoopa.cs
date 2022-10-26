using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Sprites.EnemySprites
{
    public class GreenKoopa : Enemy
    {
        public GreenKoopa(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            Frame = 2;
            StartFrame = 0;
            LastFrame = 2;
        }
        public override void kill(int kill)
        {
            //base.kill(kill);
            /*Frame = 2;
            this.Velocity = new Vector2(0, 0);
            this.Acceleration = new Vector2(0, 0);*/
            State.CurrState = Interfaces.EnemyState.State.SHELLIDLE;
        }
        /*public override void Update()
        {
            //State.CurrState = Interfaces.EnemyState.State.MOVING;
        }*/
    }
}
