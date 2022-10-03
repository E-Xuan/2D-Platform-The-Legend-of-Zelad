using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;

namespace SprintZeroSpriteDrawing.Commands
{
    internal class QBlockCmd : ICommand
    {
        public QBlockCmd(QuestionBlock nRef) : base(nRef) { }

        public override void Execute()
        {
            
            ((QuestionBlock)Ref).State.ChangeState((int)State.BUMPING);
        }
       
    }
}
