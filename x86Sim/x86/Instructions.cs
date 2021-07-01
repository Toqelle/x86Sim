using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace x86
{
    public class Instructions
    {
        readonly Registers Registers;
        readonly BusIU BusIU;

        public Instructions(Registers registers, BusIU bus)
        {
            Registers = registers;
            BusIU = bus;
        }

        public void Push(ushort value)
        {
            Registers.SP -= 2;
            BusIU.PushStack(Registers.SP, value);
        }

        public ushort Pop()
        {
            ushort result = BusIU.PopStack(Registers.SP);
            Registers.SP += 2;
            return result;
        }

        public void MOV(int wordSize1, int wordSize2,  byte reg1, byte reg2) //Register to register
        {
            Registers.SaveRegisterValue(wordSize1, reg1, Registers.GetRegisterValue(wordSize2, reg2));
        }

        public void MOV(int wordSize1, byte reg1, ushort value)
        {
            Registers.SaveRegisterValue(wordSize1, reg1, value);
        }

        public void MOV(int offset = 0, int value = 0)
        {
            BusIU.SaveWord(offset, (ushort)value);
        }

        public void XCHG(int wordSize1, int wordSize2, byte reg1, byte reg2) //Register to register
        {
            var temp = Registers.GetRegisterValue(wordSize1, reg1);
            Registers.SaveRegisterValue(wordSize1, reg1, Registers.GetRegisterValue(wordSize2, reg2));
            Registers.SaveRegisterValue(wordSize2, reg2, temp);
        }

        public void XCHG(int wordSize1, byte reg1, int offset)
        {
            var value = BusIU.GetWord(offset);
            BusIU.SaveWord(offset, (ushort)Registers.GetRegisterValue(wordSize1, reg1));
            Registers.SaveRegisterValue(wordSize1, reg1, value);
        }





    }
}
