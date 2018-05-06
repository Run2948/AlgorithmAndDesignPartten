//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/02 18:07:23
//--------------------------------------------

namespace DesignMethod.单例模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            Singleton let = Singleton.GetInstance();
            let.Co();
        }
    }
}