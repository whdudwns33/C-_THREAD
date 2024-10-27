using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 스레딩01.Test03
{
    public class Example
    {
        public static void Main()
        {
            // Supply the state information required by the task.
            // 생성자 선언
            ThreadWithState tws = new ThreadWithState(
                "This report displays the number {0}.",
                42,
                new ExampleCallback(ResultCallback)
                );

            Thread t = new Thread(new ThreadStart(tws.ThreadProc));
            t.Start();
            Console.WriteLine("Main thread does some work, then waits.");
            t.Join();
            Console.WriteLine(
                "Independent task has completed; main thread ends.");
        }

        // The callback method must match the signature of the
        // callback delegate.
        // int 형에 void 메서드 : 대리자 서명된 함수형식
        public static void ResultCallback(int lineCount)
        {
            Console.WriteLine(
                "Independent task printed {0} lines.", lineCount);
        }


    }
}