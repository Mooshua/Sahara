using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Sahara.Core.Game
{
	public class Game : Instance
	{

		public long GameId;
		public string JobId;
		public long CreatorId;
		public int PlaceVersion;
		public string PrivateServerId;
		public long PrivateServerOwnerId;
		
		//	Common children
		public Instance Workspace;
		public Instance Lighting;
		public Instance Players;
		public Instance ReplicatedStorage;
		public Instance ReplicatedFirst;
		public Instance ServerScriptService;
		public Instance ServerStorage;

		/// <summary>
		/// @CSharpLua.Template = "game:GetService({0})"
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static extern Instance GetService(string name);

		/// <summary>
		/// @CSharpLua.Template = "game:BindToClose({0})"
		/// </summary>
		/// <param name="callback"></param>
		public static extern void BindToClose(Action callback);

		/// <summary>
		/// @CSharpLua.Template = "game:Shutdown()"
		/// </summary>
		public static extern void Shutdown();
	}
}