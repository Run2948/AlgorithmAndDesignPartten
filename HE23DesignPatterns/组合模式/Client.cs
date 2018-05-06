//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Client
// created by 朱锦润
// created time 2017/07/03 17:16:27
//--------------------------------------------
using System;
using System.Collections.Generic;

namespace DesignMethod.组合模式
{
    /// <summary>
    /// 圆
    /// </summary>
    public class Circle : Graphics
    {
        public Circle(string name)
            : base(name)
        { }

        public override void Add(Graphics g)
        {
            throw new Exception("不能向圆添加其他图形");
        }

        public override void Draw()
        {
            Console.WriteLine("画：" + Name);
        }

        public override void Remove(Graphics g)
        {
            throw new Exception("不能向圆添加其他图形");
        }
    }

    /// <summary>
    /// 复杂图形
    /// </summary>
    public class ComplexGraphics : Graphics
    {
        private List<Graphics> complexGraphicsList = new List<Graphics>();

        public ComplexGraphics(string name)
            : base(name)
        { }

        public override void Add(Graphics g)
        {
            complexGraphicsList.Add(g);
        }

        public override void Draw()
        {
            foreach (Graphics g in complexGraphicsList)
            {
                g.Draw();
            }
        }

        public override void Remove(Graphics g)
        {
            complexGraphicsList.Remove(g);
        }
    }

    /// <summary>
    /// 抽象类
    /// </summary>
    public abstract class Graphics
    {
        public Graphics(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public abstract void Add(Graphics g);

        public abstract void Draw();

        public abstract void Remove(Graphics g);
    }

    /// <summary>
    /// 线
    /// </summary>
    public class Line : Graphics
    {
        public Line(string name)
            : base(name)
        { }

        public override void Add(Graphics g)
        {
            throw new Exception("不能向线添加其他图形");
        }

        public override void Draw()
        {
            Console.WriteLine("画：" + Name);
        }

        public override void Remove(Graphics g)
        {
            throw new Exception("不能向线添加其他图形");
        }
    }
}