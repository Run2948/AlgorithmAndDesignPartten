//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Client
// created by 朱锦润
// created time 2017/07/03 13:29:29
//--------------------------------------------

namespace DesignMethod.原型模式
{
    /// <summary>
    /// 创建具体
    /// </summary>
    public class ConcretePrototype : MonkeyKingPrototype
    {
        public ConcretePrototype(string id)
            : base(id)
        { }

        public override MonkeyKingPrototype Clone()
        {
            return (MonkeyKingPrototype)this.MemberwiseClone();
        }
    }

    /// <summary>
    /// 孙悟空原型
    /// </summary>
    public abstract class MonkeyKingPrototype
    {
        public MonkeyKingPrototype(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }

        //克隆方法
        public abstract MonkeyKingPrototype Clone();
    }
}