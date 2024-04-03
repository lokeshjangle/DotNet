using Taxation;

class Program
{
    //nested class can only refer to static members of outer class
    class Auditor : IDisposable
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
        ITaxPayer t = name == "jack" ? new Supervisor { Subordinates = count } : new Worker { Jobs = count };
        //if a variable whose type inherits from IDisposable is declared 
        //within a 'using' statement block then the Dispose() method is
        //automatically called on the variable at the end of that block
        using(Auditor a = new Auditor())
        {
            a.Audit(name, t);
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
