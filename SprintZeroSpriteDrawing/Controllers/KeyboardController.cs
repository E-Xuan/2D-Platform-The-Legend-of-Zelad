using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;

namespace SprintZeroSpriteDrawing.Controllers
{
    /// <summary>
    /// This is a keys based implementation of the IController interface that fires commands
    /// stored in a dictionary when their assosiated keys are pressed
    /// </summary>
    public class KeyboardController : IController<Keys>
    {
        /// <summary>
        /// This is the previous state of the keys array assosiated with
        /// this given keyboard when the last update was called
        /// </summary>
        KeyboardState PreviousState;
        public Dictionary<Keys, ICommand> CommandList { get; set; }

        public KeyboardController() {
            CommandList = new Dictionary<Keys, ICommand>();
            PreviousState = Keyboard.GetState();
        }
        public KeyboardController(Dictionary<Keys, ICommand> keybindings)
        {
            CommandList = keybindings;
            PreviousState = Keyboard.GetState();
        }

        public void UpdateBinding(Keys key, ICommand command) {
            if (!CommandList.TryAdd(key, command)) {
                CommandList.Remove(key);
                CommandList.Add(key, command);
            }
        }

        public bool RemoveBinding(Keys key) {
            if (CommandList.ContainsKey(key))
            {
                CommandList.Remove(key);
                return true;
            }
            return false;
        }

        public void UpdateInput() {
            KeyboardState CurrentState = Keyboard.GetState();
            foreach (KeyValuePair<Keys, ICommand> Command in CommandList) {
                if (CurrentState.IsKeyDown(Command.Key) && !PreviousState.IsKeyDown(Command.Key))
                {
                    //On pressed
                    Command.Value.OnStart();
                }
                #region bonusCode
                else if (CurrentState.IsKeyDown(Command.Key))
                {
                    //On held
                    Command.Value.OnLoop();
                }
                else if (!CurrentState.IsKeyDown(Command.Key) && PreviousState.IsKeyDown(Command.Key)) {
                    //On released
                    Command.Value.OnStop();
                }
                #endregion
            }
            PreviousState = CurrentState;
        }
    }
}
