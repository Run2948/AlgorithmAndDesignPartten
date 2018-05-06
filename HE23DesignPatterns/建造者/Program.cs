//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/03 10:45:15
//--------------------------------------------
using System;

namespace DesignMethod.建造者
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            //初始化指挥者、构造者
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreateBuilder2();

            //叫员工1去组装第一台电脑
            director.Construct(b1);
            //组装完，组装人员搬来组装好的电脑
            Computer computer1 = b1.GetComputer();
            computer1.Show();

            //叫员工2去组装第二台电脑
            director.Construct(b2);
            Computer computer2 = b2.GetComputer();
            computer2.Show();

            Console.Read();
        }
    }
}