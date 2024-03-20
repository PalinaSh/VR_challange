using VR_Challange;
using VR_Challange.Models;


using var watcher = new FileSystemWatcher(@"D:\repos\VR_Challange_Data") // Path should be changed to real or we can read it from config.
{
    Filter = "*.txt", // It should be the right format here. There is 'data.txt' file in the example, so I monitor only .txt files.
    EnableRaisingEvents = true,
};

watcher.Created += FileCreated; // The event occurs each time a file is dropped into the watched folder.
                                // If we need to monitor other events (like file changing), we can add a new event handler to the watcher.

Console.ReadLine();


void FileCreated(object sender, FileSystemEventArgs e) => _ = ReadFile(e.FullPath);

async Task ReadFile(string path)
{
    const string BoxKeyWord = "HDR";
    const string ContentKeyWord = "LINE";

    if (!File.Exists(path))
        return;

    Box box = null;

    try
    {
        using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        using var reader = new StreamReader(fileStream);

        while (reader.Peek() >= 0)
        {
            var line = await reader.ReadLineAsync();

            if (string.IsNullOrWhiteSpace(line))
                continue;

            var columns = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (columns.Length == 3 && BoxKeyWord.Equals(columns[0], StringComparison.InvariantCultureIgnoreCase))
            {
                await SaveBox(box);

                box = new()
                {
                    Id = columns[2],
                    SupplierIdentifier = columns[1],
                };
            }
            else if (box is not null && columns.Length == 4 && ContentKeyWord.Equals(columns[0], StringComparison.InvariantCultureIgnoreCase))
            {
                var content = new Content()
                {
                    Id = Guid.NewGuid(),
                    ISBN = columns[2],
                    PoNumber = columns[1],
                    Quantity = int.TryParse(columns[3], out var quantity) ? quantity : default,
                };

                box.Contents.Add(content);
            }
        }
    }
    catch { /* Log an exception */ }

    await SaveBox(box); // Also we can save boxes to the database not one at a time, but several at a time.
}

async Task SaveBox(Box box)
{
    if (box is not null)
    {
        try
        {
            using var dbContext = new ApplicationContext();

            await dbContext.AddAsync(box);
            await dbContext.SaveChangesAsync();
        }
        catch { /* Log an exception */ }
    }
}