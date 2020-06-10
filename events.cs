using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6 {

    class MyEventArgs : EventArgs {
        public int speed { set; get; }

        public MyEventArgs(int speed) {
            this.speed = speed;
        }
    }

    class Driver {
        public event EventHandler<MyEventArgs> speed_overflow;

        public void Speed_Overflow_Checker(int speed) {
            if (PoliceMan.Max_speed < speed) {
                MyEventArgs args = new MyEventArgs(speed);
                speed_overflow?.Invoke(this, args);
            }
        }


    }

    class PoliceMan {
        public static readonly int Max_speed = 50;

        public void Straf(object sendre, MyEventArgs e) {
            if (e.speed - Max_speed <= 10) {
                Console.WriteLine("Водитель превысил скорость на " + (e.speed - Max_speed) + "км/ч штраф - 100грн.");
            }
            else if (e.speed - Max_speed <= 20) {
                Console.WriteLine("Водитель превысил скорость на " + (e.speed - Max_speed) + "км/ч штраф - 200грн.");
            }
            else {
                Console.WriteLine("Водитель превысил скорость на " + (e.speed - Max_speed) + "км/ч штраф - 500грн.");
            }

        }
    }

    class Program {
        static void Main(string[] args) {
            Driver driver1 = new Driver();
            PoliceMan police = new PoliceMan();

            driver1.speed_overflow += police.Straf;
            driver1.Speed_Overflow_Checker(100);
            driver1.Speed_Overflow_Checker(20);
        }
    }
}
