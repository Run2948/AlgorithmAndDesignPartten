//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Client2
// created by 朱锦润
// created time 2017/07/03 18:01:00
//--------------------------------------------
using System;
using System.Collections.Generic;

namespace DesignMethod.组合模式
{
    //圆
    public class Circle2 : Graphics2
    {
        public Circle2(string name)
            : base(name)
        { }

        public override void Draw()
        {
            Console.WriteLine("画：" + Name2);
        }
    }

    //复杂图形
    public class ComplexGraphics2 : Graphics2
    {
        private List<Graphics2> complexGraphicsList = new List<Graphics2>();

        public ComplexGraphics2(string name)
            : base(name)
        { }

        public void Add(Graphics2 g)
        {
            complexGraphicsList.Add(g);
        }

        public override void Draw()
        {
            foreach (Graphics2 g in complexGraphicsList)
            {
                g.Draw();
            }
        }

        public void Remote(Graphics2 g)
        {
            complexGraphicsList.Remove(g);
        }
    }

    //图形抽象类
    public abstract class Graphics2
    {
        public Graphics2(string name)
        {
            this.Name2 = name;
        }

        public string Name2 { get; set; }

        public abstract void Draw();
    }

    //线
    public class Line2 : Graphics2
    {
        public Line2(string name)
            : base(name)
        { }

        public override void Draw()
        {
            Console.WriteLine("画：" + Name2);
        }
    }
}