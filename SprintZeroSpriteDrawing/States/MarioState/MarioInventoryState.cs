using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces.MarioState;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StateInventory;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.ItemSprites.EquippableItem;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using Bomb = SprintZeroSpriteDrawing.Sprites.ItemSprites.EquippableItem.Bomb;

namespace SprintZeroSpriteDrawing.States.MarioState
{
    public enum EquippableItems
    {
        SWORD,
        BOW,
        BOMB,
        HOOKSHOT
    }

    public class MarioInventoryState : IMarioState
    {
        public HashSet<Type> PlayerInventory { get; set; }
        public MarioInventoryState(Mario nMario) : base(nMario)
        {
        }
        public MarioInventoryState(Mario nMario, HashSet<Type> inventoryItems) : base(nMario)
        {
            PlayerInventory = inventoryItems;
        }
        public virtual void ItemAction()
        {
        }
        public void EquipItem(Item item)
        {
            PlayerInventory.Add(item.GetType());
        }
        public void SwitchToItem(int item)
        {
            switch ((EquippableItems)item)
            {
                case EquippableItems.SWORD:
                    if (PlayerInventory.Contains(typeof(Sword)))
                        mario.StateInventory = new EquippedSword(mario, PlayerInventory);
                    break;
                case EquippableItems.BOMB:
                    if (PlayerInventory.Contains(typeof(Bomb)))
                        mario.StateInventory = new EquippedBomb(mario, PlayerInventory);
                    break;
                case EquippableItems.BOW:
                    if (PlayerInventory.Contains(typeof(Bow)))
                        mario.StateInventory = new EquippedBow(mario, PlayerInventory);
                    break;
                case EquippableItems.HOOKSHOT:
                    if (PlayerInventory.Contains(typeof(Hookshot)))
                        mario.StateInventory = new EquippedHookshot(mario, PlayerInventory);
                    break;
            }
        }
    }
}
