using System;
using System.Collections.Generic;
using System.Text;

public delegate string UserAction(int ID);
class UserService {
    public string PerformUserAction(int ID, UserAction action) {
        return action(ID);
    }
    public string BlockUser(int ID) {
        return $"Пользователь {ID} заблокирован";
    }
    public string UnblockUser(int ID) {
        return $"Пользователь {ID} разблокирован";
    }
}