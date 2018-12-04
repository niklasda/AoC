using System.Drawing;

namespace AoC.Day4.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public Point Position { get; set; }
        public Size Area { get; set; }
        public Rectangle Rect { get; set; } 
    }
}