using System;
using System.Runtime.InteropServices.ComTypes;

namespace Sahara.Core.Game
{
	public class Player : Instance
	{
		
	}
	
	public class Players : Instance
	{
		public Player LocalPlayer;

		/// <summary>
		/// @CSharpLua.Template = "{this}:GetPlayers()"
		/// </summary>
		/// <returns></returns>
		public extern Player[] GetPlayers();
	}
}