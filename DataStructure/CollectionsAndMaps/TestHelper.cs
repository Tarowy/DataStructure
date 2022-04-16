using System;
using System.Collections.Generic;
using System.IO;

namespace DataStructure.CollectionsAndMaps
{
    public class TestHelper
    {
        public static List<string> ReadFile(string filename)
        {
            //文件IO流读取文件
            var fs = new FileStream(filename, FileMode.Open);
            //读取filestream的信息
            var sr = new StreamReader(fs);

            //储存读取到的单词
            var words = new List<string>();

            //一直读取到文件的末尾为止
            while (!sr.EndOfStream)
            {
                //读取一行字符串并去除首部和尾部的空格
                var contents = sr.ReadLine()?.Trim();
                //找到第一个字母的位置
                var start = FirstCharacterIndex(contents, 0);

                for (var i = start + 1; i <= contents?.Length;)
                {
                    //如果已经是字符串的末尾或者该字符不是字母
                    if (i == contents.Length || !Char.IsLetter(contents[i]))
                    {
                        //将这段单词截取下来
                        var substring = contents.Substring(start, i - start).ToLower();
                        words.Add(substring);
                        //继续从当前位置开始寻找下一个字母的位置
                        start = FirstCharacterIndex(contents, i);
                        i = start + 1;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            sr.Close();
            fs.Close();
            return words;
        }

        private static int FirstCharacterIndex(string content, int start)
        {
            for (var i = start; i < content.Length; i++)
            {
                if (char.IsLetter(content[i]))
                {
                    return i;
                }
            }

            return content.Length;
        }
    }
}