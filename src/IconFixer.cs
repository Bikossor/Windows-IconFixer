using System;
using System.Diagnostics;
using System.IO;

namespace de.Bikossor.WindowsIconFixer
{
	public class IconFixer
	{
		private static readonly String _iconCacheFileName = "IconCache.db";
		private static readonly String _iconCacheFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            _iconCacheFileName
        );

		private static Process[] GetExplorerProcesses {
			get {
				return Process.GetProcessesByName("explorer");
			}
		}

		public static Boolean IconCacheExists {
			get {
				return File.Exists(_iconCacheFilePath);
			}
		}

		public static void DeleteIconCache() {
			try {
				File.Delete(_iconCacheFilePath);
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}

		public static void KillExplorerProcess() {
			try {
				foreach (var p in GetExplorerProcesses) {
					p.Kill();
				}
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}

		public static void StartExplorerProcess() {
			if(GetExplorerProcesses.Length == 0) {
				Process.Start("explorer");
			}
		}
	}
}