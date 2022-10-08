using SprintZeroSpriteDrawing.Collision.MarioCollision;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Collision.CollisionManager
{
    public class MarioCollisionManager
    {
        public Mario mario { get; set; }
        public Block block { get; set; }
        public ICollideable enemy { get; set; }
        public ICollideable items { get; set; }

        Dictionary<Type, Dictionary<Direction, ICommand>> MarioCommand;
        public MarioCollisionManager(Mario Mario)
        {
            mario = Mario;
            MarioCommand = new Dictionary<Type, Dictionary<Direction, ICommand>>();
            MarioCommand.Add(typeof(Block), new Dictionary<Direction, ICommand>());


            MarioCommand[typeof(Block)].Add(Direction.TOP, new Mario_Block(Mario));
            MarioCommand[typeof(Block)].Add(Direction.RIGHT, new Mario_Block(Mario));
            MarioCommand[typeof(Block)].Add(Direction.LEFT, new Mario_Block(Mario));
            MarioCommand[typeof(Block)].Add(Direction.BOTTOM, new Mario_Block(Mario));
        }

        public void ManageBlockCollision(Block _block)
        {
            block = _block;
            Direction CollisionSide = CollisionDetector.getCD().DetectColDirection(mario, block);
            if (MarioCommand[typeof(Block)].ContainsKey(CollisionSide))
            {
                MarioCommand[typeof(Block)][CollisionSide].Execute();
            }
        }
    }
}
