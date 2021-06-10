using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace x86
{
    public class Registers
    {
        /*
         Byte Addressable Memory / data space in the cell = 8 bits
         Word Addressable Memory / data space in the cell = word length of CPU (intel 8086 has 16 bits wide data buses)
         */

        /// <summary>
        /// Main registers
        /// </summary>

        private WordRegister ax = new WordRegister();
        private WordRegister bx = new WordRegister();
        private WordRegister cx = new WordRegister();
        private WordRegister dx = new WordRegister();

        //AX (primary accumulator) 
        public ushort AX { get => ax.Value; set => ax.Value = value; } // 0x00
        //BX (base, accumulator)  
        public ushort BX { get => bx.Value; set => bx.Value = value; } // 0x01
        //CX (counter, accumulator)  
        public ushort CX { get => cx.Value; set => cx.Value = value; } // 0x02
        //DX (accumulator, extended acc.)
        public ushort DX { get => dx.Value; set => dx.Value = value; } // 0x03

        /// <summary>
        /// Index registers
        /// </summary>

        public ushort SI { get; set; } //source index | 0x04
        public ushort DI { get; set; } //destination index | 0x05
        public ushort BP { get; set; } //base pointer | 0x06
        public ushort SP { get; set; } //stack pointer | 0x07


        public Registers()
        {
            SI = 0;
            DI = 0;
            BP = 0;
            SP = 0;
        }


        public byte AH { get => ax.HI; set => ax.HI = value; } // 0x04
        public byte AL { get => ax.LO; set => ax.LO = value; } // 0x00
        public byte BH { get => bx.HI; set => bx.HI = value; } // 0x05
        public byte BL { get => bx.LO; set => bx.LO = value; } // 0x01
        public byte CH { get => cx.HI; set => cx.HI = value; } // 0x06
        public byte CL { get => cx.LO; set => cx.LO = value; } // 0x02
        public byte DH { get => dx.HI; set => dx.HI = value; } // 0x07
        public byte DL { get => dx.LO; set => dx.LO = value; } // 0x03


        public int GetRegisterValue(int wordSize, byte reg)
        {
            if (wordSize == 0)
            {
                return GetByteFromRegisters(reg);
            }
            else
            {
                return GetWordFromRegisters(reg);
            }
        }

        public void SaveRegisterValue(int wordSize, byte reg, int value)
        {
            if (wordSize == 0)
            {
                SaveByteToRegisters(reg, (byte)(value & 0xff));
            }
            else
            {
                SaveWordToRegisters(reg, (ushort)(value & 0xffff));
            }
        }

        // Get 8 bit REG result (or R/M mod=11)
        private byte GetByteFromRegisters(byte reg)
        {
            byte result = 0;
            switch (reg)
            {
                case 0x00:
                    {
                        result = AL;
                        break;
                    }
                case 0x01:
                    {
                        result = BL;
                        break;
                    }
                case 0x02:
                    {
                        result = CL;
                        break;
                    }
                case 0x03:
                    {
                        result = DL;
                        break;
                    }
                case 0x04:
                    {
                        result = AH;
                        break;
                    }
                case 0x05:
                    {
                        result = BH;
                        break;
                    }
                case 0x06:
                    {
                        result = CH;
                        break;
                    }
                case 0x07:
                    {
                        result = DH;
                        break;
                    }
            }
            return result;
        }

        // Get 16 bit REG result (or R/M mod=11)
        private ushort GetWordFromRegisters(byte reg)
        {
            ushort result = 0;
            switch (reg)
            {
                case 0x00:
                    {
                        result = AX;
                        break;
                    }
                case 0x01:
                    {
                        result = BX;
                        break;
                    }
                case 0x02:
                    {
                        result = CX;
                        break;
                    }
                case 0x03:
                    {
                        result = DX;
                        break;
                    }
                case 0x04:
                    {
                        result = SI;
                        break;
                    }
                case 0x05:
                    {
                        result = DI;
                        break;
                    }
                case 0x06:
                    {
                        result = BP;
                        break;
                    }
                case 0x07:
                    {
                        result = SP;
                        break;
                    }
            }
            return result;
        }

        // Save 8 bit value in register indicated by REG
        private void SaveByteToRegisters(byte reg, byte value)
        {
            switch (reg)
            {
                case 0x00:
                    {
                        AL = value;
                        break;
                    }
                case 0x01:
                    {
                        BL = value;
                        break;
                    }
                case 0x02:
                    {
                        CL = value;
                        break;
                    }
                case 0x03:
                    {
                        DL = value;
                        break;
                    }
                case 0x04:
                    {
                        AH = value;
                        break;
                    }
                case 0x05:
                    {
                        BH = value;
                        break;
                    }
                case 0x06:
                    {
                        CH = value;
                        break;
                    }
                case 0x07:
                    {
                        DH = value;
                        break;
                    }
            }

        }

        // Save 16 bit value in register indicated by REG
        private void SaveWordToRegisters(byte reg, ushort value)
        {
            switch (reg)
            {
                case 0x00:
                    {
                        AX = value;
                        break;
                    }
                case 0x01:
                    {
                        BX = value;
                        break;
                    }
                case 0x02:
                    {
                        CX = value;
                        break;
                    }
                case 0x03:
                    {
                        DX = value;
                        break;
                    }
                case 0x04:
                    {
                        SI = value;
                        break;
                    }
                case 0x05:
                    {
                        DI = value;
                        break;
                    }
                case 0x06:
                    {
                        BP = value;
                        break;
                    }
                case 0x07:
                    {
                        SP = value;
                        break;
                    }
            }
        }

    }
}
