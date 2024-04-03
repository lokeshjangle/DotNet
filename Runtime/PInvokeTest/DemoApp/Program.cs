long m = long.Parse(args[0]);
long n = long.Parse(args[1]);
Console.WriteLine("Number of Primes = {0}", Legacy.CountPrimes(m, n));
long[] primes = Legacy.SelectPrimes(m, 5, n - m < 100);
Console.WriteLine("First five selected primes");
foreach(long prime in primes)
    Console.WriteLine(prime);

