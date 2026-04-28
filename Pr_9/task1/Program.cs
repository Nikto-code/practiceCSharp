using static System.Console;

class Program{
    static void Main(){
        FileManager fm = new FileManager();
        FileInfoProvider info = new FileInfoProvider();
        string file = "Седляр.МВ";
        string copy = "copy.МВ";
        string folder = "Папка";
        Directory.CreateDirectory(folder);
        try {
            fm.CreateAndWrite(file, "Привет файл");
            WriteLine(fm.Read(file));
            WriteLine($"Размер: {info.GetSize(file)}");
            WriteLine($"Создан: {info.GetCreated(file)}");
            WriteLine($"Изменен: {info.GetModified(file)}");
            fm.Copy(file, copy);
            WriteLine($"Копия существует: {fm.Exists(copy)}");
            string moved = Path.Combine(folder, file);
            fm.Move(file, moved);
            fm.Rename(moved, "familiya.io");
            var files = fm.GetFiles(folder);
            WriteLine("Файлы:");
            foreach (var f in files) WriteLine(f);
            string newFile = Path.Combine(folder, "test.ii");
            fm.CreateAndWrite(newFile, "data");
            fm.SetReadOnly(newFile);
            try { fm.TryWrite(newFile, "новые данные");}
            catch { WriteLine("Запись запрещена"); }
            WriteLine("Сравнение:");
            WriteLine(info.GetSize(copy) == info.GetSize(copy) ? "равны" : "не равны");
            fm.DeleteExtension(folder, "ii");
            try { fm.Delete("no_file.ii"); }
            catch (Exception ex) { WriteLine(ex.Message); }
        }
        catch (Exception ex) { WriteLine("Ошибка: " + ex.Message); }
    }
}