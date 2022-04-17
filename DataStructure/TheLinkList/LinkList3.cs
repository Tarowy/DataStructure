using System;
using System.Text;

namespace DataStructure.TheLinkList
{
    /// <summary>
    /// 用于字典(映射)类型的链表
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    public class LinkList3<Key, Value>
    {
        public class Node
        {
            public Key key;
            public Value value;
            public Node next;

            public Node(Key key, Value value, Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }

            public override string ToString()
            {
                return new StringBuilder($"{key.ToString()} : {value.ToString()}").ToString();
            }
        }

        private Node _head;
        private int _n;

        public LinkList3()
        {
            _head = null;
            _n = 0;
        }

        public int Count => _n;
        public bool ISEmpty => _n == 0;

        /// <summary>
        /// 获取包含指定元素的节点,从头到尾遍历所有元素,
        /// 由于Add、Get、Set、Contains都需要用到该方法，
        /// 导致极其损耗性能
        /// </summary>
        /// <returns></returns>
        private Node GetNode(Key key)
        {
            var cur = _head;
            while (cur != null)
            {
                if (cur.key.Equals(key))
                {
                    return cur;
                }

                cur = cur.next;
            }

            return null;
        }

        public void Add(Key key, Value value)
        {
            var node = GetNode(key);

            //如果没有键为key的节点，就将其加入链表中
            if (node == null)
            {
                //快捷的将新节点加入链表且让head指向新节点
                _head = new Node(key, value, _head);
                _n++;
            }
            //如果有键为key的节点，就更新值
            else
            {
                node.value = value;
            }
        }

        public bool Contains(Key key)
        {
            return GetNode(key) != null;
        }

        public Value Get(Key key)
        {
            var node = GetNode(key);

            if (node == null)
            {
                throw new ArgumentException($"键{key}不存在");
            }

            return node.value;
        }

        public void Set(Key key,Value value)
        {
            var node = GetNode(key);

            if (node == null)
            {
                throw new ArgumentException($"键{key}不存在");
            }

            node.value = value;
        }
        
        public void Remove(Key key)
        {
            if (_head == null)
            {
                return;
            }

            if (_head.key.Equals(key))
            {
                _head = _head.next;
                _n--;
            }
            else
            {
                var cur = _head;
                Node pre = null;

                while (cur != null)
                {
                    if (cur.key.Equals(key))
                    {
                        pre.next = cur.next;
                        _n--;
                        break;
                    }

                    pre = cur;
                    cur = cur.next;
                }
            }
        }
    }
}