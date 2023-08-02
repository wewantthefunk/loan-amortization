public class LoanLife {
    private LoanPayment[]? _payments;
    private float _totalLoanCost = 0f;
    private float _loanAmount = 0f;
    private static String SEPERATOR = "/";
    private static int MONTHS_IN_YEAR_CHECK = 11;

    public LoanLife(LoanPayment[] payments) {
        Payments = payments;

        if (Payments.Length > 0) {
            TotalLoanCost = Payments[0].MonthlyPayment * Payments.Length;
            LoanAmount = Payments[0].BeginningLoanBalance;
        }
    }

    public float[] InterestByYear() {
        List<float> result = new List<float>();

        float temp = 0f;
        int lastMonth = Payments.Length - 1;

        for (int x = 0; x < Payments.Length; x++) {
            temp += Payments[x].InterestPayment;
            if (x > 0 && (x % MONTHS_IN_YEAR_CHECK == 0 || x == lastMonth)) {
                result.Add(temp);
                temp = 0f;
            }
        }

        return result.ToArray();
    }

    public LoanPayment[] Payments {
        get {
            if (_payments == null) {
                _payments = new LoanPayment[0];
            }
            return _payments;
        }
        private set {
            if (value == null) {
                value = new LoanPayment[0];
            }
            _payments = value;
        }
    }

    public float TotalLoanCost {
        get {
            return _totalLoanCost;
        }
        private set {
            _totalLoanCost = value;
        }
    }

    public float TotalInterest {
        get {
            return TotalLoanCost - LoanAmount;
        }
    }

    public float LoanAmount {
        get {
            return _loanAmount;
        }
        private set {
            _loanAmount = value;
        }
    }

    public override string ToString()
    {
        return TotalLoanCost + SEPERATOR + TotalInterest + SEPERATOR + LoanAmount;
    }

    public String ToJSON() {
        return "{\"totalLoanCost\":" + TotalLoanCost + ",\"totalInterest\":" + TotalInterest + ",\"loanAmount\":" + LoanAmount + "}";
    }
}