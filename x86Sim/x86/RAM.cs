using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace x86
{
    /// <summary>
    /// Random-access memory
    /// </summary>
    class RAM
    {
        private int MaxMemory;
        private byte[] ram;

        public RAM(int max)
        {
            MaxMemory = max;
            ram = new byte[max];
        }
        public byte this[int i]
        {
            get { return ram[i]; }
            set { ram[i] = value; }
        }
    }
}
