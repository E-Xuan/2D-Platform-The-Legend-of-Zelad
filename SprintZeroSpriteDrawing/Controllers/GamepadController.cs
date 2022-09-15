using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;

namespace SprintZeroSpriteDrawing.Controllers
{
    public class GamepadController : IController<Buttons>
    {
        GamePadState PreviousState;
        public Dictionary<Buttons, ICommand> CommandList { get; set; }
        int PlayerIndex = 0;
        public GamepadController() {
            CommandList = new Dictionary<Buttons, ICommand>();
            PreviousState = GamePad.GetState(PlayerIndex);
        }
        public GamepadController(Dictionary<Buttons, ICommand> keybindings)
        {
            CommandList = keybindings;
            PreviousState = GamePad.GetState(PlayerIndex);
        }
        public GamepadController(Dictionary<Buttons, ICommand> keybindings, int nPlayerIndex)
        {
            CommandList = keybindings;
            PlayerIndex = nPlayerIndex;
            PreviousState = GamePad.GetState(PlayerIndex);
        }

        public void UpdateBinding(Buttons key, ICommand command) {
            if (!CommandList.TryAdd(key, command)) {
                CommandList.Remove(key);
                CommandList.Add(key, command);
            }
        }

        public bool RemoveBinding(Buttons key) {
            if (CommandList.ContainsKey(key))
            {
                CommandList.Remove(key);
                return true;
            }
            return false;
        }

        public void UpdateInput() {
            GamePadState CurrentState = GamePad.GetState(PlayerIndex);
            foreach (KeyValuePair<Buttons, ICommand> command in CommandList) {
                if (CurrentState.IsButtonDown(command.Key) && !PreviousState.IsButtonDown(command.Key))
                {
                    command.Value.OnStart();
                }
                else if (CurrentState.IsButtonDown(command.Key))
                {
                    command.Value.OnLoop();
                }
                else if (!CurrentState.IsButtonDown(command.Key) && PreviousState.IsButtonDown(command.Key))
                {
                    command.Value.OnStop();
                }
            }
            PreviousState = CurrentState;
        }
    }
}
