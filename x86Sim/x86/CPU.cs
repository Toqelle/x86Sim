using System;

namespace x86
{
    public class CPU
    {
        public BusIU BusIU;
        public Registers Registers;
        public Instructions Instructions;

        public CPU()
        {
            BusIU = new BusIU();
            Registers = new Registers();
            Instructions = new Instructions(Registers, BusIU);
        }
    }
}
