using UnityEngine;

public class AVLTester : MonoBehaviour
{
    void Start()
    {
        AVLTree tree = new AVLTree();
        int[] values = { 10, 20, 30, 40, 50, 25 };

        foreach (int val in values)
        {
            tree.Insert(val);
        }

        Debug.Log("�rbol AVL creado con inserciones.");
        // Aqu� puedes usar tu l�gica de visualizaci�n ya hecha para el BST adaptada al AVL.
    }
}

