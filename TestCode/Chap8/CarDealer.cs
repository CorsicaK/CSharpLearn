using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap8
{
    public class CarInfoEventArgs : EventArgs
    {
        public CarInfoEventArgs(string car)
        {
            this.Car = car;
        }
        public string Car
        {
            get;
            private set;
        }
    }
    /// <summary>
    /// 事件发布程序
    /// </summary>

    public class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;
        public void newCar(string car)
        {
            Console.WriteLine("CarDealer,new car {0}", car);
            RaiseNewcarInfo(car);
        }

        protected virtual void RaiseNewcarInfo(string car)
        {
            EventHandler<CarInfoEventArgs> newCarInfo = NewCarInfo;
            if (newCarInfo != null)
            {
                newCarInfo(this, new CarInfoEventArgs(car));
            }
        }
    }
}
