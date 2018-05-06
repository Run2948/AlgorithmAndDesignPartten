//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Client
// created by 朱锦润
// created time 2017/07/06 15:09:07
//--------------------------------------------
using System;

namespace DesignMethod.命令模式
{
    //命令抽象类
    public abstract class Command
    {
        //命令应该知道接受者是谁，所以有Receiver这个成员变量
        protected Receiver _receiver;

        public Command(Receiver receiver)
        {
            this._receiver = receiver;
        }

        public abstract void Action();
    }

    //具体指令
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver)
            : base(receiver)
        { }

        public override void Action()
        {
            _receiver.Run1000Meters();
        }
    }

    //调用命令执行要求
    public class Invoke
    {
        public Command _command;

        public Invoke(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Action();
        }
    }

    //命令接受者
    public class Receiver
    {
        public void Run1000Meters()
        {
            Console.WriteLine("跑1000米");
        }
    }
}