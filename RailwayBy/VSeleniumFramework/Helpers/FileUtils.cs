using System;
using System.Xml;

namespace VSeleniumFramework.Helpers
{
    public class FileUtils
    {
        private static string Language
        {
            get => GetProperty("Language");
        }
        public static string GetProperty(string nameProperty)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(System.IO.Directory.GetCurrentDirectory() + @"/config.xml"))
                {
                    try
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement() && reader.Name.ToString() == nameProperty)
                            {
                                return reader.ReadElementContentAsString();
                            }
                        }
                        throw new System.ArgumentException("Bad name of Property – " + nameProperty);
                    }
                    catch (Exception e)
                    {
                        Logger.Error("FileUtils", "GetProperty", e);
                        throw new Exception(e.Message);
                    }
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
                Logger.Error("FileUtils", "GetProperty", e);

                throw new System.IO.FileNotFoundException("'Config.xml' file is not exisits or bad path/ bad name.");
            }
        }

        private static XmlNode GetLanguageNode(string Language)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.IO.Directory.GetCurrentDirectory() + GetProperty("LocalizationFile"));
                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/testdata/Language");

                foreach (XmlNode node in nodes)
                {
                    if (string.Compare(node.Attributes["Name"].Value, Language) == 0)
                        return node;
                }
                throw new ArgumentException("Language is not valid");
            }
            catch (Exception e)
            {
                Logger.Error("FileUtils", "GetLanguageNode", e);
                throw new Exception(e.Message);

            }
        }

        public static string GetLocalWord(string word)
        {
            try
            {
                return GetLanguageNode(Language).SelectSingleNode(word).InnerText;
            }
            catch(System.NullReferenceException e)
            {
                Logger.Error("FileUtils", "GetLocalWord", e);

                throw new NullReferenceException("Bad path to localization word. Word is not exists.");
            }
        }

    }

    

    
}
