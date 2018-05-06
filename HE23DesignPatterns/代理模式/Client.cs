using System;

namespace DesignMethod.代理模式
{
    //代理角色
    public class Friend : Person
    {
        private RealBuyPerson realSubject;

        public override void BuyProduct()
        {
            Console.WriteLine("通过代理类访问真实实体对象的方法");
            if (realSubject == null)
            {
                realSubject = new RealBuyPerson();
            }
            this.PreBuyProduct();
            realSubject.BuyProduct();
            this.PostBuyProduct();
        }

        //操作2
        public void PostBuyProduct()
        {
            Console.WriteLine("列清单");
        }

        //代理角色执行的一些操作
        public void PreBuyProduct()
        {
            Console.WriteLine("弄清单");
        }
    }

    //抽象主题角色
    public abstract class Person
    {
        public abstract void BuyProduct();
    }

    //真实主题角色
    public class RealBuyPerson : Person
    {
        public override void BuyProduct()
        {
            Console.WriteLine("帮我买一个Iphone和一台苹果电脑");
        }
    }
}