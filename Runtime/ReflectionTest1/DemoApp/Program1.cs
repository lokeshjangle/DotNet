﻿using Finance;

double p = double.Parse(args[0]);
int m = 10;
for(int n = 1; n <= m; ++n)
{
    //pattern matching switch
    double r = args[1] switch 
    {
        "EducationLoan" => new EducationLoan().Common(p, n),
        "PersonalLoan" => new PersonalLoan().Common(p, n),
        "HomeLoan" => new HomeLoan().Common(p, n),
        _ => throw new ArgumentException("Invalid loan policy")
    };
    double emi = Loans.GetMonthlyInstallment(p, n, r);
    Console.WriteLine("{0, -6}{1, 16:0.00}", n, emi);
}
