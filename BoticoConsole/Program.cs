using System;
using Botico;

namespace BoticoConsole
{
	class MainClass
	{
		public static BoticoClient Botico = new BoticoClient('/', "Console", false);

		public static void Main(string[] args)
		{
			Botico.Init();
			ReadLine();
		}

		public static void ReadLine()
		{
			string s = Console.ReadLine();
			string response = Botico.UseCommand(s, Environment.UserName, false);
			if (!string.IsNullOrEmpty(response))
				Console.WriteLine(response);
			else
				Console.WriteLine("Unknown command!");
			ReadLine();
		}
	}
}
