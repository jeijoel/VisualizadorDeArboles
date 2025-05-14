using UnityEngine;
using System.Collections.Generic;
using System.Xml;

public class AVLTreeVisualizer : MonoBehaviour
{
    public GameObject nodePrefab;
    public GameObject linePrefab;
    public RectTransform panelTransform;
    public float horizontalSpacing = 1.5f;
    public float verticalSpacing = 2.0f;
    private Dictionary<AVLTreeNode, GameObject> nodeObjects = new Dictionary<AVLTreeNode, GameObject>();

    public void VisualizeTree(AVLTreeNode root)
    {
        ClearVisualization();
        if (root != null)
        {
            DrawNode(root, Vector2.zero, 0);
        }
    }
    void Start()
    {
        Debug.Log("Probando instancia de AVLNodeUI");
        GameObject testNode = Instantiate(nodePrefab, transform);
        var label = testNode.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        if (label != null)
        {
            label.text = "AVL";
        }
        else
        {
            Debug.LogWarning("No se encontró TextMeshProUGUI en el prefab.");
        }

        var rt = testNode.GetComponent<RectTransform>();
        rt.anchoredPosition = Vector2.zero;
    }

    private void DrawNode(AVLTreeNode node, Vector2 position, int depth)
    {
        if (node == null) return;

        // Crear el nodo visual
        GameObject nodeObj = Instantiate(nodePrefab, panelTransform);
        nodeObj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = node.value.ToString();// Asumiendo que AVLNode tiene un campo value
        nodeObjects[node] = nodeObj;

        // Calcular posiciones de hijos
        float childOffset = horizontalSpacing * Mathf.Pow(0.5f, depth);

        if (node.left != null)
        {
            Vector2 leftPos = position + new Vector2(-childOffset, -verticalSpacing);
            DrawNode(node.left, leftPos, depth + 1);
            DrawLine(position, leftPos);
        }

        if (node.right != null)
        {
            Vector2 rightPos = position + new Vector2(childOffset, -verticalSpacing);
            DrawNode(node.right, rightPos, depth + 1);
            DrawLine(position, rightPos);
        }
    }

    private void DrawLine(Vector2 from, Vector2 to)
    {
        GameObject line = Instantiate(linePrefab, panelTransform);
        RectTransform lineRect = line.GetComponent<RectTransform>();

        Vector2 direction = to - from;
        float distance = direction.magnitude;

        lineRect.sizeDelta = new Vector2(4f, distance); // grosor, largo
        lineRect.anchoredPosition = from + direction / 2;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        lineRect.rotation = Quaternion.Euler(0, 0, angle - 90);
    }


    private void ClearVisualization()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        nodeObjects.Clear();
    }
}