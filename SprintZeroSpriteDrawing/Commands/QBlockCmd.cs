using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;

namespace SprintZeroSpriteDrawing.Commands
{
    public class QBlockCmd : ICommand
    {
        public QBlockCmd(QuestionBlock nRef) : base(nRef) { }

        public override void Execute()
        {
            
            ((QuestionBlock)Ref).TogVis(0);
        }
       
    }
}
