using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game1
{
    public class Board
    {
        ConsoleKeyInfo move;                        
        
        private List<List<string>> Maps = new List<List<string>>();        
        public List<List<Tile>> tiles = new List<List<Tile>>();
        public Player player = new Player(3, 3);
        public List<Ball> balls = new List<Ball>();
        
        public void Run() // Stage 숫자값 입력 받아 실행
        {
            int stageNum;
            while (true)
            {
                Console.Write("Insert a Number(1 ~ 89) : ");
                string tmpNum = Console.ReadLine();
                stageNum = Convert.ToInt32(tmpNum);
                if (stageNum < 90 && stageNum > 0) break;                    
            }
            this.StageStart(stageNum - 1);
            this.Draw();
            while (this.StageClear())
            {
                move = Console.ReadKey(false);

                if (move.Key == ConsoleKey.R) // R 누르면 재시작
                    this.StageRestart(move, stageNum);
                
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
        public Board() // 맵로딩만
        {
            this.MapLoading();            
        }
        
        public void StageStart(int stageNum) // 스테이지 입력 받아 저장
        {
            int i = -1, j;
            foreach (string line in Maps[stageNum])
            {
                i++; j = 0;
                tiles.Add(new List<Tile>());
                foreach (char c in line) // 주어진 맵에서 char별로 구분해서 저장
                {
                    switch (c)
                    {
                        case '#': tiles[i].Add(new Wall(i, j++)); break;
                        case ' ': tiles[i].Add(new Floor(i, j++)); break;
                        case '.': tiles[i].Add(new Hole(i, j++)); break;
                        case '$':
                            {
                                tiles[i].Add(new Floor(i, j));
                                balls.Add(new Ball(i, j++));
                                break;
                            }
                        case '@':
                            {
                                tiles[i].Add(new Floor(i, j));
                                player.Row = i; player.Col = j++;
                                break;
                            }                        
                    }                    
                }                
            }            
        }
        public void StageRestart(ConsoleKeyInfo move, int stageNum)
        {
            Console.Clear();
            tiles = new List<List<Tile>>();
            player = new Player(3, 3);
            balls = new List<Ball>();
            this.StageStart(stageNum - 1);
        }  
          
                 

        public void Draw() // 그리기
        {
            bool isUnit = true;
            foreach(List<Tile> tileLine in tiles)
            {
                foreach(Tile tile in tileLine)
                {                    
                    foreach (Ball ball in balls)
                    {
                        if (tile.Row == ball.Row && tile.Col == ball.Col)
                        {
                            Console.Write(ball.Space);
                            isUnit = false; // 공이 있으면 타일 그리지 않기
                            break;
                        }
                    }

                    if (tile.Row == player.Row && tile.Col == player.Col)
                    {
                        Console.Write(player.Space);
                        isUnit = false; // 플레이어                   
                    }
                    if (isUnit) Console.Write(tile.Space);
                    isUnit = true;
                }
                Console.WriteLine("");
            }           
        }        

        public bool StageClear()
        {
            
            foreach(Ball ball in balls)
            {
                ball.BallAtHole(this);
                if (ball.Space == "● ") continue;
                else return true;
            }
            return false;
        }

        public void MapLoading()
        {            
            Maps.Add(new List<string>());            
            int stageNum = 0;
            int i = 0;
            StreamReader Map = new StreamReader(@"aaa.txt");
            while (true)
            {
                Maps[stageNum].Add(Map.ReadLine());               
                if (Maps[stageNum][i] == "; " + (stageNum + 1))
                {
                    Maps.Add(new List<string>());
                    stageNum++; i = 0;
                }
                else i++;
                if (stageNum > 89) break;
            }
        }
       
    }
}
