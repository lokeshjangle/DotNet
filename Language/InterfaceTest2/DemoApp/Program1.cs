using Taxation;

class Program
{
    //nested class can only refer to static members of outer class
    class Auditor
    {
        public Auditor()
        {
            Console.WriteLine("Auditor - acquiring resources");
        }

        public void Audit(string id, ITaxPayer info)
        {
            if(id.Length < 4)
                throw new ArgumentException("Invalid ID");
            decimal payment = info.IncomeTax() + 500;
            Console.WriteLine("Total Tax Payment: {0}", payment);
        }

        public void Dispose()
        {
            Console.WriteLine("Auditor - releasing resources");
        }
    }


    static void Process(string name, int count)
    {
        //boxing will be required to convert struct type to interface type
        ITaxPayer t = name == "jack" ? new Supervisor { Subordinates = count } : new Worker { Jobs = count };
        Auditor a = new Auditor();
        try
        {
            a.Audit(name, t);
        }
        finally
        {
            a.Dispose();
        }

    }

    static void Main(string[] args)
    {
        try
        {
            string m = args[0].ToLower();
            int n = int.Parse(args[1]);
            Process(m, n);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
