using UnityEngine;

public class AVLController : MonoBehaviour
{
    public AVLTreeVisualizer visualizer;

    private AVLTree tree = new AVLTree();

    void Start()
    {
        int[] valores = { 30, 20, 10, 25, 40, 50, 60 };

        foreach (int val in valores)
        {
            tree.Insert(val);
        }

        visualizer.VisualizeTree(tree.root);

        Debug.Log("AVL root: " + (tree.root != null ? tree.root.value.ToString() : "null"));
    }
}
