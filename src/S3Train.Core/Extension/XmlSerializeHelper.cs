using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MVC.Core.Extension
{
    public static class XmlSerializeHelper
    {
        #region Serialize Methods

        public static bool ObjectToFile<T>(string filePath, T obj)
        {
            bool isSuccess = false;
            if (obj != null)
            {
                using (var streamWriter = new StreamWriter(filePath))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(streamWriter, obj);
                    isSuccess = true;
                }
            }
            return isSuccess;
        }

        public static bool ObjectToFile<T>(string filePath, T obj, string xmlNamespace)
        {
            bool isSuccess = false;
            if (obj != null)
            {
                var xmlSettings = new XmlWriterSettings();
                xmlSettings.OmitXmlDeclaration = true;
                xmlSettings.Indent = true;
                using (var xmlWriter = XmlTextWriter.Create(filePath, xmlSettings))
                {
                    var serializeNamespaces = new XmlSerializerNamespaces();
                    serializeNamespaces.Add(string.Empty, xmlNamespace);

                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(xmlWriter, obj);
                    isSuccess = true;
                }
            }
            return isSuccess;
        }

        #endregion Serialize Methods

        #region Deserialize Methods

        public static T XmlToObject<T>(string xml) where T : class, new()
        {
            T obj = null;
            using (var reader = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                obj = serializer.Deserialize(XmlReader.Create(reader)) as T;
            }
            return obj;
        }

        public static T XmlFileToObject<T>(string filePath) where T : class, new()
        {
            T obj = null;
            if (File.Exists(filePath))
            {
                string xml = File.ReadAllText(filePath);
                return XmlToObject<T>(xml);
            }
            return obj;
        }

        #endregion Deserialize Methods
    }
}