//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/08 15:38:57
//--------------------------------------------
using System;

namespace DesignMethod.解释者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            string englist = "This is an apple.";
            string chinese = Translator.Translate(englist);
            Console.WriteLine(chinese);
            Console.Read();
        }
    }
}