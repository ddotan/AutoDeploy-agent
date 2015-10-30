using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AutoDeploy.Application.Utilities
{
   public class XmlUtilities
    {
       public static T Serilize<T>(string i_Path)
       {
           T item;
           using (FileStream stream = new FileStream(i_Path, FileMode.OpenOrCreate))
           {
               XmlSerializer serializer = new XmlSerializer(typeof(T));
               item = (T)serializer.Deserialize(stream);
           }
           return item;
       }
    }
}
