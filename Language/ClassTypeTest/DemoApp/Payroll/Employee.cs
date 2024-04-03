namespace Payroll
{
    class Employee
    {
        private int hours;
        private float rate;

        //parameterized constructor
        public Employee(int h, float r)
        {
            hours = h;
            rate = r;
        }

        //parameterless constructor
        public Employee() : this(0, 50) {}

        //a 'property' provides access to data within an instance through
        //a syntax similar to accessing a field of that isntance
        public int Hours
        {
            get
            {
                return hours;
            }

            set
            {
                hours = value;
            }
        }

        public float HourlyRate
        {
            get { return rate; }
            set { rate = value; }
        }

        //only a method declared with 'virtual' keyword can be
        //overridden in a derived class
        public virtual double Income()
        {
            double salary = hours * rate;
            int ot = hours - 180;
            if(ot > 0)
                salary += 50 * ot;
            return salary;
        }

    }
}

