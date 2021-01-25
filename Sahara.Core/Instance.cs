using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net;
using System.Numerics;
using System.Threading;

namespace Sahara.Core
{
	
	/// <summary>
	/// A class that bootstraps the Instance system.
	/// Written in CSharp-lua bindings.
	/// </summary>
	public class Instance
	{

		public string ClassName;
		public string Name;
		public Instance Parent;
		public bool Archivable;

		/// <summary>
		/// @CSharpLua.Template = "game"
		/// </summary>
		/// <returns>The current DataModel</returns>
		public static extern Instance Game();

		/// <summary>
		/// @CSharpLua.Template = "script"
		/// </summary>
		/// <returns>The current script</returns>
		public static extern Instance Script();

		/// <summary>
		/// @CSharpLua.Template = "Instance.new({0})"
		/// </summary>
		/// <param name="className"></param>
		/// <returns></returns>
		public static extern Instance New(string className);

		/// <summary>
		/// @CSharpLua.Template = "Instance.new({0},{1})"
		/// </summary>
		/// <param name="className"></param>
		/// <param name="parent"></param>
		/// <returns></returns>
		public static extern Instance New(string className, Instance parent);

		/// <summary>
		/// Get [index] (a[b])
		/// @CSharpLua.Template = "{this}[{0}]"
		/// </summary>
		/// <param name="index">The index</param>
		/// <returns></returns>
		public extern object Get(object index);

		/// <summary>
		/// Set [index] to value (a[b] = c)
		/// @CSharpLua.Template = "{this}[{0}] = {1}"
		/// </summary>
		/// <param name="index">The index</param>
		/// <param name="value">The value to set the index to</param>
		/// <example>Instance.Set(Instance.Game(), "Name", "NameHere")</example>
		///	<returns>Nothing</returns>
		public extern void Set(object index, object value);

		/// <summary>
		/// Namecall (a:b()) an object
		/// @CSharpLua.Template = "{this}[{0}]({this}, {*1})"
		/// </summary>
		/// <param name="index"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public extern object[] Namecall(object index, params object[] args);

		/// <summary>
		/// @CSharpLua.Template = "{this}:ClearAllChildren()"
		/// </summary>
		public extern void ClearAllChildren();

		/// <summary>
		/// @CSharpLua.Template = "{this}:Clone()"
		/// </summary>
		public extern Instance Clone();
		
		/// <summary>
		/// Destroy an instance
		/// @CSharpLua.Template = "{this}:Destroy()"
		/// </summary>
		public extern void Destroy();

		/// <summary>
		/// @CSharpLua.Template = "{this}:FindFirstAncestor({0})"
		/// </summary>
		public extern Instance FindFirstAncestor(string name);
		
		/// <summary>
		/// @CSharpLua.Template = "{this}:FindFirstAncestorOfClass({0})"
		/// </summary>
		public extern Instance FindFirstAncestorOfClass(string className);
		
		/// <summary>
		/// @CSharpLua.Template = "{this}:FindFirstAncestorWhichIsA({0})"
		/// </summary>
		public extern Instance FindFirstAncestorWhichIsA(string className);

		/// <summary>
		/// @CSharpLua.Template = "{this}:FindFirstChild({0},{1})"
		/// </summary>
		/// <param name="name"></param>
		/// <param name="recursive"></param>
		public extern Instance FindFirstChild(string name, bool recursive);

		/// <summary>
		/// @CSharpLua.Template = "{this}:FindFirstChildOfClass({0})"
		/// </summary>
		/// <param name="className"></param>
		/// <returns></returns>
		public extern Instance FindFirstChildOfClass(string className);

		/// <summary>
		/// @CSharpLua.Template = "{this}:FindFirstChildWhichIsA({0},{1})"
		/// </summary>
		/// <param name="className"></param>
		/// <param name="recursive"></param>
		/// <returns></returns>
		public extern Instance FindFirstChildWhichIsA(string className, bool recursive);

		/// <summary>
		/// Get a list of attributes in a k->v format.
		/// @CSharpLua.Template = "{this}:GetAttributes()"
		/// </summary>
		/// <returns></returns>
		public extern Dictionary<string, object> GetAttributes();

		/// <summary>
		/// @CSharpLua.Template = "{this}:GetAttribute({0})"
		/// </summary>
		/// <param name="attribute"></param>
		/// <returns></returns>
		public extern object GetAttribute(string attribute);

		/// <summary>
		/// @CSharpLua.Template = "{this}:SetAttribute({0},{1})"
		/// </summary>
		/// <param name="attribute"></param>
		/// <param name="value"></param>
		public extern void SetAttribute(string attribute, object value);

		/// <summary>
		/// @CSharpLua.Template = "{this}:GetChildren()"
		/// </summary>
		/// <returns>A list of children</returns>
		public extern Instance[] GetChildren();

		/// <summary>
		/// @CSharpLua.Template = "{this}:GetDescendants()"
		/// </summary>
		/// <returns></returns>
		public extern Instance[] GetDescendants();
		
		/// <summary>
		/// @CSharpLua.Template = "{this}:GetFullName()"
		/// </summary>
		/// <returns></returns>
		public extern string GetFullName();

		/// <summary>
		/// @CSharpLua.Template = "{this}:IsA({0})"
		/// </summary>
		/// <param name="className"></param>
		/// <returns></returns>
		public extern bool IsA(string className);

		/// <summary>
		/// Checks if the current instance has a descendent matching "descendant"
		/// @CSharpLua.Template = "{this}:IsAncestorOf({0})"
		/// </summary>
		/// <param name="descendant">The instance to check if it is a descendant</param>
		/// <returns></returns>
		public extern bool IsAncestorOf(Instance descendant);

		/// <summary>
		/// Checks if the current instance is a descendant of "ancestor"
		/// @CSharpLua.Template = "{this}:IsDescendantOf({0})"
		/// </summary>
		/// <param name="ancestor">The instance which is supposedly a ancestor of this instance</param>
		/// <returns></returns>
		public extern bool IsDescendantOf(Instance ancestor);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public extern Instance WaitForChild();

		public static void Test()
		{
			var a = Instance.Game();
			a.Namecall("hey", "b","c","d");
			a.Set("Name", "wee");
			var b = a.GetAttributes();
			foreach (var c in b)
			{
				Console.WriteLine(c);
			}
		}

	}
}