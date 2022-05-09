///
/// code generator:
/// amd32 is an instruction builder
/// data of instructions are seperate structs
/// eventually will be interface
///

// remove this line

namespace sharp
{
    public class Amd32
    {
        public enum Reg8
        {
            AH,
            AL,
            BH,
            BL,
            CH,
            CL,
            DH,
            DL
        }

        public enum Reg16
        {
            AX,
            BX,
            CX,
            DX
        }

        public enum Reg32
        {
            EAX,
            EBX,
            ECX,
            EDX
        }

        public static byte[] BuildRet()
        {
            return new byte[] { 0xC3 };
        }

        public static byte[] BuildMov(Reg8 reg, byte value)
        {
            byte regOp;
            switch (reg)
            {
                case Reg8.AH:
                    regOp = 0xB4;
                    break;
                case Reg8.AL:
                    regOp = 0xB0;
                    break;
                case Reg8.BH:
                    regOp = 0xB7;
                    break;
                case Reg8.BL:
                    regOp = 0xB3;
                    break;
                case Reg8.CH:
                    regOp = 0xB5;
                    break;
                case Reg8.CL:
                    regOp = 0xB1;
                    break;
                case Reg8.DH:
                    regOp = 0xB6;
                    break;
                case Reg8.DL:
                    regOp = 0xB2;
                    break;
            }

            return new byte[] { opcode, byte };
        }

        public static byte[] BuildMov(Reg16 reg, byte value1, byte value2)
        {
            byte op = 0x66;
            byte regOp;
            switch (reg)
            {
                case Reg16.AX:
                    opcode = 0xB8;
                    break;
                case Reg16.BX:
                    opcode = 0xBB;
                    break;
                case Reg16.CX:
                    opcode = 0xB9;
                    break;
                case Reg16.DX:
                    opcode = 0xBA;
                    break;
            }

            return new byte[] { opcode, regOp, value1, value2 };
        }

        public static byte[] BuildMov(Reg32 reg, byte value1, byte value2, byte value3, byte value4)
        {
            byte regOp;
            switch (reg)
            {
                case Reg32.EAX:
                    opcode = 0xB8;
                    break;
                case Reg32.EBX:
                    opcode = 0xBB;
                    break;
                case Reg32.ECX:
                    opcode = 0xB9;
                    break;
                case Reg32.EDX:
                    opcode = 0xBA;
                    break;
            }

            return new byte[] { regOp, value1, value2, value3, value4 };
        }
    }
}
