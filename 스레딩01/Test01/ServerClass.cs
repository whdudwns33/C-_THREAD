using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 스레딩01.Test01
{
    public class ServerClass
    {
        // The method that will be called when the thread is started.
        // 스레드 실행 메서드
        public void InstanceMethod()
        {
            Console.WriteLine(
                "인스턴스 메서드 실행.");

            // Pause for a moment to provide a delay to make
            // threads more apparent.
            // 스레드 일시 정지 -> 텀을 주기 위함
            Thread.Sleep(3000);
            Console.WriteLine(
                "3초 일시 정지 후, 인스턴스 메서드 실행.");
        }

        public static void StaticMethod()
        {
            Console.WriteLine(
                "스태틱 메서드 실행.");

            // Pause for a moment to provide a delay to make
            // threads more apparent.
            Thread.Sleep(5000);
            Console.WriteLine(
                "일시정지 5초 후, 스태틱 메서드 실행.");
        }
    }
}
