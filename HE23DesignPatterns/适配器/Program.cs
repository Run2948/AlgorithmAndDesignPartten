//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/03 14:17:02
//--------------------------------------------
using System;

namespace DesignMethod.适配器
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            #region OpenClass

            IThreeHole threehole = new PowerAdpter();
            threehole.Requset();
            Console.ReadLine();

            #endregion OpenClass

            #region OpenObject

            ThreeHole2 three = new PowerAdapter();
            three.Request();
            Console.ReadLine();

            #endregion OpenObject
        }
    }
}