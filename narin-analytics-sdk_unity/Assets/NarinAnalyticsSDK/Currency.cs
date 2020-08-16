public partial struct Currency {
    public string CurrencyCode;
    public int CurrencyCodeNum;

    public Currency(string currencyCode, int currencyCodeNum) {
        CurrencyCode = currencyCode;
        CurrencyCodeNum = currencyCodeNum;

    }

    public static implicit operator int(Currency currency) {
        return currency.CurrencyCodeNum;
    }

    public static implicit operator string(Currency currency) {
        return currency.CurrencyCode;
    }
}

public partial struct Currency {
    public readonly static Currency USD = new Currency("USD", 840);
    public readonly static Currency IRR = new Currency("IRR", 364);
    public readonly static Currency EUR = new Currency("EUR", 978);
    public readonly static Currency RUB = new Currency("RUB", 643);
}