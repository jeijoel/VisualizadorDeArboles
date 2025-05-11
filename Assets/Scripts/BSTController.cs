using UnityEngine;

public class BSTController : MonoBehaviour
{
    public BSTVisualizer visualizer;

    private BST tree;

    void Start()
    {
        tree = new BST();
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(8);
        tree.Insert(2);
        tree.Insert(4);

        visualizer.Visualize(tree.GetRoot());
    }
}

