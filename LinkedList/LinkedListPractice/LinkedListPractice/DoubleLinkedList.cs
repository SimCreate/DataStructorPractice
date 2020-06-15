using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPractice
{
    // 이중 연결 리스트 : 리스트 안의 노드가 이전 노드와 다음노드를 가리키는 포인터를 가지고 있어 양방향으로 탐색이 가능한 자료구조.

    public class DoubleLinkedListNode<T>
    {

        // 리스트의 처음을 가리키는 HEAD 필드가 필요
        // 경우에 따라서는 마지막 노드를 가리키는 Tail 필드도 필요

        public T Data { get; set; }

        public DoubleLinkedListNode<T> Prev { get; set; }

        public DoubleLinkedListNode<T> Next { get; set; }

        public DoubleLinkedListNode(T Data) : this(Data, null, null)
        {

        }

        public DoubleLinkedListNode(T Data, DoubleLinkedListNode<T> prev, DoubleLinkedListNode<T> next)
        {
            this.Data = Data;
            this.Prev = prev;
            this.Next = next;
        }
    }

    public class DoubleLinkedList<T>
    {
        private DoubleLinkedListNode<T> head;

        public void Add (DoubleLinkedListNode<T> newNode)
        {
            // 첫 데이터를 경우
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;

                // DoubleLinkedList의 마지막(Tail) 까지 이동

                while (current != null && current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
                newNode.Next = null;        // 마지막이니까
                newNode.Prev = current;
            }
        }

        public void AddAfter(DoubleLinkedListNode<T> current, DoubleLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            // Current : 1
            // NewNode ; 2
            // 기존 Next ; 3 - 라고 생각했을 떄 

            newNode.Next = current.Next;        // 2과 3를 연결
            current.Next.Prev = newNode;        // 3의 이전 숫자는 2
            newNode.Prev = current;             // 2의 이전 숫자는 1
            current.Next = newNode;             // 1과 2를 연결
        }

        public void Remove(DoubleLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            // 삭제 노드가 첫 노드라면

            if (removeNode == head)
            {
                // 첫 노드라고 모든 데이터를 삭제하면 안되니까...
                head = head.Next;

                if (head != null)
                {
                    // 이전 데이터를 삭제했으므로 포인터 또한 삭제
                    head.Prev = null;
                }
            }
            // 첫 노드가 아니면, Prev노드와 Next노드를 연결
            // 양 끝 포인터 변경 후 Data 삭제
            else
            {
                removeNode.Prev.Next = removeNode.Next;

                if (removeNode.Next != null)
                {
                    removeNode.Next.Prev = removeNode.Prev;
                }

                removeNode = null;
            }
        }


        public DoubleLinkedListNode<T> GetNode(int index)
        {
            var current = head;

            for (int i = 0; i < index && current != null; i++ )
            {
                // 연결리스트의 (Index)번까지 이동
                current = current.Next;
            }

            return current;
        }

        public int Count()
        {
            int cnt = 0;

            var current = head;
            // 계속 Next하면 결국 current.Next가 Null인 지점까지 이동하므로
            while (current != null)
            {
                cnt++;
                current = current.Next;
            }

            return cnt;
        }

    }
}
