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
        public static Object[][] ReadMap(string fileName)
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Object[][]));
            System.IO.StreamReader file = new System.IO.StreamReader(
                Environment.CurrentDirectory + "//" + fileName);
            Object[][] overview = (Object[][])reader.Deserialize(file);
            file.Close();
            return overview;
        }

        public static void WriteMap(Object[][] overview, string fileName)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Object[][]));

            var path = Environment.CurrentDirectory + "//" + fileName;
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, overview);
            file.Close();
        }
    }
}
