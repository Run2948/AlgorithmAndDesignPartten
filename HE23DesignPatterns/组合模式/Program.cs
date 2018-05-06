//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/03 17:16:17
//--------------------------------------------
using System;

namespace DesignMethod.组合模式
{
    public class Program : OpenDesign
    {
        public static void Open1()
        {
            #region 安全式组合模式

            ComplexGraphics2 complexGraphics = new ComplexGraphics2("复杂图形");
            complexGraphics.Add(new Line2("线A"));
            ComplexGraphics2 CompositeCG = new ComplexGraphics2("一个园和一条线");
            CompositeCG.Add(new Circle2("圆"));
            CompositeCG.Add(new Line2("线段B"));
            complexGraphics.Add(CompositeCG);
            Line2 l = new Line2("线段C");
            complexGraphics.Add(l);
            //显示复杂图形画法
            Console.WriteLine("复杂图形的绘制如下：");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("");
            //移除一个组件再显示复杂图形的画法
            complexGraphics.Remote(l);
            Console.WriteLine("移除线段C后，复杂图形的绘制如下：");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.Read();

            #endregion 安全式组合模式
        }

        public override void Open()
        {
            #region 透明式组合模式

            ComplexGraphics complexGraphics = new ComplexGraphics("一个复杂图形和两条线段组成的复杂图形");
            complexGraphics.Add(new Line("线段A"));
            ComplexGraphics CompositeCG = new ComplexGraphics("一个圆和一条线组成的复杂图形");
            CompositeCG.Add(new Circle("圆"));
            CompositeCG.Add(new Circle("线段B"));
            complexGraphics.Add(CompositeCG);
            Line l = new Line("线段C");
            complexGraphics.Add(l);
            //显示复杂图形的画法
            Console.WriteLine("复杂图形的绘制如下：");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("");
            //移除一个组件再显示复杂图形的画法
            complexGraphics.Remove(l);
            Console.WriteLine("移除线段C后，复杂图形的绘制如下：");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.Read();

            #endregion 透明式组合模式

            #region 安全组合模式

            Open1();

            #endregion 安全组合模式
        }
    }
}