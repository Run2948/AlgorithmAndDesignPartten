//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/03 15:39:48
//--------------------------------------------
using System;

namespace DesignMethod.桥接模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            RemoteControl remote = new ConcreteRemote();
            remote.Implementor = new ChangHong();
            remote.On();
            remote.Off();
            remote.SetChannel();
            Console.WriteLine();

            remote.Implementor = new SanXing();
            remote.On();
            remote.Off();
            remote.SetChannel();
            Console.WriteLine();

            Console.Read();
        }
    }
}