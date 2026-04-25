using static System.Console;
class Program{
    static void Main() {
        UserService service = new UserService();
        WriteLine(service.PerformUserAction(10, service.BlockUser));
        WriteLine(service.PerformUserAction(10, service.UnblockUser));
    }
}