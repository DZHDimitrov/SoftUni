using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Theatre
{
    public class XmlConvert
    {
        public static string Serialize<T>(T dto, string xmlRootElement)
        {
            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootElement));

            var builder = new StringBuilder();
            var write = new StringWriter(builder);
            serializer.Serialize(write, dto, GetXmlNamespaces());

            return builder.ToString();
        }

        public static T Deserialize<T>(string xmlString, string xmlRootElement) where T : class
        {
            var attr = new XmlRootAttribute(xmlRootElement);
            XmlSerializer serializer = new XmlSerializer(typeof(T), attr);
            T deserializedObject = serializer.Deserialize(new StringReader(xmlString)) as T;
            return deserializedObject;
        }

        private static XmlSerializerNamespaces GetXmlNamespaces()
        {
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);
            return xmlNamespaces;
        }
    }
}
