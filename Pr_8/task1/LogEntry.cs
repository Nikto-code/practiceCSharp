using System;
using System.Collections.Generic;
using System.Text;

class LogEntry { 
    public DateTime Timestamp { get; set; }
    public string Message { get; set; }
    public LogEntry(string message) {
        Timestamp = DateTime.Now;
        Message = message;
    }
}