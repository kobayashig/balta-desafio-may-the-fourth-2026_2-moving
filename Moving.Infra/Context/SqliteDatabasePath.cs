namespace Moving.Infra.Context;

internal static class SqliteDatabasePath
{
    private const string DatabaseFileName = "Moving.db";
    private const string ApiProjectDirectoryName = "Moving.API";

    public static string FromContentRoot(string contentRootPath) =>
        Path.Combine(contentRootPath, DatabaseFileName);

    public static string ForDesignTime(string currentDirectory)
    {
        var directory = new DirectoryInfo(currentDirectory);

        while (directory is not null)
        {
            var apiDirectory = Path.Combine(directory.FullName, ApiProjectDirectoryName);
            if (Directory.Exists(apiDirectory))
                return Path.Combine(apiDirectory, DatabaseFileName);

            directory = directory.Parent;
        }

        throw new DirectoryNotFoundException(
            $"Could not locate '{ApiProjectDirectoryName}' from '{currentDirectory}'.");
    }
}
