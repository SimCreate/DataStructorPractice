using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 자료구조 : 데이터를 효율적으로 엑세스하고 조작할 수 있도록 데이터의 구조를 만들어 데이터를 저장하고 관리하는 것
 *           -> 각 자료구조마다 각 장단점이 있으므로 자신의 목적에 맞게 알맞게 선택해야 한다.
 * 
 * 자료구조의 종류
 *  - 단순구조 : 정수, 실수, 문자, Boolean
 *  - 신형구조 : 배열, IList<T>, Stack, Quenu 등이 해당됨. (1:1)
 *  - 비선형구조 : Tree, Graphic (1 : n / n : n)
 *  - 파일구조 : 순차파일, 색인파일, 직접파일
 *  ※ 구현방법에 따라 선형구조나 비선형구조가 될 수 있는 Hashtable에 대해서도 알아 볼 것...
*/

/* 
 * 배열 - 배열 인덱스 사용시 각 배열요소를 직접 엑세스 할 수 있다
 *     -> A[0] 엑세스 시간 = A[99] 엑세스 시간
 * 
*/

namespace DataStructor_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Read();
        }
    }

    class DefaultArray
    {
        int[] A;

        public DefaultArray()
        {
            // 정적배열(StaticArray) = 처음 지정한 고정 크기를 계속 유지하는 배열
            A = new int[10];
        }

        // 인터페이스로 대체 예정
        public void Add(int pValue, int pIndex)
        {
            A[pIndex] = pValue;
        }

        public void Del(int pIndex)
        {
            A[pIndex] = 0; // default(int)
        }
    }

    class JaggedArray
    {
        int[][] A = new int[3][];

        // 가변 배열 (Jagged Array) = 각 차원마다 다른 배열 크기를 가져야 하는 경우 사용
        public JaggedArray()
        {
            A[0] = new int[2];
            A[1] = new int[6];
            A[2] = new int[3];
        }

    }

    // 동적 배열
    // 동적 배열을 만드는 가장 간단한 방식 :  새로운 요소가 추가될 때마다 배열 크기를 하나씩 늘려가는 것.

    class DynamicArray_A
    {
        private object[] arr = new object[0];

        public void Add(object pElement)
        {
            // 해당 클래스 전역변수 배열보다 한 자리 크게 만든다.
            var temp = new object[arr.Length + 1];

            // 임시 배열 변수에 모든 요소들을 복사합니다.
            for (int i = 0; i < arr.Length; i++)
            {
                temp[i] = arr[i];
            }
            arr = temp;

            // 마지막 요소에 새 배열요소를 추가하는 것이다.
            arr[arr.Length - 1] = pElement;
        }

        // 이러한 방식은 하나의 요소가 추가될 때마다 전체의 기존 배열을 복사해야 하기 때문에, 비효율적임.
    }

    // 동적배열 2
    // 앞서 적은 방식에 비해 훨씬 효율적임. 왜인지는 나중에 생각해보자 - 불완전공부밥
    // 배열 확장시 2배씩 확장하는 것.

    class DynamicArray_B
    {
        private object[] arr;
        private const int GROWTH_FACTOR = 2;    // 성장인자 : .Net은 기본적으로 2배를 사용함.

        public int Count { get; private set; }
        public int Capacity
        {
            get { return arr.Length; }
        }

        public DynamicArray_B(int pCapacity = 16)
        {
            arr = new object[pCapacity];
            Count = 0;
        }

        public void Add(object pElement)
        {
            // 배열이 꽉 찼을 때 확장
            if (Count >= Capacity)
            {
                int newSize = Capacity * GROWTH_FACTOR;
                var temp = new object[newSize];

                for (int i = 0; i < arr.Length; i++)
                {
                    temp[i] = arr[i];
                }

                arr = temp;
            }

            arr[Count] = pElement;
            Count++;
        }

        public Object Get(int pindex)
        {
            if (pindex > Capacity - 1)
            {
                throw new ApplicationException("Element Not Found");
            }
            return arr[pindex];
        }
    }

    // 원형 배열
    // 고정된 크기의 배열을 양 끝이 연결된 것처럼 사용할 수 있게 한 자료구조
    // 배열의 마지막 요소에 도착하면 다음 배열요소는 첫번째 요소로 순환하는 구조...
    class CircularArray
    {
        private char[] A;

        public CircularArray(string pCircularString)
        {
            A = pCircularString.ToCharArray();
        }

        public void ShowAllValue(int pIndex)
        {
            for (int i = 0; i < A.Length; i++)
            {
                // C# 에서는 Mod 연산자인 %를 통해 처리한다.
                Console.WriteLine(A[(i + pIndex) % A.Length]);
            }
        }
    }

    // 참고문헌
    // 알고리즘의 수행시간을 대략적으로 나타내는 방법 : 점근 표기법
    // 1. Big O 표기법 : 알고리즘이 최악으로 실행될 경우의 성능
    // 2. Big Omega : 알고리즘이 최상으로 실행될 경우의 성능
    // 3. Big Theta : 알고리즘 성능의 상한과 하한을 동시에 나타내는 방법
}