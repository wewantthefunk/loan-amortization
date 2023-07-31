public class CalcPayment {
    private float _principle;
    private float _interest;
    private float _years;

    public CalcPayment(float principle, int years, float interest) {
        _principle = principle;
        _interest = interest;
        _years = Convert.ToSingle(years);
    }

    public LoanPayment[] Amortize() {
        List<LoanPayment> result = new List<LoanPayment>();

        float principle = _principle;

        result.Add(Calc(principle, 1));

        for (int x = 1; x < _years * 12; x++) {            
            principle = result[result.Count - 1].EndingLoanBalance;
            LoanPayment lp = new LoanPayment(x + 1, result[0].MonthlyPayment, principle, _interest);
            result.Add(lp);
        }

        return result.ToArray();
    }

    public LoanPayment Calc() {
        return Calc(_principle, 1);
    }

    public LoanPayment Calc(float principle, int paymentNum) {
        float months = _years * 12;

        float monthlyInterest = _interest / (12 * 100);

        double x = Convert.ToDouble(1 + monthlyInterest);
        double y = Convert.ToDouble(-1 * months);

        float monthly = Convert.ToSingle(Math.Round(principle * (monthlyInterest / (1 - Convert.ToSingle(Math.Pow(x, y)))), 2));

        return new LoanPayment(paymentNum, monthly, principle, _interest);
    }

    public override String ToString() {
        return "hello";
    }
}