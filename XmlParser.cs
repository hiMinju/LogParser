using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogParser
{
    class XmlParser
    {
        public List<List<String>> innerXml = new List<List<String>>();
        public List<String> innerAttr = new List<String>();
        public List<String> childName = new List<String>();
        public List<string[]> listString = new List<string[]>();

        public string[] attr;

        public List<List<String>> StringParsing(string strXml)
        {
            strXml.Trim();

            string[] lines = strXml.Split('\n');

            foreach (string s in lines)
            {
                string[] line = s.Split('\t');
                for (int i = 0; i < line.Length; i++)
                {
                    line[i] = line[i].Trim(); // 뒤에 의미 없는 공백 제거
                }
                listString.Add(line);
            }

            attr = listString[0];

            
            for (int i = 1; i < listString.Count; i++)
            {
                string[] s = listString[i];

                // xml 형식일 때와 아닐 때 구분
                XmlDocument xml = new XmlDocument(); // XmlDocument 생성
                if(s.Length>4)
                {
                    for(int j=0; j < s.Length-1; j++)
                    {
                        innerAttr.Add(s[j]);
                    }
                    
                    try
                    {
                        xml.LoadXml(s[s.Length-1]);
                    }
                    catch (XmlException e)
                    {
                        Console.WriteLine(e);
                    }
                    XmlNodeList xnList = xml.GetElementsByTagName("Table");


                    foreach (XmlNode node in xnList)
                    {
                        XmlNodeList childList = node.ChildNodes;
                        List<String> text = new List<String>();
                        foreach (XmlNode childNode in childList)
                        {
                            if (innerAttr.Count <= 5)
                            {
                                childName.Add(childNode.Name);
                            }
                            text.Add(childNode.InnerText);
                        }
                        innerXml.Add(text);
                    }
                }
            }
            return innerXml;
        }
    }
}
