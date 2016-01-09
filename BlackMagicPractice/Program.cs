using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BotTemplate.Constants.Offsets;

namespace BlackMagicPractice {
    class Program {
        public static string processwindowtitle = "World of Warcraft";
        private static BlackMagic wow;
        static void Main(string[] args) {
            wow = new BlackMagic();
            wow.OpenProcessAndThread(SProcess.GetProcessFromWindowTitle(processwindowtitle));
            uint gamebase = (uint)wow.MainModule.BaseAddress;
            uint plvl1 = wow.ReadUInt(gamebase + 0x00A42788);
            uint plvl2 = wow.ReadUInt(plvl1 + 0x9c);
            uint plvl3 = wow.ReadUInt(plvl2 + 0x5c);
            uint plvl4 = wow.ReadUInt(plvl3 + 0x60);
            uint player_guid = plvl3 - 0x10;
            //uint playerbase = wow.ReadUInt(wow.ReadUInt(wow.ReadUInt(0x0A87EC2C+0x40))); //this is the player base
            string playername = wow.ReadASCIIString(0x00DBE820, 256); //reads player name
            Console.WriteLine(wow.ReadUInt(player_guid+(uint)descriptors.Health));
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            /*Console.WriteLine(playername + plvl4);
                for (uint j = 0; j < 1; j++) {
                try {
                    uint c = uint.Parse(Console.ReadLine());

                    for (uint i = 0; i < 2000; i++) {
                        uint temp = wow.ReadUInt(plvl3 + (0x10 * i));
                        if (temp > 0 && temp < 200000) {
                            Console.WriteLine("Value: " + temp + " at 0x{0:X}", (0x10 * i));
                            if (temp == c) {
                                Console.WriteLine("Found it! Press enter to continue...");
                                Console.ReadLine();
                            }
                        }
                    }
                }
                catch {

                }
            }
            for (uint i = 0; i < 100; i++) {
                try {
                    uint offset = uint.Parse(Console.ReadLine());
                    Console.WriteLine(wow.ReadUInt(plvl3 + offset));
                }
                catch {

                }
            }
            */
            //////////////////
            Console.ReadLine();
        }

    }
}
