﻿class Program
{
    class JointAccount
    {
        public int Balance { get; private set; }

        public bool Withdraw(int amount)
        {
            bool success = false;
            //lock the monitor assigned to the specified object
            Monitor.Enter(this);
            try
            {
                if(Balance >= amount)
                {
                    Balance = Activity.Perform(Balance, amount);
                    success = true;
                }
            }
            finally
            {
                //unlock the monitor assigned to the specified object
                Monitor.Exit(this);
            }
            return success;
        }

        public void Deposit(int amount)
        {
            lock(this)
            {
                Balance += amount;
            }
        }
    }

    static void Main(string[] args)
    {
        var acc = new JointAccount();
        acc.Deposit(10000);
        Console.WriteLine("Joint-Account opened for Jack and Jill.");
        Console.WriteLine($"Initial Balance: {acc.Balance}");
        Thread child1 = new Thread(() => 
        {
            Console.WriteLine("Jack is withdrawing 6000...");
            if(!acc.Withdraw(6000))
                Console.WriteLine("Jack's withdrawal failed!"); 
            else
                Console.WriteLine("Jack's Withdrawal Successful");            
        });
        
        Thread child2 = new Thread(() => 
        {
            Console.WriteLine("Jill is withdrawing 7000...");
            if(!acc.Withdraw(7000))
                Console.WriteLine("Jill's withdrawal failed!");
             else
                Console.WriteLine("Jill's Withdrawal Successful"); 
        });
        child1.Start();
        child2.Start();
        
        child1.Join(); //current (main) thread waits for child1 to exit
        child2.Join();
        Console.WriteLine($"Final Balance : {acc.Balance}");
    }
}