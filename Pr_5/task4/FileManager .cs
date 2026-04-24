class FileManager : IReadFile, IWriteFile {
    string IReadFile.AccessFile(string fileName) {
        return $"Чтение файла: {fileName}";
    }
     string IWriteFile.AccessFile(string fileName) {
        return $"Запись в файл: {fileName}";
    }
}