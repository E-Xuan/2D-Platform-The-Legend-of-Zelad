using SprintZeroSpriteDrawing.Collision.BlockCollision;
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
    public class BlockCollisionManager
    {
        public Block block { get; set; }
        public Mario mario { get; set; }
        public BrickBlock BBlock { get; set; }
        public GroundBlock GBlock { get; set; }
        public QuestionBlock QBlocK { get; set; }
        public InvisibleBlock HBlock { get; set; }
        public UsedBlock UBlock { get; set; }
        public StairBlock SBlock { get; set; }  
        public BlockCollisionManager(Block _block)
        {
            block = _block;
            block.CollisionResponse.Add(CType.QBLOCK, new Dictionary<Direction, ICommand>());
            block.CollisionResponse.Add(CType.BBLOCK, new Dictionary<Direction, ICommand>());
            block.CollisionResponse.Add(CType.HBLOCK, new Dictionary<Direction, ICommand>());
            block.CollisionResponse.Add(CType.UBLOCK, new Dictionary<Direction, ICommand>());
            block.CollisionResponse.Add(CType.GBLOCK, new Dictionary<Direction, ICommand>());
            block.CollisionResponse.Add(CType.SBLOCK, new Dictionary<Direction, ICommand>());

            block.CollisionResponse[CType.QBLOCK].Add(Direction.TOP, new QuestionBlockCollision(this));
            block.CollisionResponse[CType.QBLOCK].Add(Direction.BOTTOM, new QuestionBlockCollision(this));
            block.CollisionResponse[CType.QBLOCK].Add(Direction.LEFT, new QuestionBlockCollision(this));
            block.CollisionResponse[CType.QBLOCK].Add(Direction.RIGHT, new QuestionBlockCollision(this));

            block.CollisionResponse[CType.BBLOCK].Add(Direction.TOP, new BrickBlockCollision(this));
            block.CollisionResponse[CType.BBLOCK].Add(Direction.BOTTOM, new BrickBlockCollision(this));
            block.CollisionResponse[CType.BBLOCK].Add(Direction.LEFT, new BrickBlockCollision(this));
            block.CollisionResponse[CType.BBLOCK].Add(Direction.RIGHT, new BrickBlockCollision(this));

            block.CollisionResponse[CType.HBLOCK].Add(Direction.TOP, new HiddenBlockCollision(this));
            block.CollisionResponse[CType.HBLOCK].Add(Direction.BOTTOM, new HiddenBlockCollision(this));
            block.CollisionResponse[CType.HBLOCK].Add(Direction.LEFT, new HiddenBlockCollision(this));
            block.CollisionResponse[CType.HBLOCK].Add(Direction.RIGHT, new HiddenBlockCollision(this));

            block.CollisionResponse[CType.UBLOCK].Add(Direction.TOP, new UsedBlockCollision(this));
            block.CollisionResponse[CType.UBLOCK].Add(Direction.BOTTOM, new UsedBlockCollision(this));
            block.CollisionResponse[CType.UBLOCK].Add(Direction.LEFT, new UsedBlockCollision(this));
            block.CollisionResponse[CType.UBLOCK].Add(Direction.RIGHT, new UsedBlockCollision(this));

            block.CollisionResponse[CType.GBLOCK].Add(Direction.TOP, new GroundBlockCollision(this));
            block.CollisionResponse[CType.GBLOCK].Add(Direction.BOTTOM, new GroundBlockCollision(this));
            block.CollisionResponse[CType.GBLOCK].Add(Direction.LEFT, new GroundBlockCollision(this));
            block.CollisionResponse[CType.GBLOCK].Add(Direction.RIGHT, new GroundBlockCollision(this));

            block.CollisionResponse[CType.SBLOCK].Add(Direction.TOP, new StairBlockCollision(this));
            block.CollisionResponse[CType.SBLOCK].Add(Direction.BOTTOM, new StairBlockCollision(this));
            block.CollisionResponse[CType.SBLOCK].Add(Direction.LEFT, new StairBlockCollision(this));
            block.CollisionResponse[CType.SBLOCK].Add(Direction.RIGHT, new StairBlockCollision(this));

        }
        public void ManageQBlockCollision(QuestionBlock _QBlock)
        {
            QBlocK = _QBlock;
            Direction CollisionSide = CollisionDetector.getCD().DetectColDirection(mario, QBlocK);
            if (block.CollisionResponse[CType.QBLOCK].ContainsKey(CollisionSide))
            {
                block.CollisionResponse[CType.QBLOCK][CollisionSide].Execute();
            }
        }
        public void ManageBBlockCollision(BrickBlock _BBlock)
        {
            BBlock = _BBlock;
            Direction CollisionSide = CollisionDetector.getCD().DetectColDirection(mario, BBlock);
            if (block.CollisionResponse[CType.BBLOCK].ContainsKey(CollisionSide))
            {
                block.CollisionResponse[CType.BBLOCK][CollisionSide].Execute();
            }
        }
        public void ManageHBlockCollision(InvisibleBlock _HBlock)
        {
            HBlock = _HBlock;
            Direction CollisionSide = CollisionDetector.getCD().DetectColDirection(mario, HBlock);
            if (block.CollisionResponse[CType.HBLOCK].ContainsKey(CollisionSide))
            {
                block.CollisionResponse[CType.HBLOCK][CollisionSide].Execute();
            }
        }
        public void ManageUBlockCollision(UsedBlock _UBlock)
        {
            UBlock = _UBlock;
            Direction CollisionSide = CollisionDetector.getCD().DetectColDirection(mario, UBlock);
            if (block.CollisionResponse[CType.UBLOCK].ContainsKey(CollisionSide))
            {
                block.CollisionResponse[CType.UBLOCK][CollisionSide].Execute();
            }
        }
        public void ManageGBlockCollision(GroundBlock _GBlock)
        {
            GBlock = _GBlock;
            Direction CollisionSide = CollisionDetector.getCD().DetectColDirection(mario, GBlock);
            if (block.CollisionResponse[CType.GBLOCK].ContainsKey(CollisionSide))
            {
                block.CollisionResponse[CType.GBLOCK][CollisionSide].Execute();
            }
        }
        public void ManageSBlockCollision(StairBlock _SBlock)
        {
            SBlock = _SBlock;
            Direction CollisionSide = CollisionDetector.getCD().DetectColDirection(mario, SBlock);
            if (block.CollisionResponse[CType.SBLOCK].ContainsKey(CollisionSide))
            {
                block.CollisionResponse[CType.SBLOCK][CollisionSide].Execute();
            }
        }
    }
}
