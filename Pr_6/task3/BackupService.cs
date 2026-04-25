using System;
using System.Collections.Generic;
using System.Text;

class BackupService
{
    public string CreateBackup(string message)
    {
        return $"Backup: создана резервная копия ({message})";
    }
}