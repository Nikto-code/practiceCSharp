using System;
using System.Collections.Generic;
using System.Text;

class FileWatcher
{
    public FileSystemWatcher watcher;
    public string folderPath;
    public string archivePath;
    public FileWatcher(string folderPath) {
        this.folderPath = folderPath;
        archivePath = Path.Combine(folderPath, "archive");
        if (!Directory.Exists(archivePath)) 
            Directory.CreateDirectory(archivePath);
        watcher = new FileSystemWatcher(folderPath);
        watcher.IncludeSubdirectories = false;
        watcher.Created += OnCreated;
        watcher.Deleted += OnDeleted;
        watcher.Changed += OnChanged;
        watcher.Renamed += OnRenamed;
    }
    public void Start()
    {
        watcher.EnableRaisingEvents = true;
    }
    public void OnCreated(object sender, FileSystemEventArgs e)
    {
        CheckAndMove(e.FullPath);
    }
    public void OnChanged(object sender, FileSystemEventArgs e)
    {
        CheckAndMove(e.FullPath);
    }
    public void OnDeleted(object sender, FileSystemEventArgs e)
    {
        File.AppendAllText("log.txt", $"Удален: {e.FullPath}\n");
    }
    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        CheckAndMove(e.FullPath);
    }
    public void CheckAndMove(string filePath)
    {
        if (!File.Exists(filePath)) return;
        DateTime lastWrite = File.GetLastWriteTime(filePath);
        if ((DateTime.Now - lastWrite).TotalDays > 30)
        {
            string fileName = Path.GetFileName(filePath);
            string destPath = Path.Combine(archivePath, fileName);

            File.Move(filePath, destPath);
        }
    }
}