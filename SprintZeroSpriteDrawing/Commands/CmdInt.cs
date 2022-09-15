using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces;

namespace SprintZeroSpriteDrawing.Commands
{
    internal class CmdInt : ICommand
    {
        KeyValuePair<Action<int>, int> Command;
        public bool Toggle { get; set; }
        public CmdInt(KeyValuePair<Action<int>, int> nCommand, bool nToggle) {
            Toggle = nToggle;
            Command = nCommand;
        }
        public void OnStart()
        {
                Command.Key(Command.Value);
        }
        public void OnLoop()
        {
            if(!Toggle)
                Command.Key(Command.Value);
        }
        public void OnStop()
        {
            if (!Toggle)
                Command.Key(Command.Value);
        }
    }
}
