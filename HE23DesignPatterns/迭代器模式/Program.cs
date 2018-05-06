//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/07 11:11:44
//--------------------------------------------
using System;

namespace DesignMethod.迭代器模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            Iterator iterator;
            IListCollection list = new ConcreteList();
            iterator = list.GetIterator();

            while (iterator.MoveNext())
            {
                int i = (int)iterator.GetCurrent();
                Console.WriteLine(i.ToString());
                iterator.Next();
            }
            Console.Read();
        }
    }
}