// See https://aka.ms/new-console-template for more information
using AllNodesDistanceKBinaryTree;

AllNodesDistanceKBinaryTree.AllNodesDistanceKBinaryTree allNodesDistanceKBinaryTree = new();
TreeNode root1 = new(3)
{
	left = new(5)
	{
		left = new(6),
		right = new(2)
		{
			left = new(7),
			right = new(4)
		}
	},
	right = new(1)
	{
		left = new(0),
		right = new(8)
	}
};
TreeNode root2 = new(1);
Console.WriteLine(string.Join(", ", allNodesDistanceKBinaryTree.DistanceK(root1, root1.left, 2)));
Console.WriteLine(string.Join(", ", allNodesDistanceKBinaryTree.DistanceK(root2, root2, 3)));