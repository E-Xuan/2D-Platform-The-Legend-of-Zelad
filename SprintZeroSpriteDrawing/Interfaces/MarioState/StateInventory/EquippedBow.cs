using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.States.MarioState;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateInventory
{
    public class EquippedBow : MarioInventoryState
    {
        public EquippedBow(Mario nMario) : base(nMario)
        {
        }
        public EquippedBow(Mario nMario, HashSet<Type> inventoryItems) : base(nMario, inventoryItems)
        {
        }

        public override void ItemAction()
        {
            mario.ShootArrow(0);
        }
    }
}
