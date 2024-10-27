using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 스레딩01.Test02
{
    //public class Example
    //{
    //    public static void Main()
    //    {
    //        // Main 스레드와 t 스레드 실행 예제
    //        // 메인 스레드가 실행되고 새로운 스레드가 실행되면 해당 실행 결과는 비동기 적으로 실행될 것
    //        // 해당 내용 확인해보자
    //
    //        int stop = 0;
    //        while (stop == 0)
    //        {
    //            Console.WriteLine("계속하려면 1번을 입력 : ");
    //            string? isGoing = Console.ReadLine();
    //            if(isGoing == "1")
    //            {
    //                // Supply the state information required by the task.
    //                ThreadWithState tws = new ThreadWithState(
    //                    "This report displays the number {0}.", 42);
    //
    //                // Create a thread to execute the task, and then
    //                // start the thread.
    //                Thread t = new Thread(new ThreadStart(tws.ThreadProc));
    //                // 새로운 스레드 시작 
    //                t.Start();
    //                Console.WriteLine("메인 스레드 작동중. Main thread does some work, then waits.");
    //                // Join() 메서드는 스레드가 종료될 때까지 메인 스레드를 대기 시키는 메서드
    //                // 따라서, 메인 스레드가 실행되다가 Join 스레드를 만나면 대기, 
    //                // 이후, 스레드의 작동이 완료되면 종료
    //                // 하지만, 매개변수로 시간을 삽입하면, 메인스래드는 해당 시간만큼만 대기하고 다시 메인 실행
    //                // ex Join(2000)
    //                t.Join();
    //
    //                Console.WriteLine(
    //                    "메인 및 . Independent task has completed; main thread ends.");
    //            }
    //            else
    //            {
    //                Console.WriteLine("종료");
    //                stop = 1;
    //            }
    //            
    //        }
    //    }
    //}
}
