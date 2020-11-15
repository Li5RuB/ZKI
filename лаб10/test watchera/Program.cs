
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;


public static class ExceptionExtension
{
    private const int ERROR_SHARING_VIOLATION = 32;
    private const int ERROR_LOCK_VIOLATION = 33;

    public static bool IsFileLocked(this Exception exception)
    {
        int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
        return errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION;
    }
}

class Program
{
   
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();


    public static ContextMenu menu;
    public static MenuItem mnuExit;
    public static NotifyIcon icon;
    static string writePath = "Logs";
    static string directory = @"D:\Test";
    static void Main()
    {

        Thread notifyThread = new Thread(
            delegate ()
            {
                ContextMenu trayMenu = new ContextMenu();
                trayMenu.MenuItems.Add("Скрыть", item1_Click);
                trayMenu.MenuItems.Add("Раскрыть", item2_Click);
                trayMenu.MenuItems.Add("Закрыть", item3_Click);

                icon = new NotifyIcon();
                icon.Icon = new Icon("icon.ico");
                icon.ContextMenu = trayMenu;
                



                icon.Visible = true;
                Application.Run();
            }
        );
        notifyThread.Start();
        ShowWindow(GetConsoleWindow(), 0); // Скрыть.
        ShowWindow(GetConsoleWindow(), 1); // Показать.
        using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
        {
            sw.WriteLine($"Start tracking {DateTime.Now};\n\n\n");
            
        }
        Console.WriteLine("MAIN");
        Init();
      
        while (true)
        {
            Console.WriteLine("just a loop");
            string line = Console.ReadLine();
            Console.WriteLine("just a loop" + line);
            
        }
    }

    private static void item3_Click(object sender, EventArgs e)
    {
        icon.Dispose();
        Application.Exit();
        Process.GetCurrentProcess().Kill();
    }

    private static void item2_Click(object sender, EventArgs e)
    {
        ShowWindow(GetConsoleWindow(), 1);
        
    }

    private static void item1_Click(object sender, EventArgs e)
    {
        ShowWindow(GetConsoleWindow(), 0);
        
    }

    static FileSystemWatcher _watcher;

    static void Init()
    {
        Console.WriteLine("INIT");
        
        _watcher = new FileSystemWatcher(directory);
        _watcher.NotifyFilter = NotifyFilters.LastAccess
                                | NotifyFilters.LastWrite
                                | NotifyFilters.FileName
                                | NotifyFilters.DirectoryName;
        _watcher.Filter = "*.*";
        
        
       
        _watcher.Changed += OnChanged;
        _watcher.Created += OnChanged;
        _watcher.Deleted += OnChanged;
        _watcher.Renamed += OnRenamed;
        _watcher.EnableRaisingEvents = true;
        _watcher.IncludeSubdirectories = true;
    }

  
    private static void OnRenamed(object source, RenamedEventArgs e)
    {
       
        Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
        DateTime dt = File.GetLastAccessTime(directory);
        Console.WriteLine("The last access time for this file was {0}.", dt);
        Console.WriteLine("UserName: {0}", Environment.UserName);
        using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
        {
            sw.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
            sw.WriteLine("The last access time for this file was {0}.", dt);
            sw.WriteLine("UserName: {0}", Environment.UserName);
        }
    }

    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        
        Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        DateTime dt = File.GetLastAccessTime(directory);
        Console.WriteLine("The last access time for this file was {0}.", dt);
        Console.WriteLine("UserName: {0}", Environment.UserName);
        using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
        {
            sw.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            sw.WriteLine("The last access time for this file was {0}.", dt);
            sw.WriteLine("UserName: {0}", Environment.UserName);
        }
    }

}

