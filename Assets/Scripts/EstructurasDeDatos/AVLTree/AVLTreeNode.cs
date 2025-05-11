using System.Xml;
using UnityEngine;

public class AVLTreeNode
{
    public int Value { get; set; }
    public AVLTreeNode? Left { get; set; }
    public AVLTreeNode? Right { get; set; }
    public int Height { get; set; }
    public AVLTreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
        Height = 1;
    }
}
