﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.States.MarioState;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateInventory
{
    public class EquippedBomb : MarioInventoryState
    {
        public EquippedBomb(Mario nMario) : base(nMario)
        {
        }
        public EquippedBomb(Mario nMario, HashSet<Type> inventoryItems) : base(nMario, inventoryItems)
        {
        }
        public override void ItemAction()
        {
            mario.PlaceBomb(0);
        }
    }
}
