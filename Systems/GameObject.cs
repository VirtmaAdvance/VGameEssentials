using VGameEssentials.Systems.Collections.Basic;

namespace VGameEssentials.Systems
{
	/// <summary>
	/// Manages game objects.
	/// </summary>
	public class GameObject
	{

		private static VEnumerable<GameObject> s_items = [];
		/// <summary>
		/// The game objects that have been created.
		/// </summary>
		public static VEnumerable<GameObject> Items => s_items;
		/// <summary>
		/// The ID for this game object.
		/// </summary>
		public readonly Guid ID;
		/// <summary>
		/// The name for this object.
		/// </summary>
		public string? Name { get; set; }


		/// <summary>
		/// Creates a new instance of the <see cref="GameObject"/> class.
		/// </summary>
		/// <param name="name"></param>
		public GameObject(string name)
		{
			ID = Guid.NewGuid();
		}

	}
}
