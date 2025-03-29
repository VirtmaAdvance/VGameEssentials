using VGameEssentials.Systems.Collections.Basic;

namespace VGameEssentials.Systems
{
	/// <summary>
	/// Manages game objects.
	/// </summary>
	public class GameObject
	{

		private static VEnumerable<GameObject> s_gameObjects = [];
		/// <summary>
		/// The game objects that have been created.
		/// </summary>
		public static VEnumerable<GameObject> GameObjects => s_gameObjects;
		/// <summary>
		/// The ID for this game object.
		/// </summary>
		public readonly Guid ID;
		/// <summary>
		/// The name for this object.
		/// </summary>
		public string? Name { get; set; }


		/// <inheritdoc cref="GameObject.GameObject(Guid, string)"/>
		public GameObject()
		{
			ID = Guid.NewGuid();
			GameObjects.Add(this);
		}
		/// <inheritdoc cref="GameObject.GameObject(Guid, string)"/>
		public GameObject(string name)
		{
			ID = Guid.NewGuid();
			Name = name;
			GameObjects.Add(this);
		}
		/// <summary>
		/// Creates a new instance of the <see cref="GameObject"/> class.
		/// </summary>
		/// <param name="id">The ID for this object.</param>
		/// <param name="name">The name for this object.</param>
		public GameObject(Guid id, string name)
		{
			ID = id;
			Name = name;
			GameObjects.Add(this);
		}

	}
}
