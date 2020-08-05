using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogParser
{
    class XmlParser // xml 부분 제외한 string parsing
    {
        public List<List<String>> innerXml = new List<List<String>>();
        public List<List<String>> innerName = new List<List<String>>();
        public List<String> innerAttr = new List<String>();
        public List<int> tableNum = new List<int>();
        public List<string[]> listString = new List<string[]>();
        public string[] attr;

        public void StringParsing(string strXml)
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
        }

        public void xmlParsing(string strXml) // 먼저 string parsing 후 xml parsing
        {
            StringParsing(strXml);

            for (int i = 1; i < listString.Count; i++)
            {
                string[] s = listString[i];

                // xml 형식일 때와 아닐 때 구분
                XmlDocument xml = new XmlDocument(); // XmlDocument 생성
                if (s.Length > 4)
                {
                    for (int j = 0; j < s.Length - 1; j++)
                    {
                        innerAttr.Add(s[j]);
                    }

                    try
                    {
                        xml.LoadXml(s[s.Length - 1]);
                    }
                    catch (XmlException e)
                    {
                        Console.WriteLine(e);
                    }

                    XmlNodeList xnList = xml.GetElementsByTagName("Table");
                    if (xnList.Count == 0)
                    {
                        xnList = xml.GetElementsByTagName("table");
                        if (xnList.Count == 0)
                        {
                            xnList = xml.GetElementsByTagName("NewDataset");
                        }
                    } // 다른 경우 있는지 확인 필요
                    tableNum.Add(xnList.Count);

                    for (int j = 0; j < xnList.Count; j++)
                    {
                        XmlNodeList childList = xnList[j].ChildNodes;
                        List<String> text = new List<String>();
                        List<String> name = new List<String>();
                        foreach (XmlNode childNode in childList)
                        {
                            name.Add(childNode.Name);
                            text.Add(childNode.InnerText);
                        }
                        innerName.Add(name);
                        innerXml.Add(text);
                    }
                }
            }
        }

        public void parsing(string StringXml)
        {
            XmlDocument xml = new XmlDocument(); // XmlDocument 생성

            try
            {
                xml.LoadXml(StringXml);
            }
            catch (XmlException e)
            {
                Console.WriteLine(e);
            }

            XmlNodeList xnList = xml.GetElementsByTagName("Table");
            if (xnList.Count == 0)
            {
                xnList = xml.GetElementsByTagName("table");
                if (xnList.Count == 0)
                {
                    xnList = xml.GetElementsByTagName("NewDataset");
                }
            } // 다른 경우 있는지 확인 필요
            tableNum.Add(xnList.Count);

            for (int j = 0; j < xnList.Count; j++)
            {
                XmlNodeList childList = xnList[j].ChildNodes;
                List<String> text = new List<String>();
                List<String> name = new List<String>();
                foreach (XmlNode childNode in childList)
                {
                    name.Add(childNode.Name);
                    text.Add(childNode.InnerText);
                }
                innerName.Add(name);
                innerXml.Add(text);
            }
        }
    }
}
