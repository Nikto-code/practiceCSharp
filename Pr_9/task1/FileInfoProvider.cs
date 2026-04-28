class FileInfoProvider {
    public double GetSize(string path) { return new FileInfo(path).Length; }
    public DateTime GetCreated(string path) { return File.GetCreationTime(path); }
    public DateTime GetModified(string path){ return File.GetLastWriteTime(path); }
    public bool CanRead(string path) { return File.Exists(path);}
    public bool CanWrite(string path) {
        FileAttributes attr = File.GetAttributes(path);
        return (attr & FileAttributes.ReadOnly) == 0;
    }
}