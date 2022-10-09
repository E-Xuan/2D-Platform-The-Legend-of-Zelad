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
    {   /*NOT WORKING !!!!!!!!!!!!!!!!!!!!!!! IGNORE IT*/
        public ICollideable mario { get; set; }
        public ICollideable block { get; set; }
        public ICollideable enemy { get; set; }
        public ICollideable items { get; set; }
        public MarioCollisionManager(Mario Mario)
        {
            mario = Mario;
            mario.CollisionResponse.Add(CType.GROUND_BLOCK, new Dictionary<Direction, ICommand>());
            mario.CollisionResponse.Add(CType.QUESTION_BLOCK, new Dictionary<Direction, ICommand>());

            /*mario.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new Mario_Block(Mario), Direction.BOTTOM, CType.NEUTRAL));
            mario.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new Mario_Block(Mario), Direction.LEFT, CType.NEUTRAL));
            mario.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new Mario_Block(Mario), Direction.RIGHT, CType.NEUTRAL));*/

        }

        public void ManageBlockCollision(Block _block)
        {
            block = _block;
            Direction CollisionSide = CollisionDetector.getCD().DetectColDirection(mario, block);
            /*if (mario.CollisionResponse[CType.Neu].ContainsKey(CollisionSide))
            {
                MarioCommand[typeof(Block)][CollisionSide].Execute();
            }*/
        }
    }
}
