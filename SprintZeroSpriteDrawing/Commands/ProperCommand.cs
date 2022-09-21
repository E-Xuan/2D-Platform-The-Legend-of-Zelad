using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces;

namespace SprintZeroSpriteDrawing.Commands
{
    class CmdTogVis : ICommand
    {
        public CmdTogVis(ISprite nRef) : base(nRef) { }

        public override void Execute()
        {
            ((ISprite)Ref).TogVis(0);
        }
    }
}
