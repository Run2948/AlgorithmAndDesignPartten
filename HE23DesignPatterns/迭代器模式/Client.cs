//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Client
// created by 朱锦润
// created time 2017/07/07 11:12:11
//--------------------------------------------
using System;

namespace DesignMethod.迭代器模式
{
    //抽象聚合类
    public interface IListCollection
    {
        Iterator GetIterator();
    }

    //抽象迭代器
    public interface Iterator
    {
        Object GetCurrent();

        bool MoveNext();

        void Next();

        void Reset();
    }

    //具体迭代器类
    public class ConcreteInterator : Iterator
    {
        private int _index;

        //迭代器要集合对象进行遍历操作，自然就需要引用集合对象
        private ConcreteList _list;

        public ConcreteInterator(ConcreteList list)
        {
            _list = list;
            _index = 0;
        }

        public object GetCurrent()
        {
            return _list.GetElement(_index);
        }

        public bool MoveNext()
        {
            if (_index < _list.Length)
            {
                return true;
            }
            return false;
        }

        public void Next()
        {
            if (_index < _list.Length)
            {
                _index++;
            }
        }

        public void Reset()
        {
            _index = 0;
        }
    }

    //具体聚合类
    public class ConcreteList : IListCollection
    {
        private int[] collection;

        public ConcreteList()
        {
            collection = new int[] { 2, 4, 6, 8 };
        }

        public int Length
        {
            get { return collection.Length; }
        }

        public int GetElement(int index)
        {
            return collection[index];
        }

        public Iterator GetIterator()
        {
            return new ConcreteInterator(this);
        }
    }
}