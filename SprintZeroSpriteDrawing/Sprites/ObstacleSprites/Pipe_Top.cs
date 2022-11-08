using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces.BlockState;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class Pipe_Top : Block
    {
        private int timecounter = 0;
        private Item recurInvin;
        public Pipe_Top(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            State = new BlockTapped(this); 
            recurInvin = null;
        }
        public Pipe_Top(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, List<Item> inventory) : base(nSprite, nSheetSize, nPos, inventory)
        {
            recurInvin = inventory[0];
        }

        public override void Update()
        {
            base.Update();
            timecounter++;
            if (timecounter >= 300)
            {
                if (State.Inventory.Count == 0 && recurInvin != null)
                {
                    State.Inventory.Add(recurInvin);
                    ChangeState((int)Interfaces.BlockState.State.UNTAPPED);
                }
                timecounter = 0;
                ChangeState((int)Interfaces.BlockState.State.BUMPING);
                Velocity = new Vector2();
            }
        }
    }
}
