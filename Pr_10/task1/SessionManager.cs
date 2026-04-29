using System;
using System.Collections.Generic;
using System.Text;

class SessionManager {
    private static SessionManager _instance;
    private static readonly object _lock = new object();
    private string _currentUser;
    private SessionManager() { }
    public static SessionManager GetInstance() {
        if (_instance == null) {
            lock (_lock) {
                if (_instance == null)
                    _instance = new SessionManager();
            }
        }
        return _instance;
    }
    public void Login(string user) { _currentUser = user; }
    public void Logout() { _currentUser = null; }
    public string GetCurrentUser() { return _currentUser; }
}