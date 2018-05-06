//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Customer
// created by 朱锦润
// created time 2017/07/03 10:45:43
//--------------------------------------------
using System;
using System.Collections.Generic;

namespace DesignMethod.建造者
{
    //抽象建造者
    public abstract class Builder
    {
        //装CPU
        public abstract void BuilderPartCPU();

        //装主板
        public abstract void BuilderPartMainBoard();

        //获得组装好的电脑
        public abstract Computer GetComputer();
    }

    //电脑类
    public class Computer
    {
        //电脑组建集合
        private IList<string> parts = new List<string>();

        //单个组件添加到电脑组建集合中
        public void Add(string part)
        {
            parts.Add(part);
        }

        //显示
        public void Show()
        {
            Console.WriteLine("开始....");
            foreach (string part in parts)
            {
                Console.WriteLine("组件" + part + "已装好");
            }
            Console.WriteLine("组装完成");
        }
    }

    //具体创建者
    public class ConcreateBuilder2 : Builder
    {
        private Computer computer = new Computer();

        public override void BuilderPartCPU()
        {
            computer.Add("CPU2");
        }

        public override void BuilderPartMainBoard()
        {
            computer.Add("Main Board2");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }

    //具体创建者
    public class ConcreteBuilder1 : Builder
    {
        private Computer computer = new Computer();

        public override void BuilderPartCPU()
        {
            computer.Add("CPU1");
        }

        public override void BuilderPartMainBoard()
        {
            computer.Add("Main Board1");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }

    public class Director
    {
        //组装电脑
        public void Construct(Builder builder)
        {
            builder.BuilderPartCPU();
            builder.BuilderPartMainBoard();
        }
    }
}