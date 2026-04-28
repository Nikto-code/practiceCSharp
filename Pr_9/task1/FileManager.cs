using System;
using System.IO;

class FileManager
{
    public void CreateAndWrite(string path, string content) { File.WriteAllText(path, content); }
    public string Read(string path) { return File.ReadAllText(path);}
    public bool Exists(string path) { return File.Exists(path); }
    public void Delete(string path) {
        if (!File.Exists(path)) throw new FileNotFoundException("Файл не найден");
        File.Delete(path);
    }
    public void Copy(string source, string dest) { File.Copy(source, dest, true); }
    public void Move(string source, string dest) { File.Move(source, dest, true); }
    public void Rename(string source, string newName) {
        string dir = Path.GetDirectoryName(source);
        string newPath = Path.Combine(dir, newName);
        File.Move(source, newPath, true);
    }
    public void DeleteExtension(string folder, string ext)
    {
        string[] files = Directory.GetFiles(folder, "*." + ext);
        foreach (var file in files)
        {
            File.SetAttributes(file, FileAttributes.Normal);
            File.Delete(file);
        }
    }
    public string[] GetFiles(string folder) { return Directory.GetFiles(folder); }
    public void SetReadOnly(string path) { File.SetAttributes(path, FileAttributes.ReadOnly); }
    public void TryWrite(string path, string content) { File.WriteAllText(path, content); }
}