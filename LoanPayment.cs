public class LoanPayment {
    private int _paymentNum;
    private float _monthlyPayment;
    private float _beginningLoanBalance;
    private float _interestRate;
    private float _principlePayment;
    private float _interestPayment;
    private float _endingLoanBalance;
    
    private static String SEPERATOR = "/";
    private static int MONTHS_IN_YEAR = 12;

    private int DECIMAL_OFFSET = 100;

    public LoanPayment(int paymentNum, float monthlyPayment, float beginningLoanBalance, float interestRate) {
        PaymentNum = paymentNum;
        MonthlyPayment = monthlyPayment;
        BeginningLoanBalance = beginningLoanBalance;
        InterestRate = interestRate;

        PrinciplePayment = MonthlyPayment - (BeginningLoanBalance * (InterestRate / (MONTHS_IN_YEAR * DECIMAL_OFFSET)));

        InterestPayment = MonthlyPayment - PrinciplePayment;

        EndingLoanBalance = BeginningLoanBalance - PrinciplePayment;
    }

    public float EndingLoanBalance {
        get {
            return _endingLoanBalance;
        }
        private set {
            _endingLoanBalance = value;
        }
    }

    public float BeginningLoanBalance {
        get {
            return _beginningLoanBalance;
        }
        private set {
            _beginningLoanBalance = value;
        }
    }

    public float MonthlyPayment {
        get {
            return _monthlyPayment;
        }
        private set {
            _monthlyPayment = value;
        }
    }

    public float InterestPayment {
        get {
            return _interestPayment;
        }
        private set {
            _interestPayment = value;
        }        
    }

    public float InterestRate {
        get {
            return _interestRate;
        }
        private set {
            _interestRate = value;
        }
    }

    public float PrinciplePayment {
        get {
            return _principlePayment;
        }
        private set {
            _principlePayment = value;
        }
    }

    public int PaymentNum {
        get {
            return _paymentNum;
        }
        private set {
            _paymentNum = value;
        }
    }

    public override string ToString()
    {
        return PaymentNum + SEPERATOR + BeginningLoanBalance + SEPERATOR + MonthlyPayment + SEPERATOR + InterestPayment + SEPERATOR + PrinciplePayment + SEPERATOR + EndingLoanBalance;
    }

    public string ToJSON()
    {
        return "{\"paymentNum\":" + PaymentNum + ",\"beginningBalance\":" + BeginningLoanBalance + ",\"monthlyPayment\":" + MonthlyPayment + ",\"interestPayment\":" + InterestPayment + ",\"principlePayment\":" + PrinciplePayment + ",\"endingBalance\":" + EndingLoanBalance + "}";
    }
}