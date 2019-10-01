using System;
using System.Diagnostics;
using System.IO;

namespace de.Bikossor.WindowsIconFixer
{
	public static class IconFixer
	{
        #region Private fields

        private static readonly String _iconCacheFileName = "IconCache.db";
		private static readonly String _iconCacheFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            _iconCacheFileName
        );

        #endregion

        #region Private properties

        private static Process[] GetExplorerProcesses => Process.GetProcessesByName("explorer");
        private static Boolean ExplorerProcessExists => GetExplorerProcesses.Length > 0;

        #endregion

        #region Public properties

        public static Boolean IconCacheExists => File.Exists(_iconCacheFilePath);

        #endregion

        #region Public methods

        public static void DeleteIconCache()
        {
			try
            {
				File.Delete(_iconCacheFilePath);
			}
			catch (Exception e)
            {
				Console.WriteLine(e.Message);
			}
		}

		public static void KillExplorerProcess()
        {
			try
            {
				foreach (var process in GetExplorerProcesses)
                {
					process.Kill();
				}
			}
			catch (Exception e)
            {
				Console.WriteLine(e.Message);
			}
		}

		public static void StartExplorerProcess()
        {
			if (!ExplorerProcessExists)
            {
				Process.Start("explorer");
			}
		}

        #endregion
    }
}