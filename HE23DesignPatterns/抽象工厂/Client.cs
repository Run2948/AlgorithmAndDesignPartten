//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Client
// created by 朱锦润
// created time 2017/07/03 9:46:15
//--------------------------------------------
using System;

namespace DesignMethod.抽象工厂
{
    // 抽象工厂类
    public abstract class AbstractFactory
    {
        public abstract YaBo CreateYaBo();

        public abstract YaJia CreateYaJia();
    }

    //南昌工厂类
    public class NanChangFactory : AbstractFactory
    {
        public override YaBo CreateYaBo()
        {
            return new NanChangYaBo();
        }

        public override YaJia CreateYaJia()
        {
            return new NanChangYaJia();
        }
    }

    //上海工厂
    public class ShangHaiFactory : AbstractFactory
    {
        public override YaBo CreateYaBo()
        {
            return new ShangHaiYaBo();
        }

        public override YaJia CreateYaJia()
        {
            return new ShangHaiYaJia();
        }
    }

    #region 食品抽象类

    //南昌鸭脖
    public class NanChangYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("南昌的鸭脖");
        }
    }

    //南昌鸭架
    public class NanChangYaJia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("南昌的鸭架");
        }
    }

    //上海鸭脖
    public class ShangHaiYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("上海鸭脖");
        }
    }

    //上海鸭架
    public class ShangHaiYaJia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("上海鸭架");
        }
    }

    //定义鸭脖抽象类
    public abstract class YaBo
    {
        public abstract void Print();
    }

    //定义鸭架抽象类
    public abstract class YaJia
    {
        public abstract void Print();
    }

    #endregion 食品抽象类
}