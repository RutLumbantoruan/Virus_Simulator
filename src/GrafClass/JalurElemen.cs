using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_VirusSimulation.src.GrafClass
{
    class JalurElemen
    {
        public char jalur;
        public double peluang;
        public JalurElemen(char jalur, double peluang)
        {
            this.jalur = jalur;
            this.peluang = peluang;
        }
    }
}
