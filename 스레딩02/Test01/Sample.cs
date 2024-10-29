using System;
using System.ComponentModel;
using System.Threading;

namespace 스레딩02.Test01
{
    internal class Sample
    {
        public static void Main()
        {
            // 파티 플레이어인 전사, 마법사는 상대방인 거인을 공격하고, 
            // 단일 플레이터인 거인은 한번 공격할 때, 전사나 마법사 둘 중 하나만 공격

            // 전사
            Charactor charactor1 = new Charactor("전사", 50, 5, 1000);
            // 마법사
            Charactor charactor2 = new Charactor("마법사", 20, 15, 1200);
            // 거인
            Charactor charactor3 = new Charactor("거인", 80, 10, 1500);

            // 전투 스레드 시작
            Thread thread1 = new Thread(() => charactor1.StartFight(charactor3));
            Thread thread2 = new Thread(() => charactor2.StartFight(charactor3));
            Thread thread3 = new Thread(() => charactor3.StartFight(charactor1));
            Thread thread4 = new Thread(() => charactor3.StartFight(charactor1));

            thread1.Start();
            thread2.Start();

            // 스레드가 종료될 때까지 기다립니다.
            thread1.Join();
            thread2.Join();

            Console.WriteLine("전투 종료!");
        }
    }

    public class Charactor
    {
        private string _name;               // 캐릭터 이름
        private int _health;                // 체력
        private int _attackPower;           // 공격력
        private int _attackSpeed;           // 공격속도 (ms)
        private bool _isAlive = true;       // 생존 여부 

        public Charactor(string name, int health, int attackPower, int attackSpeed)
        {
            _name = name;
            _health = health;
            _attackPower = attackPower;
            _attackSpeed = attackSpeed;
        }

        // 상대방을 공격하는 메서드
        public void StartFight(Charactor opponent)
        {
            while (_isAlive && opponent._isAlive)
            {
                Thread.Sleep(_attackSpeed);
                Attack(opponent);
            }
        }

        // 단일 대상 공격
        private void Attack(Charactor opponent)
        {
            if (!_isAlive || !opponent._isAlive)
                return;

            // 상대방에게 데미지를 입힘
            Console.WriteLine($"{_name}이(가) {opponent._name}을(를) 공격하여 {opponent._name}의 체력이 {opponent._health}에서 {opponent._health - _attackPower}로 감소했습니다.");
            opponent._health -= _attackPower;

            // 상대방이 체력이 0 이하가 되면 사망 처리
            if (opponent._health <= 0)
            {
                opponent._isAlive = false;
                Console.WriteLine($"{opponent._name}이(가) 쓰러졌습니다!");
            }
        }
        
        // 다수 대상 공격
        private void Attack(List<Charactor> opponentList)
        {
            // 자신의 생존 여부
            if (!_isAlive) return;


            

            // 상대방에게 데미지를 입힘
            foreach (Charactor opponent in opponentList)
            {
                // 상대방들 중 하나의 적만 공격
                // 상대방의 체력이 0보다 커야되고(생존 상태) 확률적으로 공격
                // 상대방이 생존 상태일 때만 공격 수행
                if (opponent._isAlive)
                {
                    Console.WriteLine($"{_name}이(가) {opponent._name}을(를) 공격하여 {opponent._name}의 체력이 {opponent._health}에서 {opponent._health - _attackPower}로 감소했습니다.");
                    opponent._health -= _attackPower;

                    // 상대방이 체력이 0 이하가 되면 사망 처리
                    if (opponent._health <= 0)
                    {
                        opponent._isAlive = false;
                        Console.WriteLine($"{opponent._name}이(가) 쓰러졌습니다!");
                    }
                }
            }
        }
    }
}
