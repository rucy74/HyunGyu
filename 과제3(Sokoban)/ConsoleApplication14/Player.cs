using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Player : Unit
    {
        
        public Player(int row, int col)
        {
            Row = row;
            Col = col;
            Space = "ㅋ ";
        }

        public override void Move(Board board, ConsoleKeyInfo move)
        {
            if (Blocked(board, move)) return;
            foreach(Ball ball in board.balls)
            {
                if (MoveTrigger(this, ball, move)) 
                {
                    if (ball.ballMovable) break;
                    else return;
                }
                else continue;
            }
            Moving(move);
            return;
        }
    }
}
