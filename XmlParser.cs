﻿using System;
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
            //XmlDocument xml = new XmlDocument(); // XmlDocument 생성
            //try
            //{
            //    xml.Load("xml.xml");
            //}
            //catch (XmlException e)
            //{
            //    Console.WriteLine(e);
            //}

            //XmlNodeList xnList = xml.GetElementsByTagName("ConnString");

            //foreach (XmlNode node in xnList)
            //{
            //    XmlNodeList childList = node.ChildNodes;
            //    foreach (XmlNode childNode in childList)
            //    {
            //        Console.Write("{0}\n", childNode.Name);
            //        foreach (XmlAttribute attribute in childNode.Attributes)
            //        {
            //            Console.Write("{0} ", attribute.Name);
            //            Console.Write("{0}\t", attribute.Value);
            //        }

            //        Console.WriteLine();
            //        Console.WriteLine();
            //    }
            //}
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
                XmlDocument xml = new XmlDocument(); // XmlDocument 생성
                if(s.Length>4)
                {
                    for(int j=0; j <= 4; j++)
                    {
                        innerAttr.Add(s[j]);
                    }
                    
                    try
                    {
                        xml.LoadXml(s[4]);
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

        public void FileParsing(string strXml)
        {
            string[] textValue = System.IO.File.ReadAllLines(strXml);
            List<string[]> listString = new List<string[]>();

            if (textValue.Length > 0)
            {
                foreach (string str in textValue)
                {
                    string[] s = str.Split('\t');
                    for (int i = 0; i < s.Length; i++)
                    {
                        s[i] = s[i].Trim(); // 뒤에 의미 없는 공백 제거
                    }
                    listString.Add(s);
                }
            }
            List<String> attr = new List<string>();
            List<List<String>> innerText = new List<List<String>>();

            for (int i = 1; i < listString.Count; i++)
            {
                string[] s = listString[i];
                XmlDocument xml = new XmlDocument(); // XmlDocument 생성
                try
                {
                    xml.LoadXml(s[4]);
                }
                catch (XmlException e)
                {
                    Console.WriteLine(e);
                }
                XmlNodeList xnList = xml.GetElementsByTagName("Table");


                foreach (XmlNode node in xnList)
                {
                    XmlNodeList childList = node.ChildNodes;
                    List<String> text = new List<string>();
                    foreach (XmlNode childNode in childList)
                    {
                        if (attr.Count <= 5)
                        {
                            attr.Add(childNode.Name);
                        }
                        text.Add(childNode.InnerText);
                        //Console.Write("{0}\n", childNode.InnerText);
                    }
                    innerText.Add(text);
                }
            }

            foreach (string a in attr)
            {
                Console.Write("{0, -15}", a);
            }
            Console.WriteLine();

            foreach (List<String> list in innerText)
            {
                foreach (string s in list)
                {
                    Console.Write("{0, -15}", s);
                }
                Console.WriteLine();
            }
        }
    }
}