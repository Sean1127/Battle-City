using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
                    string type = br.ReadString();
                    map[j, i] = new Object(type);
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
                    string type = map[j, i].Name;
                    bw.Write(type);
                    bw.Flush();
                }
            }
            bw.Close();
        }
    }
}
