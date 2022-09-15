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
        ISprite Refrence { get; set; }
        public CmdTogVis(ISprite nRefrence) {
            Refrence = nRefrence;
        }
        public void OnLoop()
        {
        }

        public void OnStart()
        {
            Refrence.TogVis(0);
        }

        public void OnStop()
        {
        }
    }
}
