float principle = Convert.ToSingle(args[0]);
float rate = Convert.ToSingle(args[1]);
int years = Convert.ToInt32(args[2]);

CalcPayment cp = new CalcPayment(principle,years,rate);

LoanPayment[] payments = cp.Amortize();

foreach(LoanPayment payment in payments)
    Console.WriteLine(payment);

LoanLife life = new LoanLife(payments);

float[] interestByYear = life.InterestByYear();
float ti = 0f;
foreach(float year in interestByYear) {
    ti += year;
    Console.WriteLine(year);
}

Console.WriteLine(ti);

Console.WriteLine(life.TotalLoanCost);

Console.WriteLine(life.TotalLoanCost - principle);
