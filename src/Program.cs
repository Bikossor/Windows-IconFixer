using System;
using System.Reflection;

namespace de.Bikossor.WindowsIconFixer
{
	class Program
	{
		static void Main(String[] args)
		{
			Console.Write("Windows-IconFixer v{0} by André Lichtenthäler (Bikossor)\n",
                Assembly.GetExecutingAssembly().GetName().Version.ToString()
            );
			Console.Write("Website:  {0}\n\n", "https://github.com/Bikossor/Windows-IconFixer");
			
			Console.Write("Windows-IconFixer has been started...\n");

			if(IconFixer.IconCacheExists) {
				Console.Write("Deleting IconCache...\n");
				IconFixer.DeleteIconCache();
				Console.Write("IconCache deleted!\n");

				Console.Write("Killing explorer.exe...\n");
				IconFixer.KillExplorerProcess();
				Console.Write("Killed explorer.exe!\n");

				Console.Write("Starting explorer.exe...\n");
				IconFixer.StartExplorerProcess();
				Console.Write("Started explorer.exe!\n");

                Console.Write("Windows-IconFixer has finished!");
			}
			else {
				Console.Write("Sorry but no IconCache.db was found on your computer.\n");
			}

			Console.ReadKey();
		}
	}
}
