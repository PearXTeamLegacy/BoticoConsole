using System;
using Botico;

namespace BoticoConsole
{
	class MainClass
	{
		public static BoticoClient Botico = new BoticoClient('/', "Console", false);

		public static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the Botico!");
			Botico.Init();
			ReadLine();
		}

		public static void ReadLine()
		{
			Console.Write(">");
			string s = Console.ReadLine();
			if (s == "/quit")
			{
				Botico.End();
			}
			else
			{
				string response = Botico.UseCommand(s, Environment.UserName, false);
				if (!string.IsNullOrEmpty(response))
					Console.WriteLine(response);
				else
					Console.WriteLine("Unknown command!");
				ReadLine();
			}
		}
	}
}
