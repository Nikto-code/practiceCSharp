using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

class Logger {
    private Stack logs = new Stack();
    public void AddLog(string message) {
        logs.Push(new LogEntry(message));
    }
    public LogEntry RemoveLast() {
        if (logs.Count == 0) return null;
        return (LogEntry)logs.Pop();
    }
    public LogEntry GetLast() {
        if (logs.Count == 0) return null;
        return (LogEntry)logs.Peek();
    }
    public LogEntry Find(string text) {
        foreach (LogEntry log in logs) {
            if (log.Message.Contains(text)) return log;
        }
        return null;
    }
    public LogEntry[] Filter(string text) {
        ArrayList result = new ArrayList();
        foreach (LogEntry log in logs) {
            if (log.Message.Contains(text)) result.Add(log);
        }
        return (LogEntry[])result.ToArray(typeof(LogEntry));
    }
    public LogEntry[] GetSorted() {
        object[] temp = logs.ToArray();
        LogEntry[] arr = new LogEntry[temp.Length];
        for (int i = 0; i < temp.Length; i++) arr[i] = (LogEntry)temp[i];
        for (int i = 0; i < arr.Length - 1; i++) {
            for (int j = 0; j < arr.Length - i - 1; j++) {
                if (arr[j].Timestamp > arr[j + 1].Timestamp) {
                    var t = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = t;
                }
            }
        }
        return arr;
    }
}