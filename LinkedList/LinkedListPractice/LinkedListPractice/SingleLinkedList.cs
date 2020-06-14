using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPractice
{

    public class SingleLinkedListNode<T>
    {
        public T Data { get; set; }
        public SingleLinkedListNode<T> Next { get; set; }

        public SingleLinkedListNode(T data)
        {
            this.Data = data;
            this.Next = null;
        }
    }


    public class SingleLinkedList<T>
    {
        // 리스트의 첫 노드를 가리키는 head, 이를 사용하여 전체 리스트를 순차적으로 엑세스함.
        private SingleLinkedListNode<T> head;

        // 새 노드를 추가하는 Add() 매서드
        public void Add(SingleLinkedListNode<T> newNode)
        {
            // 리스트가 비어있다면...
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;

                while (current != null && current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }
        }

        // CurrentNode - NextNode => CurrentNode - NewNode - NextNode로 변환
        public void AddAfter(SingleLinkedListNode<T> current, SingleLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }


        public void Remove(SingleLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null) return;

            // 삭제할 노드가 첫 노드면
            if (removeNode == head)
            {
                head = head.Next;
                removeNode = null;
            }
            else
            {
                var current = head;

                // 단방향이므로 삭제할 노드의 바로 이전 노드를 검색해야 함

                while (current != null && current.Next != removeNode)
                {
                    current = current.Next;
                }

                if (current != null)
                {
                    // 이전 노드의 Next에 삭제노드의 Next를 할당
                    current.Next = removeNode.Next;
                    removeNode = null;
                }

            }
        }

        public SingleLinkedListNode<T> GetNode(int index)
        {
            var current = head;
            for (int i = 0; i < index && current != null; i++ )
            {
                current = current.Next;
            }

            // 만약 index가 리스트 카운터보다 크면 Null이 리턴됨
            return current;
        }

        public int Count()
        {
            int cnt = 0;

            var current = head;
            while (current != null)
            {
                cnt++;
                current = current.Next;
            }

            return cnt;
        }
    }
}
