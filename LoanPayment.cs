public class LoanPayment {
    private int _paymentNum;
    private float _payment;
    private float _beginningLoanBalance;
    private float _interest;
    private float _principlePayment;
    private float _interestPayment;
    private float _endingLoanBalance;
    
    private static String SEPERATOR = "/";

    public LoanPayment(int paymentNum, float monthlyPayment, float beginningLoanBalance, float interest) {
        _paymentNum = paymentNum;
        _payment = monthlyPayment;
        _beginningLoanBalance = beginningLoanBalance;
        _interest = interest;

        _principlePayment = _payment - (_beginningLoanBalance * (_interest / (12* 100)));

        _interestPayment = _payment - _principlePayment;

        _endingLoanBalance = _beginningLoanBalance - _principlePayment;
    }

    public float EndingLoanBalance {
        get {
            return _endingLoanBalance;
        }
    }

    public float MonthlyPayment {
        get {
            return _payment;
        }
    }

    public float InterestPayment {
        get {
            return _interestPayment;
        }        
    }

    public override string ToString()
    {
        return _paymentNum + SEPERATOR + _beginningLoanBalance + SEPERATOR + _payment + SEPERATOR + _interestPayment + SEPERATOR + _principlePayment + SEPERATOR + _endingLoanBalance;
    }
}