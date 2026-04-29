using static System.Console;

class Program {
    static void Main() {
        var session1 = SessionManager.GetInstance();
        session1.Login("Nikto");
        var session2 = SessionManager.GetInstance();
        WriteLine(session2.GetCurrentUser()); 
        session2.Logout();
        WriteLine(session1.GetCurrentUser());
    }
}