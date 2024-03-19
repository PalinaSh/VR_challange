using VR_Challange;


using var watcher = new FileSystemWatcher(@"D:\repos\VR_Challange_Data") // Path should be changed to real or we can read it from config.
{
    Filter = "*.txt", // It should be the right format here. There is 'data.txt' file in the example, so I monitor only .txt files.
    EnableRaisingEvents = true,
};

watcher.Created += FileCreated; // The event occurs each time a file is dropped into the watched folder.
                                // If we need to monitor other events (like file changing), we can add a new event handler to the watcher.

Console.ReadLine();




void FileCreated(object sender, FileSystemEventArgs e)
{

}