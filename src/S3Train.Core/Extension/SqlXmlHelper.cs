using System;
using System.Collections.Generic;
using System.Xml;

namespace MVC.Core.Extension.Helper
{
    public static class SqlXmlHelper
    {
        /// <summary>
        /// Parse xml and load all sql statements from there
        /// </summary>
        /// <param name="sqlFileContent"></param>
        /// <returns></returns>
        public static IDictionary<string, string> LoadSqlListFromXml(string sqlFileContent)
        {
            IDictionary<string, string> sqlList = null;
            if (!string.IsNullOrEmpty(sqlFileContent))
            {
                var xmldoc = new XmlDocument();
                xmldoc.LoadXml(sqlFileContent);
                var nsmgr = new XmlNamespaceManager(xmldoc.NameTable);
                nsmgr.AddNamespace("nmsp", xmldoc.DocumentElement.NamespaceURI);
                var nodelist = xmldoc.DocumentElement.SelectNodes("//nmsp:SQL", nsmgr);
                sqlList = new Dictionary<string, string>();
                foreach (XmlNode node in nodelist)
                {
                    string sqlId = XmlHelper.GetAttribute(node, "Id");
                    string sql = XmlHelper.GetNodeValue(node);
                    sqlList[sqlId] = sql;
                }
                return sqlList;
            }
            else
            {
                throw new ApplicationException("Cannot load sql list from empty content");
            }
        }
    }
}