using System;
using System.Collections.Generic;
using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace SprintZeroSpriteDrawing.Interfaces
{
    /// <summary>
    /// This code sets up the requirements for a controller specifying
    /// a command binding list and an input updating method to fire commands.
    /// </summary>
    /// <typeparam name="T"> This is the type of trigger: (Keys, Buttons, Etc)</typeparam>
    public interface IController<T>
    {
        /// <summary>
        /// This maps the commands assositated with each key
        /// </summary>
        Dictionary<T, ICommand> CommandList { get; set; }
        public void UpdateInput();

        //This could really be an abstract class... The update bindings method is the same either way
        public void UpdateBinding(T key, ICommand command);

        public bool RemoveBinding(T key);
    }
}
