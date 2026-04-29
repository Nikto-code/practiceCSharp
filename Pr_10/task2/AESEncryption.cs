using System;
using System.Collections.Generic;
using System.Text;

class AESEncryption : IEncryptionStrategy
{
    public string Encrypt(string data)
    {
        return $"AES({data})";
    }
}
class DESEncryption : IEncryptionStrategy
{
    public string Encrypt(string data)
    {
        return $"DES({data})";
    }
}
class NoEncryption : IEncryptionStrategy
{
    public string Encrypt(string data)
    {
        return data;
    }
}