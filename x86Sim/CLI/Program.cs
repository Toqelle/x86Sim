using System;
using x86;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            CPU CPU = new CPU();

            CPU.Registers.SaveRegisterValue(1, 0x01, 0x0001);

            CPU.Instructions.MOV(1, 1, 0x02, 0x01);
            Console.WriteLine(CPU.Registers.BX);




        }
    }
}
