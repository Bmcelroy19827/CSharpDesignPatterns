using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand
{
    public static class HMenuPicker
    {
        /// <summary>
        /// Function for a keyboard navigated menu
        /// </summary>
        /// <param name="options"></param>
        /// <param name="greetings"></param>
        /// <param name="instruction"></param>
        /// <returns>string with the selected option</returns>
        public static string MenuPicker(string[] options,string greetings,string instruction)
        {
            int itemNo = 0;
            string seperator;
            string command = string.Empty;

            ConsoleKeyInfo key_pressed;
            do
            {
                Console.Clear();
                HConsole.StarRow();
                Console.WriteLine(greetings);
                Console.WriteLine(instruction);
                //prints all the options
                for (int i = 0; i < options.Length; i++)
                {
                    if (itemNo == i)
                    {
                        seperator = "->";
                    }
                    else
                    {
                        seperator = "  ";
                    }
                    Console.WriteLine($"\t {seperator} {i+1}.{options[i]}");
                }
                
                HConsole.StarRow();
                Console.WriteLine("Enter a command :");

                //gets the current key presseed
                key_pressed = Console.ReadKey();

                
                if (key_pressed.Key == ConsoleKey.UpArrow)
                {
                    //if uparrow is pressed and cursor length is greater than zero
                    //decrement it
                    //else if it less than zero reset it pointing it to first item
                    if (itemNo > 0)
                    {
                        itemNo--;
                    }
                    else
                    {
                        itemNo = options.Length - 1;
                    }
                   
                }
                
                else if (key_pressed.Key == ConsoleKey.DownArrow)
                {
                    //if downarrow is pressed and cursor length is less than number of items
                    //incremet it
                    //else if it greater than item length reset it pointing it to last item
                    if (itemNo < options.Length - 1 )
                    {
                        itemNo++;
                    }
                    else
                    {
                        itemNo = 0;
                    }
                }
                else
                {
                    //if up or down arrow is not pressed
                    //save the pressed input
                    //break from loop
                    command += key_pressed.KeyChar.ToString();
                    break;
                }

            } while (key_pressed.Key != ConsoleKey.Enter);

            //enter is pressed return the selected item
            if (key_pressed.Key == ConsoleKey.Enter )
            {
                return options[itemNo];
            }
            //else return the last input saved
            return command;
        }
    }
}
