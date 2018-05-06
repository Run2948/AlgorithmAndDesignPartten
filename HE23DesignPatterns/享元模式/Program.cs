using System;

namespace DesignMethod.享元模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            //定义外部状态
            int externalstate = 10;
            //初始化享元工厂
            FlyweightFactory factory = new FlyweightFactory();
            //判断是否有A字符
            Flyweight fa = factory.GetFlyweight("A");
            if (fa != null)
            {
                fa.Operation(externalstate);
            }
            //判断B字符
            Flyweight fb = factory.GetFlyweight("B");
            if (fb != null)
            {
                fb.Operation(externalstate);
            }
            //判断C字符
            Flyweight fc = factory.GetFlyweight("C");
            if (fc != null)
            {
                fc.Operation(externalstate);
            }
            //判断D字符
            Flyweight fd = factory.GetFlyweight("D");
            if (fd != null)
            {
                fd.Operation(externalstate);
            }
            else
            {
                Console.WriteLine("不存在字符串D");
                ConcreteFlyweight d = new ConcreteFlyweight("D");
                factory.flyweights.Add("D", d);
            }
            Console.WriteLine("");
            Console.Read();
        }
    }
}