using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllNodesDistanceKBinaryTree
{
	internal class AllNodesDistanceKBinaryTree
	{
		private readonly struct Node
		{
			public readonly TreeNode node;
			public readonly TreeNode parent;

			public Node(TreeNode node, TreeNode parent)
			{
				this.node = node;
				this.parent = parent;
			}
		}

		private readonly struct NodeDistance
		{
			public readonly int node;
			public readonly int distance;

			public NodeDistance(int node, int distance)
			{
				this.node = node;
				this.distance = distance;
			}
		}

		private Dictionary<int, List<int>> GetGraph(TreeNode root)
		{
			Dictionary<int, List<int>> graph = new();
			Stack<Node> st = new();
			st.Push(new Node(root, null));
			while(st.Count > 0)
			{
				Node curNode = st.Pop();
				TreeNode node = curNode.node;
				TreeNode parent = curNode.parent;
				if (!graph.ContainsKey(node.val))
				{
					graph.Add(node.val, new List<int>());
				}
				if (parent != null)
				{
					graph[node.val].Add(parent.val);
				}
				if (node.right != null)
				{
					graph[node.val].Add(node.right.val);
					st.Push(new Node(node.right, node));
				}
				if (node.left != null)
				{
					graph[node.val].Add(node.left.val);
					st.Push(new Node(node.left, node));
				}
			}
			return graph;
		}

		private void BFS(Dictionary<int, List<int>> graph, TreeNode target, List<int> answers, int k)
		{
			Queue<NodeDistance> queue = new();
			HashSet<int> visited = new() { target.val };
			queue.Enqueue(new NodeDistance(target.val, 0));
			while(queue.Count > 0)
			{
				NodeDistance nodeDistance = queue.Dequeue();
				if (nodeDistance.distance == k)
				{
					answers.Add(nodeDistance.node);
					continue;
                }
				if (graph.TryGetValue(nodeDistance.node, out List<int> neighbors))
				{
					foreach(int neighbor in neighbors)
					{
						if (visited.Add(neighbor))
						{
							queue.Enqueue(new NodeDistance(neighbor, nodeDistance.distance + 1));
						}
					}
				}
			}
		}

		public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
		{
			List<int> answers = new();
			Dictionary<int, List<int>> graph = GetGraph(root);
			BFS(graph, target, answers, k);
			return answers;
		}
	}
}
