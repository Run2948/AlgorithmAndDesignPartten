//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Client
// created by 朱锦润
// created time 2017/07/08 15:07:31
//--------------------------------------------
using System;
using System.Collections.Generic;

namespace DesignMethod.备忘录模式
{
    //管理角色
    public class Caretaker
    {
        public ContactMemento ContactM { get; set; }
    }

    //备忘录
    public class ContactMemento
    {
        //保存发起人的状态
        public List<ContactPerson> contactPersonBack;

        public ContactMemento(List<ContactPerson> persons)
        {
            contactPersonBack = persons;
        }
    }

    //联系人
    public class ContactPerson
    {
        public string MobileNum { get; set; }
        public string Name { get; set; }
    }

    //发起人
    public class MobileOwner
    {
        public MobileOwner(List<ContactPerson> persons)
        {
            ContactPersons = persons;
        }

        //发起人需要保存内部状态
        public List<ContactPerson> ContactPersons { get; set; }

        //创建备忘录
        public ContactMemento CreateMemento()
        {
            return new ContactMemento(new List<ContactPerson>(this.ContactPersons));
        }

        //将备忘录中的数据备份导入联系人中
        public void RestoreMemento(ContactMemento memento)
        {
            this.ContactPersons = memento.contactPersonBack;
        }

        public void Show()
        {
            Console.WriteLine("联系人列表中有{0}个人", ContactPersons.Count);
            foreach (ContactPerson per in ContactPersons)
            {
                Console.WriteLine("姓名：{0} 号码{1}", per.Name, per.MobileNum);
            }
        }
    }
}