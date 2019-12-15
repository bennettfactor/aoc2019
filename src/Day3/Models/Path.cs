using System.Collections.Generic;

namespace Day3.Models
{
    public class Path
    {
        public Path(IEnumerable<Movement> moves)
        {
            Moves = moves;
        }

        public IEnumerable<Movement> Moves { get; }
    }
}
