using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.ItemSprites.EquippableItem;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.States.MarioState;
using Bomb = SprintZeroSpriteDrawing.Sprites.ItemSprites.EquippableItem.Bomb;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateInventory
{
    public class EquippedEmpty : MarioInventoryState
    {
        public EquippedEmpty(Mario nMario) : base(nMario)
        {
            PlayerInventory = new HashSet<Type>(){typeof(Bomb), typeof(Sword), typeof(Bow), typeof(Hookshot)};
        }
        public EquippedEmpty(Mario nMario, HashSet<Type> inventoryItems) : base(nMario, inventoryItems)
        {
        }

    }
}
