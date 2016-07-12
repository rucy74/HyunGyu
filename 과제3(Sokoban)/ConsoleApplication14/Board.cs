using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Board
    {
        ConsoleKeyInfo move;
        public const int len = 10;
        public const int num = 4;
        private bool isUnit;                

        Random random = new Random();
        public Tile[][] tiles = new Tile[len][];
        public Player player = new Player(3, 3);
        public List<Ball> balls = new List<Ball>();
        
        public void Run()
        {
            this.Draw();
            while (this.StageClear())
            {
                move = Console.ReadKey(false);
                foreach (Ball ball in balls)
                {
                    ball.Move(this, move);
                    ball.BallAtHole(this);
                }
                player.Move(this, move);
                
                Console.Clear();
                this.Draw();
            }
            Console.WriteLine("==========Stage Clear!!!==========");
        }
        public Board() // 보드 만들기
        {
            for (int i = 0; i < len; i++) // 타일 만들기
            {
                tiles[i] = new Tile[len];
                for (int j = 0; j < len; j++)
                {
                    if (i == 0 || i == len - 1 || j == 0 || j == len - 1)
                        tiles[i][j] = new Wall(i, j);
                    else if ((i == 4 || i == 5) && (j == 4 || j == 5)) tiles[i][j] = new Hole(i, j);
                    else tiles[i][j] = new Floor(i, j);
                }
            }
            for (int i = 0; i < num; i++)
            {                
                balls.Add(new Ball(i + 2, random.Next(2, 5))); // 유닛 만들기
            }
        }           
                 

        public void Draw()
        {
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    isUnit = true;                   
                    for (int k = 0; k < num + 1; k++) 
                    {
                        if (k != num)
                        {
                            if (balls[k].Row == i && balls[k].Col == j)
                            {                                 
                                Console.Write(balls[k].Space);
                                isUnit = false;
                            }
                        }
                        else if (player.Row == i && player.Col == j)
                        {
                            Console.Write(player.Space);
                            isUnit = false;
                        }
                        else continue;
                    }
                    if (isUnit) Console.Write(tiles[i][j].Space);
                }                
                Console.WriteLine("");                
            }
        }

        public bool StageClear()
        {
            
            for (int i = 0; i < num; i++)
            {
                balls[i].BallAtHole(this);
                if (balls[i].Space == "●") continue;
                else return true;
            }
            return false;
        }
       
    }
}
