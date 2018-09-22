using System.Collections.Generic;
using System.Linq;

namespace Data.Trie
{
	/// <summary>
	/// Represents a node in a Trie structure.
	/// </summary>
	public class Node
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="Node"/> class.
		/// </summary>
		/// <param name="value">A character for this current node.</param>
		/// <param name="depth">Depth of this character in that tree strucure.</param>
		/// <param name="parent">A <see cref="Node"/> parent node.</param>
		public Node(char value, int depth, Node parent)
		{
			this.Value = value;
			this.Depth = depth;
			this.Parent = parent;
			this.Children = new List<Node>();
		}

		/// <summary>
		/// Node value.
		/// </summary>
		public char Value { get; set; }

		/// <summary>
		/// Children for this node.
		/// </summary>
		public List<Node> Children { get; set; }

		/// <summary>
		/// Parent node.
		/// </summary>
		public Node Parent { get; set; }

		/// <summary>
		/// Node depth.
		/// </summary>
		public int Depth { get; set; }

		/// <summary>
		/// Flag to determine if this node is a leaf node.
		/// </summary>
		public bool IsLeaf
		{
			get
			{
				return Children.Count == 0;
			}
		}

		/// <summary>
		/// Finds the child node matching the value.
		/// </summary>
		/// <param name="c">Value to be searched in the Node collection.</param>
		/// <returns>Node matching the value supplied.</returns>
		public Node FindChild(char c)
		{
			return Children.FirstOrDefault(x => x.Value == c);
		}

		/// <summary>
		/// Deletes the node matching the value supplied from the node collection.
		/// </summary>
		/// <param name="c">Node value to be removed from collection.</param>
		public void Delete( char c)
		{
			var matchingNode = Children.FirstOrDefault(x => x.Value == c);
			if( matchingNode != null)
				Children.Remove(matchingNode);
		}
	}
}
