using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication17
{
    class Program
    {
        static void Main(string[] args)
        {
            Hanoi hanoi = new Hanoi();
            hanoi.Run();
        }
    }
    public class Hanoi
    {
        private HanoiTower[] towers;
        public int NumOfDisks { get; private set; }
        public int Turns { get; private set; }

        public Hanoi() 
        {
            towers = new HanoiTower[3]; // HanoiTower 3개 assign
            Console.Write("Write a MaxDiskNumber : ");
            string numOfDisks = Console.ReadLine();
            this.NumOfDisks = Convert.ToInt32(numOfDisks); // Tower 높이 = disk 개수 입력받기
            towers[0] = new HanoiTower(NumOfDisks); towers[0].DiskCount = NumOfDisks; 
            towers[1] = new HanoiTower(NumOfDisks); towers[1].DiskCount = 0;
            towers[2] = new HanoiTower(NumOfDisks); towers[2].DiskCount = 0; // 각 tower assign
            for (int i = 0; i < NumOfDisks; i++)
            {
                towers[2].Disks[i] = 0; towers[1].Disks[i] = 0;
                towers[0].Disks[i] = NumOfDisks - i; // HanoiTower를 각각 NumOfDisks, 0, 0 으로 초기화
            }
            this.Turns = 0; // turns값 초기화
        }

        public void Run()
        {
            ExecuteTurn(NumOfDisks, towers[0], towers[1], towers[2]); // Turn 시행
            Console.Write("Turns : "); Console.WriteLine(Turns); // Turns값 결과값
        }
        public void ExecuteTurn(int n, HanoiTower source, HanoiTower via, HanoiTower dest)
        {
            if (n == 1)
            {
                dest.Disks[(dest.DiskCount++)] = source.RemoveAndInsertDisk(); // 1, 0, 0 => 0, 0, 1 이라는 이미지
                Draw(); Console.WriteLine(""); // Turns당 1회 그리기
                Turns++; 
            }
            else
            {
                ExecuteTurn(n - 1, source, dest, via); // 아무 생각없이 따라한 알고리즘
                ExecuteTurn(1, source, via, dest);
                ExecuteTurn(n - 1, via, source, dest);
                
            }

        }
        public void Draw()
        {
            for (int i = -1; i < NumOfDisks; i++) // i당 1줄
            {
                DrawDisk(towers[0], i); // 첫 번째 tower의 각 줄
                DrawDisk(towers[1], i);
                DrawDisk(towers[2], i);
                Console.WriteLine("");
            }
        }
        public void DrawDisk(HanoiTower tower, int i)
        {
            for (int j = -NumOfDisks; j <= NumOfDisks; j++)
            {
                if (i == -1)
                {
                    Console.Write(j == 0 ? "|" : " ");
                    continue;
                }
                if (j < 0) Console.Write((j + tower.Disks[NumOfDisks - i - 1] >= 0) ? "*" : " ");
                else if (j == 0) Console.Write("|");
                else Console.Write((j - tower.Disks[NumOfDisks - i - 1] <= 0) ? "*" : " ");
            }
            Console.Write("  ");
        }
    }
    public class HanoiTower
    {
        private readonly int maxDisks;
        public int[] Disks { get; private set; }
        public int DiskCount; // 현재 disk 개수

        public HanoiTower(int maxDisks)
        {
            this.maxDisks = maxDisks;
            Disks = new int[maxDisks]; // construct와 동시에 numOfDisk만큼 disk array assign
        }
        public int RemoveAndInsertDisk()
        {
            int value = Disks[DiskCount - 1];
            Disks[DiskCount - 1] = 0; DiskCount--; // 빼는 걸 함수 안에서 하고 그 값을 리턴
            return value;
        }
    }
}
