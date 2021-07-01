using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using x86;

namespace UIApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateRegisters();
        }

        CPU cpu = new CPU();
        private ushort DISP = 0x0000;
        private string console_output = "";

        private void UpdateRegisters()
        {
            AX_TextBox.Text = $"{cpu.Registers.AX:X4}";
            BX_TextBox.Text = $"{cpu.Registers.BX:X4}";
            CX_TextBox.Text = $"{cpu.Registers.CX:X4}";
            DX_TextBox.Text = $"{cpu.Registers.DX:X4}";
            SI_TextBox.Text = $"{cpu.Registers.SI:X4}";
            DI_TextBox.Text = $"{cpu.Registers.DI:X4}";
            BP_TextBox.Text = $"{cpu.Registers.BP:X4}";
            SP_TextBox.Text = $"{cpu.Registers.SP:X4}";
            DISP_TextBox.Text = $"{DISP:X4}";
        }

        private void RandomRegisters()
        {
            Random rand = new Random();
            cpu.Registers.AX = (ushort)rand.Next(0, 65535);
            cpu.Registers.BX = (ushort)rand.Next(0, 65535);
            cpu.Registers.CX = (ushort)rand.Next(0, 65535);
            cpu.Registers.DX = (ushort)rand.Next(0, 65535);
            cpu.Registers.SI = (ushort)rand.Next(0, 65535);
            cpu.Registers.DI = (ushort)rand.Next(0, 65535);
            cpu.Registers.BP = (ushort)rand.Next(0, 65535);
            cpu.Registers.SP = (ushort)rand.Next(0, 65535);
            DISP = (ushort)rand.Next(0, 65535);
        }




        private void Reg_AX_TextBox(object sender, TextChangedEventArgs e)
        {
            try
            {
                cpu.Registers.AX = Convert.ToUInt16(AX_TextBox.Text, 16);
                AX_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FF000000"));
            }
            catch
            {
                AX_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FFBF1363"));
            }
        }


        private void Reg_BX_TextBox(object sender, TextChangedEventArgs e)
        {
            try
            {
                cpu.Registers.BX = Convert.ToUInt16(BX_TextBox.Text, 16);
                BX_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FF000000"));
            }
            catch
            {
                BX_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FFBF1363"));
            }
        }

        private void Reg_CX_TextBox(object sender, TextChangedEventArgs e)
        {
            try
            {
                cpu.Registers.CX = Convert.ToUInt16(CX_TextBox.Text, 16);
                CX_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FF000000"));
            }
            catch
            {
                CX_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FFBF1363"));
            }
        }

        private void Reg_DX_TextBox(object sender, TextChangedEventArgs e)
        {
            try
            {
                cpu.Registers.DX = Convert.ToUInt16(DX_TextBox.Text, 16);
                DX_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FF000000"));
            }
            catch
            {
                DX_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FFBF1363"));
            }
        }



        private void Button_Random(object sender, RoutedEventArgs e)
        {
            RandomRegisters();
            UpdateRegisters();
            CWL("Random registers...");
        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            cpu.Registers.AX = 0x0000;
            cpu.Registers.BX = 0x0000;
            cpu.Registers.CX = 0x0000;
            cpu.Registers.DX = 0x0000;
            cpu.Registers.SI = 0x0000;
            cpu.Registers.DI = 0x0000;
            cpu.Registers.BP = 0x0000;
            cpu.Registers.SP = 0x0000;
            DISP = 0x0000;
            UpdateRegisters();
            CWL("Reset registers...");
        }

        private void Reg_SI_TextBox(object sender, TextChangedEventArgs e)
        {
            try
            {
                cpu.Registers.SI = Convert.ToUInt16(SI_TextBox.Text, 16);
                SI_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FF000000"));
            }
            catch
            {
                SI_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FFBF1363"));
            }
        }

        private void Reg_DI_TextBox(object sender, TextChangedEventArgs e)
        {
            try
            {
                cpu.Registers.DI = Convert.ToUInt16(DI_TextBox.Text, 16);
                DI_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FF000000"));
            }
            catch
            {
                DI_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FFBF1363"));
            }
        }

        private void Reg_BP_TextBox(object sender, TextChangedEventArgs e)
        {
            try
            {
                cpu.Registers.BP = Convert.ToUInt16(BP_TextBox.Text, 16);
                BP_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FF000000"));
            }
            catch
            {
                BP_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FFBF1363"));
            }
        }

        private void Reg_SP_TextBox(object sender, TextChangedEventArgs e)
        {
            try
            {
                cpu.Registers.SP = Convert.ToUInt16(SP_TextBox.Text, 16);
                SP_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FF000000"));
            }
            catch
            {
                SP_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FFBF1363"));
            }
        }

        private void Reg_DISP_TextBox(object sender, TextChangedEventArgs e)
        {
            try
            {
                DISP = Convert.ToUInt16(DISP_TextBox.Text, 16);
                DISP_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FF000000"));
            }
            catch
            {
                DISP_TextBox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#FFBF1363"));
            }
        }

        private void CWL(string text) //Console write line
        {
            console_output += $"{text} \n";
            ConsoleOutput_TextBlock.Text = console_output;
            ConsoleOutput_TextBlock.ScrollToEnd();
        }


        private void AssemblerCMD(string cmd)
        {
            cmd = cmd.Trim();
            CWL(cmd);
            string[] command = cmd.Split(' ');
            command[1] = command[1].TrimEnd(',');
            List<string> wordRegistersList1 = new List<string> { "AX", "BX", "CX", "DX", "SI", "DI", "BP", "SP" };
            List<string> wordRegistersList0 = new List<string> { "AH", "AL", "BH", "BL", "CH", "CL", "DH", "DL" };
            int? wordSize1;
            int? wordSize2;
            byte? firstRegCode = 0;
            byte? secoundRegCode = 0;

            if (wordRegistersList1.Contains(command[1]))
                wordSize1 = 1;
            else if (wordRegistersList0.Contains(command[1]))
                wordSize1 = 0;
            else
                wordSize1 = null;



            if (wordRegistersList1.Contains(command[2]))
                wordSize2 = 1;
            else if (wordRegistersList0.Contains(command[2]))
                wordSize2 = 0;
            else
                wordSize2 = null;



            if (wordSize1 == 1)
            {
                switch (command[1])
                {
                    case "AX":
                        firstRegCode = 0x00;
                        break;
                    case "BX":
                        firstRegCode = 0x01;
                        break;
                    case "CX":
                        firstRegCode = 0x02;
                        break;
                    case "DX":
                        firstRegCode = 0x03;
                        break;
                    case "SI":
                        firstRegCode = 0x04;
                        break;
                    case "DI":
                        firstRegCode = 0x05;
                        break;
                    case "BP":
                        firstRegCode = 0x06;
                        break;
                    case "SP":
                        firstRegCode = 0x07;
                        break;
                    default:
                        firstRegCode = null;
                        break;

                }
            }

            if (wordSize1 == 0)
            {
                switch (command[1])
                {
                    case "AL":
                        firstRegCode = 0x00;
                        break;
                    case "BL":
                        firstRegCode = 0x01;
                        break;
                    case "CL":
                        firstRegCode = 0x02;
                        break;
                    case "DL":
                        firstRegCode = 0x03;
                        break;
                    case "AH":
                        firstRegCode = 0x04;
                        break;
                    case "BH":
                        firstRegCode = 0x05;
                        break;
                    case "CH":
                        firstRegCode = 0x06;
                        break;
                    case "DH":
                        firstRegCode = 0x07;
                        break;
                    default:
                        firstRegCode = null;
                        break;

                }
            }

            if (wordSize2 == 1)
            {
                switch (command[2])
                {
                    case "AX":
                        secoundRegCode = 0x00;
                        break;
                    case "BX":
                        secoundRegCode = 0x01;
                        break;
                    case "CX":
                        secoundRegCode = 0x02;
                        break;
                    case "DX":
                        secoundRegCode = 0x03;
                        break;
                    case "SI":
                        secoundRegCode = 0x04;
                        break;
                    case "DI":
                        secoundRegCode = 0x05;
                        break;
                    case "BP":
                        secoundRegCode = 0x06;
                        break;
                    case "SP":
                        secoundRegCode = 0x07;
                        break;
                    default:
                        secoundRegCode = null;
                        break;
                }
            }
            if (wordSize2 == 0)
            {
                switch (command[2])
                {
                    case "AL":
                        secoundRegCode = 0x00;
                        break;
                    case "BL":
                        secoundRegCode = 0x01;
                        break;
                    case "CL":
                        secoundRegCode = 0x02;
                        break;
                    case "DL":
                        secoundRegCode = 0x03;
                        break;
                    case "AH":
                        secoundRegCode = 0x04;
                        break;
                    case "BH":
                        secoundRegCode = 0x05;
                        break;
                    case "CH":
                        secoundRegCode = 0x06;
                        break;
                    case "DH":
                        secoundRegCode = 0x07;
                        break;
                    default:
                        secoundRegCode = null;
                        break;

                }
            }

            int EnumAddress(string cmdString)
            {
                int address = 0;
                List<string> wordRegistersList = new List<string> { "AX", "BX", "CX", "DX", "SI", "DI", "BP", "SP", "DISP" };
                List<string> byteRegistersList = new List<string> { "AH", "AL", "BH", "BL", "CH", "CL", "DH", "DL" };
                Regex hexReg = new Regex("[a-fA-F0-9]{4}");
                //Direct addressing
                if (cmdString[0] == '[' && cmdString[cmdString.Length - 1] == ']')
                {

                    cmdString = cmdString.TrimStart('[').TrimEnd(']');
                    string[] temp = cmdString.Split('+');

                    foreach (var el in temp)
                    {
                        if (hexReg.IsMatch(el))
                        {
                            address += Convert.ToUInt16(el, 16);
                        }
                        //
                        if (wordRegistersList.Contains(el))
                        {
                            switch (el)
                            {
                                case "AX":
                                    address += cpu.Registers.GetRegisterValue(1, 0x00);
                                    break;
                                case "BX":
                                    address += cpu.Registers.GetRegisterValue(1, 0x01);
                                    break;
                                case "CX":
                                    address += cpu.Registers.GetRegisterValue(1, 0x02);
                                    break;
                                case "DX":
                                    address += cpu.Registers.GetRegisterValue(1, 0x03);
                                    break;
                                case "SI":
                                    address += cpu.Registers.GetRegisterValue(1, 0x04);
                                    break;
                                case "DI":
                                    address += cpu.Registers.GetRegisterValue(1, 0x05);
                                    break;
                                case "BP":
                                    address += cpu.Registers.GetRegisterValue(1, 0x06);
                                    break;
                                case "SP":
                                    address += cpu.Registers.GetRegisterValue(1, 0x07);
                                    break;
                                case "DISP":
                                    address += DISP;
                                    break;
                                default:
                                    break;

                            }
                        }
                        //
                        if (byteRegistersList.Contains(el))
                        {
                            switch (el)
                            {
                                case "AL":
                                    address += cpu.Registers.GetRegisterValue(0, 0x00);
                                    break;
                                case "BL":
                                    address += cpu.Registers.GetRegisterValue(0, 0x01);
                                    break;
                                case "CL":
                                    address += cpu.Registers.GetRegisterValue(0, 0x02);
                                    break;
                                case "DL":
                                    address += cpu.Registers.GetRegisterValue(0, 0x03);
                                    break;
                                case "AH":
                                    address += cpu.Registers.GetRegisterValue(0, 0x04);
                                    break;
                                case "BH":
                                    address += cpu.Registers.GetRegisterValue(0, 0x05);
                                    break;
                                case "CH":
                                    address += cpu.Registers.GetRegisterValue(0, 0x06);
                                    break;
                                case "DH":
                                    address += cpu.Registers.GetRegisterValue(0, 0x07);
                                    break;
                                default:
                                    break;

                            }
                        }

                    }


                }
                return address;
            }

            switch (command[0])
            {
                case "MOV":
                    {
                        /*if(wordSize1 != null && wordSize2 == null && command[2][0] == '[')
                        {
                            command[2] = command[2].TrimStart('[').TrimEnd(']');
                            string[] addr = command[2].Split('+');
                            foreach(var el in addr)
                            {
                                CWL($"{el}");
                            }
                            return;
                        }*/
                        //Register to register
                        if (wordSize1 != null && wordSize2 != null)
                        {
                            CWL("[MOV] > Register's value to register");
                            cpu.Instructions.MOV((int)wordSize1, (int)wordSize2, (byte)firstRegCode, (byte)secoundRegCode);
                            UpdateRegisters();
                            return;
                        }
                        //Address's value to register
                        if (wordSize1 != null && wordSize2 == null && command[2][0] == '[')
                        {
                            CWL("[MOV] > Address's value to register");
                            cpu.Instructions.MOV((int)wordSize1, (byte)firstRegCode, cpu.BusIU.GetWord(EnumAddress(command[2])));
                            UpdateRegisters();
                            return;
                        }
                        //Register's value to adress
                        if (wordSize1 == null && command[1][0] == '[' && wordSize2 != null)
                        {
                            CWL("[MOV] > Register's value to adress");
                            cpu.Instructions.MOV(EnumAddress(command[1]), cpu.Registers.GetRegisterValue((int)wordSize2, (byte)secoundRegCode));
                            UpdateRegisters();
                            return;
                        }
                        //Value to address's register's value
                        if (wordSize1 == null && command[1][0] == '[' && wordSize2 == null)
                        {
                            CWL("[MOV] > Value to address's register's value");
                            ushort value = Convert.ToUInt16(command[2], 16);
                            cpu.Instructions.MOV(EnumAddress(command[1]), value);
                            UpdateRegisters();
                            return;
                        }
                        //Address's value to adress
                        if (wordSize1 == null && command[1][0] == '[' && wordSize2 == null && command[2][0] == '[')
                        {
                            CWL("[MOV] > Address's value to adress");
                            ushort value = cpu.BusIU.GetWord(EnumAddress(command[2]));
                            cpu.Instructions.MOV(EnumAddress(command[1]), value);
                            UpdateRegisters();
                            return;
                        }
                        //Value to register
                        if (wordSize1 != null & wordSize2 == null)
                        {
                            try
                            {
                                ushort value = Convert.ToUInt16(command[2], 16);
                                cpu.Instructions.MOV((int)wordSize1, (byte)firstRegCode, value);
                                CWL("[MOV] > Value to register");
                                UpdateRegisters();
                            }
                            catch
                            {
                                CWL("!!! Invalid value !!!");
                            }
                            return;
                        }

                        break;
                    }
                case "XCHG":
                    {
                        //Register to register
                        if (wordSize1 != null && wordSize2 != null)
                        {
                            CWL("[XCHG] > Register's value to register");
                            cpu.Instructions.XCHG((int)wordSize1, (int)wordSize2, (byte)firstRegCode, (byte)secoundRegCode);
                            UpdateRegisters();
                            return;
                        }

                        //Address's value to register
                        if (wordSize1 != null && wordSize2 == null && command[2][0] == '[')
                        {
                            CWL("[XCHG] > Address's value to register");
                            cpu.Instructions.XCHG((int)wordSize1, (byte)firstRegCode, EnumAddress(command[2]));
                            UpdateRegisters();
                            return;
                        }

                        //Register value to adress
                        if (wordSize2 != null && wordSize1 == null && command[1][0] == '[')
                        {
                            CWL("[XCHG] > Address's value to register");
                            cpu.Instructions.XCHG((int)wordSize2, (byte)secoundRegCode, EnumAddress(command[1]));
                            UpdateRegisters();
                            return;
                        }
                        //Address's value to adress
                        if (wordSize1 == null && command[1][0] == '[' && wordSize2 == null && command[2][0] == '[')
                        {
                            CWL("[XCHG] > Address's value to adress");
                            ushort value = cpu.BusIU.GetWord(EnumAddress(command[2]));
                            cpu.Instructions.MOV(EnumAddress(command[1]), value);
                            UpdateRegisters();
                            return;
                        }

                        break;
                    }
            }



        }

        private void Button_Run(object sender, RoutedEventArgs e)
        {
            AssemblerCMD(CMD_TextBox.Text.ToUpper());
        }


    }
}
