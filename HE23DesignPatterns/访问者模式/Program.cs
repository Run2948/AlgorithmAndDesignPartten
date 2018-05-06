//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/08 14:22:59
//--------------------------------------------
using System;

namespace DesignMethod.访问者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            ObjectStructure objectstructure = new ObjectStructure();
            foreach (Element e in objectstructure.Element)
            {
                e.Accept(new ConcreteVistor());
            }

            Console.Read();
        }
    }
}