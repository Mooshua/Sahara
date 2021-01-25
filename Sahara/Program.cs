using System;
using Sahara.Core;
using Sahara.Core.Game;

namespace Sahara
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World! from {0} !!!","C Sharp");
			Game.BindToClose(() 
				=>
			{
				Console.WriteLine("Haha");
			});
		}
	}
}