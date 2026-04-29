using System;
using System.Collections.Generic;
using System.Text;
class EncryptionService
{
    private IEncryptionStrategy _strategy;
    public EncryptionService(IEncryptionStrategy strategy)
    {
        _strategy = strategy;
    }
    public void SetStrategy(IEncryptionStrategy strategy)
    {
        _strategy = strategy;
    }
    public string Process(string data)
    {
        return _strategy.Encrypt(data);
    }
}