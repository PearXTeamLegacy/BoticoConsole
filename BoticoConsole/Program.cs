using System;
using Botico;
using Botico.Model;

namespace BoticoConsole
{
	class MainClass
	{
		public static BoticoClient Botico = new BoticoClient("Console");

		public static void Main()
		{
			Console.WriteLine("Welcome to the Botico!");
			Botico.Init();
			ReadLine();
		}

		public static void ReadLine()
		{
			Console.Write(">");
			string s = Console.ReadLine();
			if(s != "/quit")
			{
				BoticoResponse response = Botico.UseCommand(s, Environment.UserName, false);
				HandleResponse(response, false);
				ReadLine();
			}
		}

		public static void HandleResponse(BoticoResponse response, bool group)
		{
			bool text = !string.IsNullOrEmpty(response.Text);
			bool img = response.Images != null;

			if (text || img)
			{
				if (group)
					Console.Write("[Group] ");
				if (text)
					Console.WriteLine(response.Text);
				if (img)
				{
					foreach (var v in response.Images)
						Console.WriteLine("[Image  " + v.Width + "x" + v.Height + "]");
				}
			}
		}
	}
}