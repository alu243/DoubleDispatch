using System;

namespace DoubleDispatch.VisitorPattern
{
    class Visitor
    {
        public static void Run(string[] args)
        {
            // Single Dispatch
            Vehicle vehicle = new Vehicle();
            Vehicle benz = new Benz();

            Sales sales = new Sales();
            Console.WriteLine("Visitor Single Dispatch Demo:");
            Console.WriteLine($"Sales: The rate for common vehicle is: {sales.GetDiscountRate(vehicle)}");
            Console.WriteLine($"Sales: The rate for benz is: {sales.GetDiscountRate(benz)}");

            // Double Dispatch (fail)
            SalesManager salesManager = new SalesManager();
            Console.WriteLine("Visitor Double Dispatch Demo(失敗的例子):");
            Console.WriteLine($"SalesManager: The rate for common vehicle is: {salesManager.GetDiscountRate(vehicle)}");
            Console.WriteLine($"SalesManager: The rate for benz is: {salesManager.GetDiscountRate(benz)}");
        }
    }


    public class BaseVehicle // Visitor
    {
        public virtual double GetBaseDisountRate(Sales sales) { return 0; }
        public virtual double GetBaseDisountRate(SalesManager sales) { return 0; }
    };

    public class Vehicle : BaseVehicle // ConcreteVisitor
    {
        public override double GetBaseDisountRate(Sales sales) { return 0.03; }
        public override double GetBaseDisountRate(SalesManager sales) { return 0.03; }
    }

    public class Benz : Vehicle // ConcreteVisitor
    {
        public override double GetBaseDisountRate(Sales sales) { return 0.06; }
        public override double GetBaseDisountRate(SalesManager sales) { return 0.06 * 1.1; }
    }

    public class BaseSales
    {
        public virtual double GetDiscountRate(BaseVehicle vehicle) { return 0; }
    }

    public class Sales : BaseSales
    {
        public override double GetDiscountRate(BaseVehicle vehicle) { return vehicle.GetBaseDisountRate(this); }
    }

    public class SalesManager : BaseSales
    {
        public override double GetDiscountRate(BaseVehicle vehicle) { return vehicle.GetBaseDisountRate(this); }
    }

}
