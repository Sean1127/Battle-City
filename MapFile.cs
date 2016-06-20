using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Type = Tank.Enum.Type;
using System.Drawing;

namespace Tank
{
    public class MapFile
    {
        public static Object[,] ReadMap(string fileName)
        {
            Object[,] map = new Object[13, 13];
            BinaryReader br;

            try
            {
                br = new BinaryReader(new FileStream(fileName, FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            try
            {
                for (int i = 0; i < 13; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        Type type = (Type)br.ReadInt32();
                        map[j, i].Size = new Size(32, 32);
                        map[j, i].Top = j * 32;
                        map[j, i].Left = i * 32;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            br.Close();
            return map;
        }

        public static void WriteMap(Object[,] map, string fileName)
        {
            BinaryWriter bw;
            try
            {
                bw = new BinaryWriter(new FileStream(fileName, FileMode.Create));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            try
            {
                for (int i = 0; i < 13; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        Type type = map[j, i].type;
                        bw.Write((int)type);
                        bw.Flush();
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            bw.Close();
        }
    }
}
