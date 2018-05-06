using System;
using System.Collections.Generic;

namespace DesignMethod.享元模式
{
    //享元对象
    public class ConcreteFlyweight : Flyweight
    {
        private string intrinsicstate;

        public ConcreteFlyweight(string name)
        {
            this.intrinsicstate = name;
        }

        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("具体实现类：intrinsicstate{0},extrinsicstate{1}", intrinsicstate, extrinsicstate);
        }
    }

    //享元抽象类
    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

    //享元工厂
    public class FlyweightFactory
    {
        public Dictionary<string, Flyweight> flyweights = new Dictionary<string, Flyweight>();

        public FlyweightFactory()
        {
            flyweights.Add("A", new ConcreteFlyweight("A"));
            flyweights.Add("B", new ConcreteFlyweight("B"));
            flyweights.Add("C", new ConcreteFlyweight("C"));
        }

        public Flyweight GetFlyweight(string key)
        {
            Flyweight flyweight = null;
            if (flyweights.ContainsKey(key))
            {
                return flyweights[key] as Flyweight;
            }

            if (flyweights == null)
            {
                Console.WriteLine("驻留池中不存在字符串" + key);
                flyweight = new ConcreteFlyweight(key);
            }
            return flyweight as Flyweight;
        }
    }
}