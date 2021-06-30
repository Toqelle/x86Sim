using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace x86
{
    /// <summary>
    /// Bus interface unit
    /// </summary>
    public enum SegmentOverrideState
    {
        UseCS,
        UseDS,
        UseSS,
        UseES,
        NoOverride
    };
    public class BusIU
    {
        public const int MAX_MEMORY = 0x100000;

        /// <summary>
        /// Segment registers
        /// </summary>

        ushort CS { get; set; }  // code segment
        ushort DS { get; set; }  // data segment
        ushort SS { get; set; }  // stack segment
        ushort ES { get; set; }  // extra segmemt

        /*The Segment Override Prefix says that if we want to use some other segment register than the default segment for a particular code, then it is possible.It can simply be one by mentioning the segment that is to be used before the address location or the offset register containing that address.By doing so, the machine, i.e.the 8086 microprocessor, while calculating the effective address will consider the mentioned segment for calculating the effective address rather than opting for the default one.*/
        SegmentOverrideState SegmentOverride { get; set; }
        public bool UsingBasePointer { get; set; }
        /// <summary>
        /// Program counter
        /// </summary>
        ushort IP { get; set; }  // instruction pointer

        private RAM Ram;

        public BusIU()
        {
            CS = 0xffff;
            DS = 0x0000;
            SS = 0x0000;
            ES = 0x0000;
            IP = 0x0000;
            SegmentOverride = SegmentOverrideState.NoOverride;
            UsingBasePointer = false;

            Ram = new RAM(MAX_MEMORY);  // 1,048,576 bytes (maximum addressable by the 8086)
        }

        private ushort GetDataSegment()
        {
            if (SegmentOverride == SegmentOverrideState.NoOverride)
            {
                if (UsingBasePointer)
                    return SS;
                else
                    return DS;
            }
            else if (SegmentOverride == SegmentOverrideState.UseCS)
                return CS;
            else if (SegmentOverride == SegmentOverrideState.UseES)
                return ES;
            else if (SegmentOverride == SegmentOverrideState.UseSS)
                return SS;
            else
                return DS;
        }

        // fetch the 8 bit value at the requested offset
        public byte GetByte(int offset)
        {
            int addr = (GetDataSegment() << 4) + offset;
            if (addr >= MAX_MEMORY)
            {
                throw new InvalidOperationException(String.Format("Memory bounds exceeded. DS={0:X4} offset={1:X4}", DS, offset));
            }
            return Ram[addr];
        }

        // save the 8 bit value to the requested offset
        public void SaveByte(int offset, byte value)
        {
            int addr = (GetDataSegment() << 4) + offset;
            if (addr >= MAX_MEMORY)
            {
                throw new InvalidOperationException(String.Format("Memory bounds exceeded. DS={0:X4} offset={1:X4}", DS, offset));
            }
            Ram[addr] = value;
        }

        // fetch the 16 bit value at the requested offset
        public ushort GetWord(int offset)
        {
            int addr = (GetDataSegment() << 4) + offset;
            if (addr >= MAX_MEMORY)
            {
                throw new InvalidOperationException(String.Format("Memory bounds exceeded. DS={0:X4} offset={1:X4}", DS, offset));
            }
            return new WordRegister(Ram[addr + 1], Ram[addr]);
        }

        // fetch the 16 bit value at the requested offset while forcing a segment address
        public ushort GetWord(int segment, int offset)
        {
            int addr = (segment << 4) + offset;
            if (addr >= MAX_MEMORY)
            {
                throw new InvalidOperationException(String.Format("Memory bounds exceeded. DS={0:X4} offset={1:X4}", DS, offset));
            }
            return new WordRegister(Ram[addr + 1], Ram[addr]);
        }

        // save the 16 bit value to the requested offset
        public void SaveWord(int offset, ushort value)
        {
            int addr = (GetDataSegment() << 4) + offset;
            if (addr >= MAX_MEMORY)
            {
                throw new InvalidOperationException(String.Format("Memory bounds exceeded. DS={0:X4} offset={1:X4}", DS, offset));
            }
            WordRegister data = new WordRegister(value);
            Ram[addr + 1] = data.HI;
            Ram[addr] = data.LO;
        }

        
        /// <summary>
        /// To-do SaveWord with segment only
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>

        public ushort PopStack(int offset)
        {
            int addr = (SS << 4) + offset;
            if (addr >= MAX_MEMORY)
            {
                throw new InvalidOperationException(String.Format("Memory bounds exceeded. SS={0:X4} offset={1:X4}", SS, offset));
            }

            return new WordRegister(Ram[addr + 1], Ram[addr]);
        }

        public void PushStack(int offset, ushort value)
        {
            int addr = (SS << 4) + offset;
            if (addr >= MAX_MEMORY)
            {
                throw new InvalidOperationException(String.Format("Memory bounds exceeded. SS={0:X4} offset={1:X4}", SS, offset));
            }

            WordRegister reg = new WordRegister(value);
            Ram[addr + 1] = reg.HI;
            Ram[addr] = reg.LO;
        }

    }    
}
