using SprintZeroSpriteDrawing.Interfaces.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.GameMode
{
    public class Mode
    {
        public IGameState State { get; set; }
        public Mode()
        {
            State = new GameNormal(this);
        }

        public void ChangeState(int state)
        {
            this.State.ChangeState(state);
        }

        public void Update()
        {
            State.Update();
        }



    }
}
