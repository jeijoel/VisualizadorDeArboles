using UnityEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


public class AVLTree
{
    internal AVLTreeNode? root;
    internal int height(AVLTreeNode node)
    {
        if (node == null)
            return 0;
        return node.Height;

    }
    internal int getBalace(AVLTreeNode node)
    {
        if (node == null)
            return 0;
        return height(node.Left) - height(node.Right);
    }
    private AVLTreeNode rightRotate(AVLTreeNode y)
    {
        AVLTreeNode x = y.Left;
        AVLTreeNode T2 = x.Right;
        // Perform rotation
        x.Right = y;
        y.Left = T2;
        // Update heights
        y.Height = Math.Max(height(y.Left), height(y.Right)) + 1;
        x.Height = Math.Max(height(x.Left), height(x.Right)) + 1;
        // Return new root
        return x;
    }
    private AVLTreeNode leftRotate(AVLTreeNode x)
    {
        AVLTreeNode y = x.Right;
        AVLTreeNode T2 = y.Left;
        // Perform rotation
        y.Left = x;
        x.Right = T2;
        // Update heights
        x.Height = Math.Max(height(x.Left), height(x.Right)) + 1;
        y.Height = Math.Max(height(y.Left), height(y.Right)) + 1;
        // Return new root
        return y;
    }
    public void insert(int value)
    {
        root = insertRecursive(root, value);
    }
    private AVLTreeNode insertRecursive(AVLTreeNode node, int value)
    {
        // Perform the normal BST insertion
        if (node == null)
            return new AVLTreeNode(value);
        if (value < node.Value)
            node.Left = insertRecursive(node.Left, value);
        else if (value > node.Value)
            node.Right = insertRecursive(node.Right, value);
        else
            return node; // Duplicate values are not allowed
        // Update height of this ancestor node
        node.Height = 1 + Math.Max(height(node.Left), height(node.Right));
        // Get the balance factor
        int balance = getBalace(node);
        // If the node becomes unbalanced, then there are 4 cases
        // Left Left Case
        if (balance > 1 && value < node.Left.Value)
            return rightRotate(node);
        // Right Right Case
        if (balance < -1 && value > node.Right.Value)
            return leftRotate(node);
        // Left Right Case
        if (balance > 1 && value > node.Left.Value)
        {
            node.Left = leftRotate(node.Left);
            return rightRotate(node);
        }
        // Right Left Case
        if (balance < -1 && value < node.Right.Value)
        {
            node.Right = rightRotate(node.Right);
            return leftRotate(node);
        }
        // Return the (unchanged) node pointer
        return node;
    }
    public AVLTreeNode delete(int value)
    {
        root = deleteRecursive(root, value);
        return root;
    }
    public AVLTreeNode deleteRecursive(AVLTreeNode root, int value)
    {
        // STEP 1: PERFORM STANDARD BST DELETE
        if (root == null)
            return root;
        if (value < root.Value)
            root.Left = deleteRecursive(root.Left, value);
        else if (value > root.Value)
            root.Right = deleteRecursive(root.Right, value);
        else
        {
            // node with only one child or no child
            if ((root.Left == null) || (root.Right == null))
            {
                AVLTreeNode temp = root.Left != null ? root.Left : root.Right;
                // No child case
                if (temp == null)
                {
                    temp = root;
                    root = null;
                }
                else
                    root = temp; // One child case
            }
            else
            {
                // node with two children: Get the inorder successor (smallest in the right subtree)
                AVLTreeNode temp = minValueNode(root.Right);
                // Copy the inorder successor's content to this node
                root.Value = temp.Value;
                // Delete the inorder successor
                root.Right = deleteRecursive(root.Right, temp.Value);
            }
        }
        // If the tree had only one node then return
        if (root == null)
            return root;
        // STEP 2: UPDATE HEIGHT OF THIS ANCESTOR NODE
        root.Height = Math.Max(height(root.Left), height(root.Right)) + 1;
        // STEP 3: GET THE BALANCE FACTOR OF THIS ANCESTOR NODE TO CHECK WHETHER THIS NODE BECAME UNBALANCED
        int balance = getBalace(root);
        // If this node becomes unbalanced, then there are 4 cases
        // Left Left Case
        if (balance > 1 && getBalace(root.Left) >= 0)
            return rightRotate(root);
        // Left Right Case
        if (balance > 1 && getBalace(root.Left) < 0)
        {
            root.Left = leftRotate(root.Left);
            return rightRotate(root);
        }
        // Right Right Case
        if (balance < -1 && getBalace(root.Right) <= 0)
            return leftRotate(root);
        // Right Left Case
        if (balance < -1 && getBalace(root.Right) > 0)
        {
            root.Right = rightRotate(root.Right);
            return leftRotate(root);
        }
        return root;


    }
    public AVLTreeNode minValueNode(AVLTreeNode node)
    {
        AVLTreeNode current = node;
        // loop down to find the leftmost leaf
        while (current.Left != null)
            current = current.Left;
        return current;
    }
}

