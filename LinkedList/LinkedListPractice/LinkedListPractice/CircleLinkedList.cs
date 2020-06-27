using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks; 

namespace LinkedListPractice
{
    // Circular Linked List : 일반 연결 리스트에서 마지막 노드를 처음 노드에 연결시켜 원형으로 만든 구조이다.
    public class CircleLinkedList<T>
    {
        // 기본적인 구성은 DoubleLinkedListNode임.
        private DoubleLinkedListNode<T> head;

        public void Add (DoubleLinkedListNode<T> newNode)
        {
            // 첫번째 노드면
            if (head == null)
            {
                head = newNode;
                head.Next = null;
                head.Prev = null;
            }
            else
            {
                var tail = head.Prev; // 오해하지 말자 - Tail은 마지막 노드를 의미한다.
                // 처음과 마지막 사이에 데이터를 차곡차곡 쌓아가는 느낌으로다가..       

                head.Prev = newNode;
                tail.Next = newNode;
                newNode.Prev = tail;
                newNode.Next = head;
            }
        }

        public void AddAfter(DoubleLinkedListNode<T> current, DoubleLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            newNode.Next = current.Next;
            current.Next.Prev = newNode;
            newNode.Prev = current;
            current.Next = newNode;
        }

        public void Remove(DoubleLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            // 삭제할 노드가 헤드 + 노드가 1개일 경우
            if (removeNode == head && head == head.Next)
            {
                head = null;
            }
            // prev 노드와 Next 노드를 연결 및 removeNode를 Null처리한다.
            else
            {
                removeNode.Prev.Next = removeNode.Next;
                removeNode.Next.Prev = removeNode.Prev;
            }

            removeNode = null;
        }

        public DoubleLinkedListNode<T> GetNode(int index)
        {
            if (head == null) return null;

            int cnt = 0;
            var current = head;
            while (cnt < index)
            {
                // (index)지점까지 이동한다.
                current = current.Next;
                if (current == head)
                {
                    return null;
                }
            }

            return current;
        }

        public int Count()
        {
            int cnt = 0;
            var current = head;

            // 데이터가 아예 없으면 0
            if (head == null) return 0;

            // 데이터가 한개밖에 없으므로
            if (current.Next == head) return 1;

            while (current != head)
            {
                current = current.Next;
                cnt++;
            }

            return cnt;
        }

        // 원형 연결 리스트인지 체크하는 방법 - 한 바퀴 돌려서 Head가 나오면 원형, 아니면 원형이 아님
        public bool IsCircular(DoubleLinkedListNode<T> node)
        {
            if (head == null) return true;

            var current = head;
            // 연결이 안되어있으면 결국 Null이 나올 거니까
            while (current != null)
            {
                current = current.Next;
                if (current == head) return true;
            }
            
            return false;
        }


    }
}
