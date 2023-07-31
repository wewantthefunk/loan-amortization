public class LoanLife {
    private LoanPayment[] _payments;
    private float _totalLoanCost;

    public LoanLife(LoanPayment[] payments) {
        this._payments = payments;

        _totalLoanCost = payments[0].MonthlyPayment * payments.Length;
    }

    public float[] InterestByYear() {
        List<float> result = new List<float>();

        float temp = 0f;

        for (int x = 0; x < _payments.Length; x++) {
            temp += _payments[x].InterestPayment;
            if (x > 0 && (x % 11 == 0 || x == _payments.Length - 1)) {
                result.Add(temp);
                temp = 0f;
            }
        }

        return result.ToArray();
    }

    public float TotalLoanCost {
        get {
            return _totalLoanCost;
        }
    }
}