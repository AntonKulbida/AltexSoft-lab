﻿using System;
using System.IO;
namespace WatcherForFiles
{
	class LogToConsole
	{
		public void Log(string text)
		{
			Console.WriteLine(text);
		}
	}
	class LogToFile
	{
		public void Log(string text)
		{
            string pathToFileLog = "ITVDN/ITVDN/log.txt";
			if (!text.Contains(pathToFileLog))
				File.AppendAllText(pathToFileLog, text);
		}
	}
	class MainClass
	{
		static void OnChanged(object sender, FileSystemEventArgs args)
		{
			var console = new LogToConsole();
			var file = new LogToFile();
			string s = string.Format("{0}: {1}", args.ChangeType, args.FullPath);
			console.Log(s);
			file.Log(s + "\n");
		}
		public static void Main(string[] args)
		{
            string path = @"D:/ITVDN/ITVDN";
			string filter = "*.*";
			if (args.Length > 0)
				if (args[0] != null && Directory.Exists(args[0]))
					path = args[0];
			if (args.Length > 1)
				if (args[1] != null)
					filter = args[1];
			
				
			var watcher = new FileSystemWatcher(path, filter);
			watcher.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.Size;
			watcher.IncludeSubdirectories = true;
			watcher.Changed += OnChanged;
			watcher.Created += OnChanged;
			watcher.Deleted += OnChanged;
			watcher.EnableRaisingEvents = true;
			Console.ReadKey();
		}
	}
}