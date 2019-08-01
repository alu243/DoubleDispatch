// 參考來源
//https://www.cnblogs.com/loveis715/p/4423464.html
using System;

namespace DoubleDispatch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Single Dispatch
            Vehicle vehicle = new Vehicle();
            Vehicle benz = new Benz();

            Sales sales = new Sales();
            Console.WriteLine("Single Dispatch Demo:");
            Console.WriteLine($"Sales: The rate for common vehicle is: {sales.GetDiscountRate(vehicle)}");
            Console.WriteLine($"Sales: The rate for benz is: {sales.GetDiscountRate(benz)}");


            // Double Dispatch (fail)
            SalesManager salesManager = new SalesManager();
            Console.WriteLine("Double Dispatch Demo(失敗的例子):");
            Console.WriteLine($"SalesManager: The rate for common vehicle is: {salesManager.GetDiscountRate(vehicle)}");
            Console.WriteLine($"SalesManager: The rate for benz is: {salesManager.GetDiscountRate(benz)}");

            // Double Dispatch (success)
            SalesManager salesManager2 = new SalesManager();
            Console.WriteLine("Double Dispatch Demo(成功的例子):");
            Console.WriteLine($"SalesManager: The rate for common vehicle is: {salesManager2.GetDiscountRate((dynamic)vehicle)}");
            Console.WriteLine($"SalesManager: The rate for benz is: {salesManager2.GetDiscountRate((dynamic)benz)}");

            VisitorPattern.Visitor.Run(args);

        }
    }

    public class Vehicle
    {
        public virtual double GetBaseDiscountRate()
        {
            return 0.03;
        }
    }

    public class Benz : Vehicle
    {
        public override double GetBaseDiscountRate()
        {
            return 0.06;
        }
    }

    public class Sales
    {
        public virtual double GetDiscountRate(Vehicle vehicle)
        {
            return vehicle.GetBaseDiscountRate();
        }
        public virtual double GetDiscountRate(Benz benz)
        {
            return benz.GetBaseDiscountRate();
        }
    }

    public class SalesManager : Sales
    {
        public override double GetDiscountRate(Vehicle vehicle)
        {
            return vehicle.GetBaseDiscountRate();
        }
        public override double GetDiscountRate(Benz benz)
        {
            return benz.GetBaseDiscountRate() * 1.1;
        }
    }

}
