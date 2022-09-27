using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Commands
{
    internal class MarioCommand : ICommand
    {
        public MarioCommand(Mario nRef) : base(nRef) { }

        public override void Execute()
        {
            
            ((Mario)Ref).SetPowerup();
            ((Mario)Ref).SetAction();
        }

        


    }
}
