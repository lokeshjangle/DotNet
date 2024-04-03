namespace Payroll
{
    //SalesPerson is a derived class of Employee (base) class
    class SalesPerson : Employee
    {
        //automatic (compiler generated) property
        public double Sales { get; set; }

        public SalesPerson(int h, float r, double s) : base(h, r)
        {
            Sales = s;
        }

        //overriding a virtual method of base class requires 'override' keyword
        public override double Income()
        {
            double salary = base.Income();
            if(Sales >= 20000)
                salary += 0.05 * Sales;
            return salary;
        }
    }
}