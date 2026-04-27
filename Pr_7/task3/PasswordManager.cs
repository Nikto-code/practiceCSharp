class PasswordManager
{
    public void ValidatePassword(string password)
    {
        if (password.Length < 8)
            throw new WeakPasswordException("Пароль слишком короткий (минимум 8 символов)");
        bool hasDigit = false;
        for (int i = 0; i < password.Length; i++)
        {
            if (char.IsDigit(password[i]))
            {
                hasDigit = true;
                break;
            }
        }
        if (!hasDigit)
            throw new WeakPasswordException("Пароль должен содержать хотя бы одну цифру");
    }
}