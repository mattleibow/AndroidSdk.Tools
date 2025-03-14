﻿using System.IO;
using System.Runtime.InteropServices;

namespace AndroidSdk
{
	public class JdkInfo
	{
		public JdkInfo(string javaCFile, string version, bool setByEnvironmentVariable = false, bool preferredByDotNet = false)
		{
			var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

			JavaC = new FileInfo(javaCFile);
			Home = new DirectoryInfo(Path.Combine(JavaC.Directory.FullName, ".."));
			Java = new FileInfo(Path.Combine(Home.FullName, "bin", "java" + (isWindows ? ".exe" : "")));
			Version = version;
			SetByEnvironmentVariable = setByEnvironmentVariable;
			PreferredByDotNet = preferredByDotNet;
		}

		public FileInfo JavaC { get; private set; }
		public FileInfo Java { get; private set; }

		public DirectoryInfo Home { get; private set; }

		public bool SetByEnvironmentVariable { get; private set; } = false;

		public bool PreferredByDotNet {get; private set; } = false;

		public string Version { get; set; }
	}
}
