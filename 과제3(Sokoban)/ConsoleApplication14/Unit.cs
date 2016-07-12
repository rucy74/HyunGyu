using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public abstract class Unit
    {
        
        public string Space { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public virtual void Move(Board board, ConsoleKeyInfo move) { }
        public bool Blocked(Board board, ConsoleKeyInfo move)
        {
            if (((board.tiles[this.Row - 1][this.Col].Space == "ㅁ") && move.Key == ConsoleKey.UpArrow) // 벽에 막히게 하기
              || ((board.tiles[this.Row + 1][this.Col].Space == "ㅁ") && move.Key == ConsoleKey.DownArrow)
              || ((board.tiles[this.Row][this.Col - 1].Space == "ㅁ") && move.Key == ConsoleKey.LeftArrow)
              || ((board.tiles[this.Row][this.Col + 1].Space == "ㅁ") && move.Key == ConsoleKey.RightArrow))
                return true;
            else return false;
        }
        public void Moving(ConsoleKeyInfo move)
        {           
                switch (move.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            Col--; break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            Col++; break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            Row--; break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            Row++; break;
                        }
                    default: break;
                }            
        }        
        protected bool MoveTrigger(Unit unit1, Unit unit2, ConsoleKeyInfo move)
        {
            if (((unit1.Row - 1 == unit2.Row && unit1.Col == unit2.Col) && move.Key == ConsoleKey.UpArrow) ||
               ((unit1.Row + 1 == unit2.Row && unit1.Col == unit2.Col) && move.Key == ConsoleKey.DownArrow) ||
               ((unit1.Row == unit2.Row && unit1.Col - 1 == unit2.Col) && move.Key == ConsoleKey.LeftArrow) ||
               ((unit1.Row == unit2.Row && unit1.Col + 1 == unit2.Col) && move.Key == ConsoleKey.RightArrow))
                return true;
            else return false;            
        }         
    }   
}
