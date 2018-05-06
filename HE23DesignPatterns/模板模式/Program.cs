//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/06 10:44:32
//--------------------------------------------
using System;

namespace DesignMethod.模板模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            Spinach spinach = new Spinach();
            spinach.CookVegetabel();
            Console.Read();
        }
    }
}