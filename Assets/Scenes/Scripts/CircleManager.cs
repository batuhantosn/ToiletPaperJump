using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CircleManager : MonoBehaviour
{
    [SerializeField] private GameObject cylinder;
    [SerializeField] private GameObject piecePrefab;
    [SerializeField] private int editorCreateCircleAmount;
    [SerializeField] private int verticalDistance;

    [ContextMenu(nameof(EditorCreate))]
    public void EditorCreate()
    {
        Create(editorCreateCircleAmount);
    }
    public void Create(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            
            var current = CreateCircle(i);
            current.transform.parent = cylinder.transform;
            current.transform.position = new Vector3(0, 9-(i*verticalDistance), 0);
        }
    }

    private GameObject CreateCircle(int number)
    {
        
        var parent = new GameObject()
        {
            transform = { name = "circle" + number}
        };
        for (int i = 0; i < 8; i++)
        {
            var current = Instantiate(piecePrefab,parent.transform);
            current.transform.Rotate(0, (360 / 8) * i, 0);
        }
        return parent;
    }


}
