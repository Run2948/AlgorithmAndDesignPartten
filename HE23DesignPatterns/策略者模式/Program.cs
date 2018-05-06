//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/08 11:12:34
//--------------------------------------------
using System;

namespace DesignMethod.策略者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            //个人所得税
            InterestOperation operation = new InterestOperation(new PersonalTaxStrategy());
            Console.WriteLine("个人支付税为：{0}", operation.GetTax(5000.00));
            Console.WriteLine("-----------------------------");
            operation = new InterestOperation(new EnterpriseTaxStrategy());
            Console.WriteLine("企业支付税为：{0}", operation.GetTax(5000.00));
            Console.Read();
        }
    }
}