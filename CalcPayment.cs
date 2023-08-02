public class CalcPayment {
    private float _principle;
    private float _interestRate;
    private float _years;
    private static int MONTHS_IN_YEAR = 12;
    private int DECIMAL_OFFSET = 100;
    private String SEPERATOR = "/";

    public CalcPayment(float principle, int years, float interestRate) {
        Principle = principle;
        InterestRate = interestRate;
        Years = Convert.ToSingle(years);
    }

    public LoanPayment[] Amortize() {
        List<LoanPayment> result = new List<LoanPayment>();

        float principle = Principle;

        result.Add(Calc(principle, 1));

        for (int x = 1; x < _years * 12; x++) {            
            principle = result[result.Count - 1].EndingLoanBalance;
            LoanPayment lp = new LoanPayment(x + 1, result[0].MonthlyPayment, principle, InterestRate);
            result.Add(lp);
        }

        return result.ToArray();
    }

    public LoanPayment Calc() {
        return Calc(Principle, 1);
    }

    public LoanPayment Calc(float principle, int paymentNum) {
        float months = Years * 12;

        float monthlyInterest = InterestRate / (MONTHS_IN_YEAR * DECIMAL_OFFSET);

        double x = Convert.ToDouble(1 + monthlyInterest);
        double y = Convert.ToDouble(-1 * months);

        float monthly = Convert.ToSingle(Math.Round(principle * (monthlyInterest / (1 - Convert.ToSingle(Math.Pow(x, y)))), 2));

        return new LoanPayment(paymentNum, monthly, principle, InterestRate);
    }

    public float Principle {
        get { return _principle;}
        private set { _principle = value; }
    }

    public float InterestRate {
        get { return _interestRate;}
        private set { _interestRate = value; }
    }

    public float Years {
        get { return _years; }
        private set { _years = value; }
    }

    public override String ToString() {
        return Principle + SEPERATOR + InterestRate + SEPERATOR + Years;
    }

    public String ToJSON() {
        return "{\"principle\":" + Principle + ",\"interestRate\":" + InterestRate + "\"years\":" + Years + "}";
    }
}