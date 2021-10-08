using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Node : MonoBehaviour
{
    public static event Action<Node> OnClicked = delegate { };

    public Vector3 Position => transform.position;
    public IEnumerable<Node> Neighbors => neighbors;

    [SerializeField] List<Node> neighbors;

    void OnMouseDown()
    {
        OnClicked(this);
        transform.DOPunchScale(Vector3.one * 1.1f, 0.175f);
    }

    void OnDrawGizmos()
    {
        if (neighbors == null) return;
        foreach (var node in neighbors)
        {
            Debug.DrawLine(Position, node.Position);
        }
    }
}
