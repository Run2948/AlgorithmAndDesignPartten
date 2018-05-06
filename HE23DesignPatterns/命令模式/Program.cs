//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/06 15:08:58
//--------------------------------------------
using System;

namespace DesignMethod.命令模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoke i = new Invoke(c);
            i.ExecuteCommand();
            Console.Read();
        }
    }
}