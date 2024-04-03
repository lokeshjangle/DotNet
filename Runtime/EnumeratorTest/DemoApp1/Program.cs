SimpleStack<string> a = new();
a.Push("Monday");
a.Push("Tuesday");
a.Push("Wednesday");
a.Push("Thursday");
a.Push("Friday");
for(var e = a.GetEnumerator(); e.MoveNext();)
    Console.WriteLine(e.Current);
Console.WriteLine("-------------------------");
/*
while(!a.Empty())
    Console.WriteLine(a.Pop());
*/
var b = new SimpleStack<double>();
b.Push(32.1);
b.Push(53.2);
b.Push(65.3);
b.Push(21.4);
b[2] = 57.2; //using indexer
foreach(double d in b)
    Console.WriteLine(d);
