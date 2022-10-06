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
            //keyboardController.UpdateBinding(Keys.B, new IntCmd(new KeyValuePair<Action<int>, int>(((Block)SpriteList["BBlock"]).ChangeState, (int)State.BUMPING)), BindingType.PRESSED);
            //keyboardController.UpdateBinding(Keys.OemQuestion, new IntCmd(new KeyValuePair<Action<int>, int>(((Block)SpriteList["QBlock"]).ChangeState, (int)State.BUMPING)), BindingType.PRESSED);
            //keyboardController.UpdateBinding(Keys.H, new IntCmd(new KeyValuePair<Action<int>, int>(((Block)SpriteList["IBlock"]).ChangeState, (int)State.BUMPING)), BindingType.PRESSED);
        }
    }
}
