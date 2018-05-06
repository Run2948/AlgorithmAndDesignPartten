//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/03 9:43:11
//--------------------------------------------
using System;

namespace DesignMethod.抽象工厂
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            AbstractFactory nanChangFac = new NanChangFactory();
            YaBo nanChangYaBo = nanChangFac.CreateYaBo();
            nanChangYaBo.Print();

            AbstractFactory shangHaiFac = new ShangHaiFactory();
            shangHaiFac.CreateYaJia().Print();
            shangHaiFac.CreateYaBo().Print();

            Console.Read();
        }
    }
}