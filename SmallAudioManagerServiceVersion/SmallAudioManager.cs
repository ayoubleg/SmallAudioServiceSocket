using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using AudioSwitcher.AudioApi.CoreAudio;
using System.Runtime.InteropServices;

namespace SmallAudioManagerServiceVersion
{
    public class SmallAudioManager
    {
        public CoreAudioController controller = new CoreAudioController();
        public string output = "";

        int print_usage()
        {
            output += "usage : Client <Device_Name> <Action> <Action-Val>" + Environment.NewLine;
            output += "or Client <API-Action>" + Environment.NewLine;
            output += "--------------------------------------" + Environment.NewLine;
            output += "<Device_Name> ::= I/O Device Name" + Environment.NewLine;
            output += "<Action> ::= Mute, Toggle, +, -, plus, minus, +<val>, -<val> or <val>" + Environment.NewLine;
            output += "<val> ::= -100 to 100" + Environment.NewLine;
            output += "<Action-Val> ::= optional int (or bool for Mute)" + Environment.NewLine;
            output += "----                              ----" + Environment.NewLine;
            output += "<API-Action> ::= API-ListAll, API-ListInputs or API-ListOutputs" + Environment.NewLine;
            output += "Press a key to continue ..." + Environment.NewLine;
            return (-1);
        }

        int API_List(string Type)
        {
            IEnumerable<CoreAudioDevice> Target;
            if (Type.Equals("API-ListInputs"))
                Target = controller.GetPlaybackDevices();
            if (Type.Equals("API-ListOutputs"))
                Target = controller.GetCaptureDevices();
            else
                Target = controller.GetDevices();
            foreach (CoreAudioDevice device in Target)
            {
                output += "Name : " + device.Name + " Type : " + device.DeviceType.ToString() + Environment.NewLine;
            }
            return 0;
        }

        int ManageDevice(string[] args)
        {
            bool warning_flag = false;

            foreach (CoreAudioDevice device in controller.GetDevices())
            {
                if (device.Name.Equals(args[0]))
                {
                    if (warning_flag)
                    {
                        output += "Warning, multiple device with same name" + Environment.NewLine;
                        output += "Press a key to continue ..." + Environment.NewLine;
                    }
                    if (int.TryParse(args[1], out int tmp) && args.Length == 2)
                    {
                        int val;
                        if (int.TryParse(args[1], out val))
                            device.Volume += val;
                    }
                    else if (!args[1].Equals("Toggle", StringComparison.OrdinalIgnoreCase)
                                && !args[1].Equals("Mute", StringComparison.OrdinalIgnoreCase)
                                && args.Length < 3)
                        return print_usage();
                    else if (args[1].Equals("+") || args[1].Equals("plus", StringComparison.OrdinalIgnoreCase))
                    {
                        int val;
                        if (int.TryParse(args[2], out val))
                            device.Volume += val;
                    }
                    else if (args[1].Equals("-") || args[1].Equals("minus", StringComparison.OrdinalIgnoreCase))
                    {
                        int val;
                        if (int.TryParse(args[2], out val))
                            device.Volume -= val;
                    }
                    else if (args[1].Equals("Mute", StringComparison.OrdinalIgnoreCase))
                    {
                        bool val;
                        if (bool.TryParse(args[2], out val))
                            device.Mute(val);
                        else
                            device.ToggleMute();
                    }
                    else if (args[1].Equals("Toggle", StringComparison.OrdinalIgnoreCase))
                        device.ToggleMute();
                    else
                        return print_usage();
                    warning_flag = true;
                }
            }
            if (!warning_flag)
            {
                output += "Warning, device not found ! Please use an <API-Action> to list your devices" + Environment.NewLine;
                output += "Press a key to continue ..." + Environment.NewLine;
            }
            return 0;
        }

        public string Main(string[] args)
        {
            output = "";
            if (args.Length == 0)
                print_usage();
            else if (args[0].StartsWith("API"))
                API_List(args[0]);
            else if (args.Length > 1)
                ManageDevice(args);
            else
                print_usage();
            return output;
        }
    }
}
