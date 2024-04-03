using System.Runtime.InteropServices;

static class Legacy
{
    [DllImport("primes", EntryPoint = "primes_count")]
    public extern static int CountPrimes(long first, long last);

    struct PrimesRange
    {
        public long Start;
        public int Count;
    }

    //In C# runtime non-verifiable types like pointers can only be used
    //in unsafe context (scope marhed with 'unsafe' keyword) which is only
    //allowed only if code is compiled with /unsafe (see DemoApp.csproj)
    [DllImport("primes", EntryPoint = "primes_select")]
    private extern static unsafe long SelectPrimes(PrimesRange* range, long* selected, delegate*<long, int> selector);

    private static int IsFavorite(long p) => (p - 1) % 4 == 0 ? 1 : 0;

    public static unsafe long[] SelectPrimes(long start, int count, bool all)
    {
        PrimesRange range = new PrimesRange { Start = start, Count = count };
        PrimesRange* pRange = &range; //taking address of a value on stack
        long[] selected = new long[count];
        //to take an address of a value within an object/array on the heap
        //its reference must be pinned using fixed statement block so that
        //it is not relocated during garbage-collection
        fixed(long* pSelected = &selected[0])
        {
            SelectPrimes(pRange, pSelected, all ? null : &IsFavorite);
        }
        return selected;
    }
}