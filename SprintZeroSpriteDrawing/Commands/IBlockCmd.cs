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
            ((InvisibleBlock)Ref).IsVis = true;
        }

    }
}
