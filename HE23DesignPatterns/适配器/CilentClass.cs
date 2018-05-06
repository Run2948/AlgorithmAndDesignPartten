//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :CilentClass
// created by 朱锦润
// created time 2017/07/03 14:17:22
//--------------------------------------------
using System;

namespace DesignMethod.适配器
{
    /// <summary>
    /// 目标角色
    /// </summary>
    public interface IThreeHole
    {
        void Requset();
    }

    /// <summary>
    /// 适配器类
    /// </summary>
    public class PowerAdpter : TwoHole, IThreeHole
    {
        public void Requset()
        {
            this.SpecificRequest();
        }
    }

    /// <summary>
    /// 源角色需要适配的类
    /// </summary>
    public class TwoHole
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是两个孔的插头");
        }
    }
}