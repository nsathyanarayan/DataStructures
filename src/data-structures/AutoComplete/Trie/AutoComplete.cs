using System.Collections.Generic;
using System.Linq;

namespace Data.Trie
{
	/// <summary>
	/// Class that implements Trie Data pattern.
	/// </summary>
	public class AutoComplete
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="AutoComplete"/> class.
		/// </summary>
		public AutoComplete()
		{
			RootNode = new Node('%', 0, null);
		}

		/// <summary>
		/// Represents the root node.
		/// </summary>
		public Node RootNode { get; private set; }

		/// <summary>
		/// Searches the existance of the value in a Trie structure.
		/// </summary>
		/// <param name="value">Value to be searched.</param>
		/// <returns>Returns true if value is found.. Else false.</returns>
		public bool Contains(string value)
		{
			var node = GetMatchingNode(value);
			return node.Depth.Equals(value.Length) && null != node.FindChild('$');
		}

		/// <summary>
		/// Insert new data into the mix.
		/// </summary>
		/// <param name="s">New value to be added to the collection.</param>
		public void Insert( string s)
		{
			var matchingNode = GetMatchingNode(s);
			var currentNode = matchingNode;
			for( int index = currentNode.Depth; index < s.Length; index++)
			{
				var newNode = new Node(s[index], currentNode.Depth + 1, currentNode);
				currentNode.Children.Add(newNode);
				currentNode = newNode;
			}

			currentNode.Children.Add(new Node('$', currentNode.Depth + 1, currentNode));
		}

		/// <summary>
		/// Insert list of words into the data structure.
		/// </summary>
		/// <param name="words">List of words to be inserted into a collection.</param>
		public void Insert(List<string> words)
		{
			words.ForEach(c => Insert(c));
		}

		/// <summary>
		/// Gets all the matching words based on a tag.
		/// </summary>
		/// <param name="tag">Tag to search all the matching words.</param>
		/// <returns>List of words matching the tag supplied.</returns>
		public List<string> GetAutoCompleteWords(string tag)
		{
			var node = GetMatchingNode(tag);
			return node.Children.Where(c => c.Value != '$').Select(w => w.Value).Select(a => tag + a).ToList();
		}

		/// <summary>
		/// Gets the node matching the characters in a string.
		/// </summary>
		/// <param name="s">String to get the keyword node.</param>
		/// <returns>Node containing one or more characters of the given string.</returns>
		private Node GetMatchingNode(string s)
		{
			var currentNode = RootNode;
			foreach (char c in s)
			{
				var node = currentNode.FindChild(c);
				if (node == null)
					break;
				currentNode = node;
			}

			return currentNode;
		}

	}
}
