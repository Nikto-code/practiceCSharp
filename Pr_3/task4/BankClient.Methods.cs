using System;
using System.Collections.Generic;
using System.Text;

public partial class BankClient
{
    public bool HasLowBalance(decimal minBalance)
    {
        return AccountBalance < minBalance;
    }
}