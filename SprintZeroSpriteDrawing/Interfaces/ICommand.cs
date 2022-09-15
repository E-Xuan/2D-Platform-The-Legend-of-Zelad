using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces
{
    /// <summary>
    /// This is a command interface made of three parts, on start, on loop, and on stop
    /// on start is fired when a key is first pressed, on loop is fired when a key is held
    /// down, and on stop is fired when a key is released
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// This method is fired at the beginning of the command execution, generally
        /// when a key is pressed or a trigger is hit
        /// </summary>
        public void OnStart();
        /// <summary>
        /// This method should be fired constantly until the OnStop() method is called
        /// This may be empty, or not called by all triggering systems
        /// </summary>
        public void OnLoop();
        /// <summary>
        /// This method should be fired once at the conclusion of the OnLoop() method
        /// This may be empty, or not called by all triggering systems
        /// </summary>
        public void OnStop();
    }
}
