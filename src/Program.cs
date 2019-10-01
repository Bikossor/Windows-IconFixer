using System;
using System.Reflection;

namespace de.Bikossor.WindowsIconFixer
{
	public static class Program
	{
		static void Main(String[] args)
		{
			Console.Write("Windows-IconFixer v{0} by André Lichtenthäler (Bikossor)\n",
                Assembly.GetExecutingAssembly().GetName().Version.ToString()
            );

			Console.Write("Website:  {0}\n\n", "https://github.com/Bikossor/Windows-IconFixer");
			
			Console.Write("Windows-IconFixer has been started...\n");

			if (IconFixer.IconCacheExists)
            {
				Console.Write("Deleting IconCache... ");
				IconFixer.DeleteIconCache();
				Console.WriteLine("Done!");

				Console.Write("Killing explorer.exe... ");
				IconFixer.KillExplorerProcess();
                Console.WriteLine("Done!");

                Console.Write("Starting explorer.exe... ");
				IconFixer.StartExplorerProcess();
                Console.WriteLine("Done!");

                Console.Write("Windows-IconFixer has finished!");
			}
			else
            {
				Console.Write("Sorry but no IconCache.db was found on your computer.\n");
			}

			Console.ReadKey();
		}
	}
}
