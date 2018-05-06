//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Client
// created by 朱锦润
// created time 2017/07/08 13:29:03
//--------------------------------------------
using System;

namespace DesignMethod.责任链模式
{
    //审批人
    public abstract class Approver
    {
        public Approver(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public Approver NextApprover { get; set; }

        public abstract void ProcessRequest(PurchaseRequest request);
    }

    //管理者
    public class Manager : Approver
    {
        public Manager(string name)
            : base(name) { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 10000.0)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

    //总经理
    public class President : Approver
    {
        public President(string name)
            : base(name) { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 100000.0)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else
            {
                Console.WriteLine("Request需要组织一个会议");
            }
        }
    }

    //采购请求
    public class PurchaseRequest
    {
        public PurchaseRequest(double amount, string productName)
        {
            Amount = amount;
            ProductName = productName;
        }

        //金额
        public double Amount { get; set; }

        //产品名称
        public string ProductName { get; set; }
    }

    //副总
    public class VicePresident : Approver
    {
        public VicePresident(string name)
            : base(name) { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 25000.0)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }
}