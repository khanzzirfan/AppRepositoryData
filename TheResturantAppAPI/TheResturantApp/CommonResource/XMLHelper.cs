using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TheResturantApp.CommonResource
{
    public static  class XMLHelper
    {
        public static string GetXMLFromObject(object o)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                using (var sw = new StringWriter())
                {
                    using (var tw = new XmlTextWriter(sw))
                    {
                        serializer.Serialize(tw, o);
                        return sw.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
             //   sw.close();
              //  tw.close();
            }
            return null;
        }
    }
}
