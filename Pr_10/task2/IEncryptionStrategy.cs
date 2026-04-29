using System;
using System.Collections.Generic;
using System.Text;

interface IEncryptionStrategy
{
    string Encrypt(string data);
}