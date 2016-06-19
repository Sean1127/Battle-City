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
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Type type = (Type)br.ReadInt32();
                    map[j, i] = new Object(type);
                    map[j, i].Size = new Size(32, 32);
                    map[j, i].Top = j * 32;
                    map[j, i].Left = i * 32;
                }
            }

            br.Close();
            return map;
        }

        public static void WriteMap(Object[,] map, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Type type = map[j, i].type;
                    bw.Write(type.ToString());
                    bw.Flush();
                }
            }
            bw.Close();
        }
    }
}
