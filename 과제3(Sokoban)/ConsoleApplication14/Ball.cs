using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    
    public class Ball : Unit
    {
        public bool ballMovable;

        public Ball(int row, int col)
        {
            Row = row;
            Col = col;
            Space = "공";
        }
        public override void Move(Board board, ConsoleKeyInfo move)
        {
            if (MoveTrigger(board.player, this,move))
            {
                if (Blocked(board, move))
                {
                    ballMovable = false;
                    return;
                }
                foreach (Ball ball in board.balls)
                {
                    if (MoveTrigger(this, ball, move))
                    {
                        ballMovable = false;
                        return;
                    }
                    else continue;
                }
                ballMovable = true;
                base.Moving(move);                
            }
            else
            {                
                ballMovable = false;
                return;
            }
        }
        public void BallAtHole(Board board)
        {
            if (board.tiles[this.Row][this.Col].Space == "○")
                this.Space = "●";
            else this.Space = "공";            
        }
    }
}
