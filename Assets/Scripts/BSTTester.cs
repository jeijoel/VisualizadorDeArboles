using UnityEngine;

public class BSTTester : MonoBehaviour
{
    void Start()
    {
        BST tree = new BST();
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(8);
        tree.Insert(2);
        tree.Insert(4);

        Debug.Log("Recorrido inorden del árbol:");
        InOrderTraversal(tree.GetRoot());
    }

    void InOrderTraversal(BSTNode<int> node)
    {
        if (node == null)
            return;

        InOrderTraversal(node.Left);
        Debug.Log("Valor del nodo: " + node.Value);
        InOrderTraversal(node.Right);
    }
}
