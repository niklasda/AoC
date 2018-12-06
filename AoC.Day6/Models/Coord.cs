using System.Drawing;

namespace AoC.Day6.Models
{
    public class Coord
    {
        public Coord(int occupierId)
        {
            OwnerId = 0;
            OccupierId = occupierId;
        }

        public Coord(int ownerId, int occupierId)
        {
            OwnerId = ownerId;
            OccupierId = occupierId;
        }

        public int OwnerId { get; set; }
        public int OccupierId { get; set; }
    }
}