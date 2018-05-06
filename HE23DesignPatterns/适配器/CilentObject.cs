//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :CilentObject
// created by 朱锦润
// created time 2017/07/03 14:17:31
//--------------------------------------------
using System;

namespace DesignMethod.适配器
{
    /// <summary>
    /// 适配器类
    /// </summary>
    public class PowerAdapter : ThreeHole2
    {
        //引用实例
        public TwoHole2 twh = new TwoHole2();

        public override void Request()
        {
            twh.SpecificRequest();
        }
    }

    /// <summary>
    /// 三个孔插头，目标角色
    /// </summary>
    public class ThreeHole2
    {
        //客户端需要的方法
        public virtual void Request()
        {
            //可以把一般实现放在这里
            Console.WriteLine("我是三个孔插头");
        }
    }

    /// <summary>
    /// 两个孔插头，源角色
    /// </summary>
    public class TwoHole2
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是两个孔插头");
        }
    }
}