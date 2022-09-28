using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;

namespace SprintZeroSpriteDrawing.Commands
{
    internal class IBlockCmd : ICommand
    {
        public IBlockCmd(InvisibleBlock nRef) : base(nRef) { }

        public override void Execute()
        {
            ((InvisibleBlock)Ref).SetVis(1);
            for(int i = 0; i < 10; i++)
            {
                if(i < 5)
                    ((InvisibleBlock)Ref).MoveY(5);
                else
                    ((InvisibleBlock)Ref).MoveY(-5);
            }
        }

    }
}
