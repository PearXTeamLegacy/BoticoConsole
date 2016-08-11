using System;
using Botico;
using Botico.Model;

namespace BoticoConsole
{
	class MainClass
	{
		public static BoticoClient Botico = new BoticoClient('/', "Console", false, true, false, true);

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
			if (s == "/quit")
			{
				Botico.End();
			}
			else
			{
				BoticoResponse response = Botico.UseCommand(s, Environment.UserName, false);

				bool text = !string.IsNullOrEmpty(response.Text);
				bool img = response.Image != null;

				if (text ||img)
				{
					if(text)
						Console.WriteLine(response.Text);
					if (img)
						Console.WriteLine("Image [" + response.Image.Width + "x" + response.Image.Height + "]");
				}
				else
					Console.WriteLine("Unknown command!");
				ReadLine();
			}
		}
	}
}