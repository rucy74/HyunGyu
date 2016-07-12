using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public abstract class Tile 
    {
    
        public virtual string Space { get; set; }
        protected int Row { get; set; }
        protected int Col { get; set; }
    }
    public class Wall : Tile
    {
        public Wall(int row, int col)
        {
            Row = row;
            Col = col;
            Space = "ㅁ";
        }        
        
    }

    public class Floor : Tile
    {
        public Floor(int row,int col)
        {
            Row = row;
            Col = col;
            Space = "  ";
        }       
    }
    public class Hole : Tile
    {        
        public Hole(int row,int col)
        {
            Row = row;
            Col = col;
            Space = "○";
        }        
    }
}
