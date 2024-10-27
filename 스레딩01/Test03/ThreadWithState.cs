using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 스레딩01.Test03
{
    // 대리자(delegate) 정의
    // void 반환에 int형을 매개변수로 하는 메서드 서명(반환타입, 매개변수로 구성하여 정의하는 형식에 부합하는 어떠한 메서드던지 사용가능. 생성자와 비슷하지만, 메서드를 매개변수처럼 쓰는 느낌)
    public delegate void ExampleCallback(int lineCount);

    public class ThreadWithState
    {
        // State information used in the task.
        private string boilerplate;
        private int numberValue;

        // Delegate used to execute the callback method when the
        // task is complete.
        // 콜백DELEGATE(대리자) field 선언
        private ExampleCallback callback;

        // The constructor obtains the state information and the
        // callback delegate.
        // 대리자를 포함하는 생성자 선언
        public ThreadWithState(string text, int number,
            // 스레드 생성자에 선언된 대리자 
            ExampleCallback callbackDelegate)
        {
            boilerplate = text;
            numberValue = number;
            // feild 선언된 대리자 
            callback = callbackDelegate;
        }

        // The thread procedure performs the task, such as
        // formatting and printing a document, and then invokes
        // the callback delegate with the number of lines printed.
        public void ThreadProc()
        {
            Console.WriteLine("스레드 함수 ThreadProc 실행");
            Console.WriteLine(boilerplate, numberValue);
            if (callback != null)
            {
                Console.WriteLine("callback 존재", callback);
                // 해당 함수에는 매개변수를 1로 선언
                // 대리자 자리에 쓰이는 함수의 매개변수는 1로 전달
                callback(1);
            }
            else
            {
                Console.WriteLine("callback 미존재");
            }
        }
    }
}
