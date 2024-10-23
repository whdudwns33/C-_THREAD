using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 스레딩01.Test02
{
    public class Example
    {
        public static void Main()
        {
            int stop = 0;
            while (stop == 0)
            {
                Console.WriteLine("계속하려면 1번을 입력 : ");
                string? isGoing = Console.ReadLine();
                if(isGoing == "1")
                {
                    // Supply the state information required by the task.
                    ThreadWithState tws = new ThreadWithState(
                        "This report displays the number {0}.", 42);

                    // Create a thread to execute the task, and then
                    // start the thread.
                    Thread t = new Thread(new ThreadStart(tws.ThreadProc));
                    t.Start();
                    Console.WriteLine("메인 스레드 작동중. Main thread does some work, then waits.");
                    // 
                    t.Join();
                    Console.WriteLine(
                        "타스크 완료. Independent task has completed; main thread ends.");
                }
                else
                {
                    Console.WriteLine("종료");
                    stop = 1;
                }
                
            }
        }
    }
}
