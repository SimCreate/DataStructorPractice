﻿using System;
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
            A[pIndex] = 0;
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

    class DynamicArray
    {

    }

}
