﻿namespace LeetCodeProblems.Trie;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode next;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null, TreeNode next = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
        this.next = next;
    }
}