using System;
using System.Collections.Generic;
using System.Text;

class Bank
{
    public BankClient[] Clients;

    public Bank(BankClient[] clients)
    {
        Clients = clients;
    }
    public BankClient[] GetClientsWithLowBalance(decimal minBalance)
    {
        int count = 0;

        for (int i = 0; i < Clients.Length; i++)
        {
            if (Clients[i].HasLowBalance(minBalance))
                count++;
        }

        BankClient[] result = new BankClient[count];
        int index = 0;
        for (int i = 0; i < Clients.Length; i++)
        {
            if (Clients[i].HasLowBalance(minBalance))
            {
                result[index] = Clients[i];
                index++;
            }
        }

        return result;
    }
    public BankClient GetRichestClient()
    {
        BankClient richest = Clients[0];
        for (int i = 1; i < Clients.Length; i++)
        {
            if (Clients[i].AccountBalance > richest.AccountBalance)
            {
                richest = Clients[i];
            }
        }
        return richest;
    }
}