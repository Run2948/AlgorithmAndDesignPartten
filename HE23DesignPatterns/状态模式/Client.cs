//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Client
// created by 朱锦润
// created time 2017/07/07 13:47:03
//--------------------------------------------
using System;

namespace DesignMethod.状态模式
{
    /// <summary>
    /// 当前对象的状态
    /// </summary>
    public class Account
    {
        public Account(string owner)
        {
            this.Owner = owner;
            this.State = new SilverState(0.00, this);
        }

        public double Balance { get { return State.Balance; } }
        public string Owner { get; set; }
        public State State { get; set; }

        //存款
        public void Deposit(double amount)
        {
            State.Deposit(amount);
            Console.WriteLine("存款金额为：{0:C}---", amount);
            Console.WriteLine("账户余额为 =:{0:C}", this.Balance);
            Console.WriteLine("账户状态为: {0}", this.State.GetType().Name);
            Console.WriteLine();
        }

        //余额
        public void PayInterest()
        {
            State.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine("账户余额为 =:{0:C}", this.Balance);
            Console.WriteLine("账户状态为: {0}", this.State.GetType().Name);
            Console.WriteLine();
        }

        //取款
        public void Withdraw(double amount)
        {
            State.Withdraw(amount);
            Console.WriteLine("取款金额为：{0:C}---", amount);
            Console.WriteLine("账户余额为 =:{0:C}", this.Balance);
            Console.WriteLine("账户状态为: {0}", this.State.GetType().Name);
            Console.WriteLine();
        }
    }

    //普通账户
    public class GoldState : State
    {
        public GoldState(State state)
        {
            this.Balance = state.Balance;
            this.Account = state.Account;
            Interest = 0.05;
            LowerLimit = 1000.00;
            UpperLimit = 10000.00;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            Balance += Interest * Balance;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            Balance -= amount;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (Balance < 0.0)
            {
                Account.State = new RedState(this);
            }
            else if (Balance < LowerLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }

    //透支
    public class RedState : State
    {
        public RedState(State state)
        {
            this.Balance = state.Balance;
            this.Account = state.Account;
            Interest = 0.0;
            LowerLimit = -100.0;
            UpperLimit = 0.00;
        }

        //存款
        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
        }

        //取钱
        public override void Withdraw(double amount)
        {
            Console.WriteLine("没有钱可以取");
        }

        private void StateChangeCheck()
        {
            if (Balance > UpperLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }

    //新建账户
    public class SilverState : State
    {
        public SilverState(State state)
            : this(state.Balance, state.Account)
        {
        }

        public SilverState(double balance, Account account)
        {
            this.Balance = balance;
            this.Account = account;
            Interest = 0.00;
            LowerLimit = 0.00;
            UpperLimit = 1000.00;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            Balance += Interest * Balance;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            Balance -= amount;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (Balance < LowerLimit)
            {
                Account.State = new RedState(this);
            }
            else if (Balance > UpperLimit)
            {
                Account.State = new GoldState(this);
            }
        }
    }

    /// <summary>
    /// 抽象状态类
    /// </summary>
    public abstract class State
    {
        //状态
        public Account Account { get; set; }

        //余额
        public double Balance { get; set; }

        //利率
        public double Interest { get; set; }

        //上限
        public double LowerLimit { get; set; }

        //下限
        public double UpperLimit { get; set; }

        //存款
        public abstract void Deposit(double amount);

        //获得利息
        public abstract void PayInterest();

        //取钱
        public abstract void Withdraw(double amount);
    }
}