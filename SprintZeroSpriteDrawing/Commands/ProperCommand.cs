using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.States.BlockState;

namespace SprintZeroSpriteDrawing.Commands
{
    class CmdTogVis : ICommand
    {
        public CmdTogVis(QuestionBolckState nRef) : base(nRef) { }

        public override void Execute()
        {
            ((ISprite)Ref).Trigger();
        }
    }
}
