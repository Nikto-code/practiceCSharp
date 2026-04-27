using System;
using System.IO;
using System.Collections.Generic;
class CollectionHandler {
    private ListProcessor processor = new ListProcessor();
    public int SafeGetElement(List<int> list, int index) {
        try {
            return processor.GetElementAt(list, index);
        }
        catch (Exception ex) {
            LogException(ex);
            throw new CollectionException("Ошибка при работе с коллекцией", ex);
        }
    }
    private void LogException(Exception ex) {
        string log = $"[{DateTime.Now}]\n" + $"Message: {ex.Message}\n" + $"StackTrace: {ex.StackTrace}\n";
        if (ex.InnerException != null)  log += $"Inner: {ex.InnerException.Message}\n";
        File.AppendAllText("log.txt", log + "\n");
    }
}