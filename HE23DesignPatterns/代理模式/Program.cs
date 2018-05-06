using System;

namespace DesignMethod.代理模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            Person proxy = new Friend();
            proxy.BuyProduct();
            Console.Read();
        }
    }
}