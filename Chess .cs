using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gobang
{
    class Chess
    {
        int x;
        int y;
        int player;
        public Chess(int x, int y, int player)
        {
            this.x = x;
            this.y = y;
            this.player = player;
        }
    }
}
