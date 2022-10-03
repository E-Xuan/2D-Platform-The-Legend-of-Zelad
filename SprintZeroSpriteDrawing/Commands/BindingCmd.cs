using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Controllers;
using SprintZeroSpriteDrawing.Commands;

namespace SprintZeroSpriteDrawing.Commands
{
    internal class BindingCmd
    {
        private Dictionary<Keys, ICommand> kCommandList = new Dictionary<Keys, ICommand>();
        private IController<Keys> keyboardController;
        private IController<Buttons> gamepadController;

        keyboardController = new KeyboardController();
        gamepadController = new GamepadController();
        keyboardController.UpdateBinding(Keys.A, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).MoveAction, -1)), BindingType.PRESSED);
        keyboardController.UpdateBinding(Keys.Left, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).MoveAction, -1)), BindingType.PRESSED);

        keyboardController.UpdateBinding(Keys.D, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).MoveAction, 1)), BindingType.PRESSED);
        keyboardController.UpdateBinding(Keys.Right, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).MoveAction, 1)), BindingType.PRESSED);

        keyboardController.UpdateBinding(Keys.Y, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).SetPowerup, 1)), BindingType.PRESSED);
        keyboardController.UpdateBinding(Keys.U, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).SetPowerup, 2)), BindingType.PRESSED);
        keyboardController.UpdateBinding(Keys.I, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).SetPowerup, 3)), BindingType.PRESSED);
        keyboardController.UpdateBinding(Keys.O, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).TakeDamage, -1)), BindingType.PRESSED);

        keyboardController.UpdateBinding(Keys.W, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).IncreaseAction, 3)), BindingType.PRESSED);
        keyboardController.UpdateBinding(Keys.Up, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).IncreaseAction, 3)), BindingType.PRESSED);
           
        keyboardController.UpdateBinding(Keys.S, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).DecreaseAction, 4)), BindingType.PRESSED);
        keyboardController.UpdateBinding(Keys.Down, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).DecreaseAction, 4)), BindingType.PRESSED);

        keyboardController.UpdateBinding(Keys.B, new IntCmd(new KeyValuePair<Action<int>, int>(((Block) spriteList["BBlock"]).Bump, 1)), BindingType.PRESSED);
        keyboardController.UpdateBinding(Keys.OemQuestion, new IntCmd(new KeyValuePair<Action<int>, int>(((Block) spriteList["QBlock"]).Bump, 1)), BindingType.PRESSED);
        keyboardController.UpdateBinding(Keys.H, new IntCmd(new KeyValuePair<Action<int>, int>(((Block) spriteList["InvisibleBlock"]).Bump, 1)), BindingType.PRESSED);

        gamepadController.UpdateBinding(Buttons.LeftStick, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).MoveAction, -1)), BindingType.PRESSED);
        gamepadController.UpdateBinding(Buttons.RightStick, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).MoveAction, 1)), BindingType.PRESSED);

        gamepadController.UpdateBinding(Buttons.DPadUp, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).IncreaseAction, 3)), BindingType.PRESSED);
        gamepadController.UpdateBinding(Buttons.DPadDown, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario) spriteList["Mario"]).DecreaseAction, 4)), BindingType.PRESSED);

    }
}
