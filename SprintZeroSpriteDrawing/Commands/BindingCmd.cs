using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Controllers;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.BlockState;

namespace SprintZeroSpriteDrawing.Commands
{
    public class BindingCmd
    {
        public static void SetGameBinding(Dictionary<string, ISprite> SpriteList, IController<Keys> keyboardController, IController<Buttons> gamepadController)
        {

            keyboardController.UpdateBinding(Keys.A, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).MoveAction, -1)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.Left, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).MoveAction, -1)), BindingType.PRESSED);

            keyboardController.UpdateBinding(Keys.D, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).MoveAction, 1)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.Right, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).MoveAction, 1)), BindingType.PRESSED);

            keyboardController.UpdateBinding(Keys.Y, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).SetPowerup, 1)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.U, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).SetPowerup, 2)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.I, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).SetPowerup, 3)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.O, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).TakeDamage, -1)), BindingType.PRESSED);

            keyboardController.UpdateBinding(Keys.W, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).IncreaseAction, 3)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.Up, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).IncreaseAction, 3)), BindingType.PRESSED);

            keyboardController.UpdateBinding(Keys.S, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).DecreaseAction, 4)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.Down, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).DecreaseAction, 4)), BindingType.PRESSED);

            keyboardController.UpdateBinding(Keys.B, new IntCmd(new KeyValuePair<Action<int>, int>(((Block)SpriteList["BBlock"]).ChangeState, (int)State.BUMPING)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.OemQuestion, new IntCmd(new KeyValuePair<Action<int>, int>(((Block)SpriteList["QBlock"]).ChangeState, (int)State.BUMPING)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.H, new IntCmd(new KeyValuePair<Action<int>, int>(((Block)SpriteList["IBlock"]).ChangeState, (int)State.BUMPING)), BindingType.PRESSED);

            gamepadController.UpdateBinding(Buttons.LeftStick, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).MoveAction, -1)), BindingType.PRESSED);
            gamepadController.UpdateBinding(Buttons.RightStick, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).MoveAction, 1)), BindingType.PRESSED);

            gamepadController.UpdateBinding(Buttons.DPadUp, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).IncreaseAction, 3)), BindingType.PRESSED);
            gamepadController.UpdateBinding(Buttons.DPadDown, new IntCmd(new KeyValuePair<Action<int>, int>(((Mario)SpriteList["Mario"]).DecreaseAction, 4)), BindingType.PRESSED);
        }
    }
}
