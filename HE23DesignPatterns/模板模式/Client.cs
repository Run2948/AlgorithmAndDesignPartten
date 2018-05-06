//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Client
// created by 朱锦润
// created time 2017/07/06 10:44:39
//--------------------------------------------
using System;

namespace DesignMethod.模板模式
{
    //大白菜
    public class ChineseCabbage : Vegetabel
    {
        public override void pourVegetabel()
        {
            Console.WriteLine("倒大白菜进锅中");
        }
    }

    //菠菜
    public class Spinach : Vegetabel
    {
        public override void pourVegetabel()
        {
            Console.WriteLine("倒菠菜进锅中");
        }
    }

    //定义抽象类
    public abstract class Vegetabel
    {
        //模板方法，不要定义可重写的修饰符
        public void CookVegetabel()
        {
            Console.WriteLine("炒蔬菜的一般做法");
            this.pourOil();
            this.HeatOil();
            this.pourVegetabel();
            this.stir_fly();
        }

        //油烧热
        public void HeatOil()
        {
            Console.WriteLine("油烧热");
        }

        //倒油
        public void pourOil()
        {
            Console.WriteLine("倒油");
        }

        //油热了之后倒蔬菜下去，具体哪种蔬菜由子类决定
        public abstract void pourVegetabel();

        //开始翻炒蔬菜
        public void stir_fly()
        {
            Console.WriteLine("翻炒");
        }
    }
}