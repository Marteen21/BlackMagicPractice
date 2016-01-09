using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //uint playerbase = wow.ReadUInt(wow.ReadUInt(wow.ReadUInt(0x0A87EC2C+0x40))); //this is the player base
            string playername = wow.ReadASCIIString(0x00DBE820, 256); //reads player name
            Console.WriteLine(playername + "'s max HP is: " +plvl4);
            for(uint i=0;i<500;i++) {
                uint temp = wow.ReadUInt(plvl4 + (0x10 * i));
                if (temp != 0) {
                    Console.WriteLine("Value: " + temp + " at 0x{0:X}",(0x10*i));
                }
            }

            //////////////////
            Console.ReadLine();
        }

    }
}
