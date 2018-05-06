//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Client
// created by 朱锦润
// created time 2017/07/08 15:39:17
//--------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMethod.解释者模式
{
    //接口
    public interface IExpression
    {
        void Interpret(StringBuilder sb);
    }

    //中英文对照字典
    public static class ChineseEnglishDict
    {
        private static Dictionary<string, string> _dictory = new Dictionary<string, string>();

        static ChineseEnglishDict()
        {
            _dictory.Add("this", "这");
            _dictory.Add("is", "是");
            _dictory.Add("an", "一个");
            _dictory.Add("apple", "苹果");
        }

        public static string GetEnglish(string value)
        {
            return _dictory[value];
        }
    }

    //包装
    public static class Translator
    {
        public static string Translate(string sentense)
        {
            StringBuilder sb = new StringBuilder();
            List<IExpression> expressions = new List<IExpression>();
            string[] elements = sentense.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string element in elements)
            {
                string[] words = element.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    expressions.Add(new WordExpression(word));
                }
                expressions.Add(new SymbolExpression("."));
            }
            foreach (IExpression expression in expressions)
            {
                expression.Interpret(sb);
            }
            return sb.ToString();
        }
    }

    public class SymbolExpression : IExpression
    {
        private string _value;

        public SymbolExpression(string value)
        {
            _value = value;
        }

        public void Interpret(StringBuilder sb)
        {
            switch (_value)
            {
                case ".":
                    sb.Append("。");
                    break;

                default:
                    break;
            }
        }
    }

    //具体翻译类
    public class WordExpression : IExpression
    {
        private string _value;

        public WordExpression(string value)
        {
            _value = value;
        }

        public void Interpret(StringBuilder sb)
        {
            sb.Append(ChineseEnglishDict.GetEnglish(_value.ToLower()));
        }
    }
}