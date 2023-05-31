using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObj : MonoBehaviour
{
    public int startIndex;
    public int endIndex;
    public LineRenderer lineRenderer;
    public EdgeCollider2D col;

    public void Set(int start, int end)
    {
        startIndex = start;
        endIndex = end;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        col = gameObject.GetComponent<EdgeCollider2D>();
    }

    public GameObject GetLineObj()
    {
        return gameObject;
    }

    public Vector2 GetLineNumber()
    {
        int multi = startIndex * endIndex;
        int plus = startIndex + endIndex;
        return new Vector2(multi, plus);
    }

    public Vector2 GetLineStartPos(CommonData commonData)
    {
        return commonData.spiderObjList[startIndex].transform.position;
    }

    public Vector2 GetLineEndPos(CommonData commonData)
    {
        return commonData.spiderObjList[endIndex].transform.position;
    }

    public Vector2 GetLineColliderStartPos()
    {
        return col.points[0];
    }

    public Vector2 GetLineColliderEndPos()
    {
        return col.points[1];
    }

    public void SetColor(Color color)
    {
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }

    public void UpdateLinePos(CommonData commonData)
    {
        Vector3 startPos = commonData.spiderObjList[startIndex].transform.position;
        Vector3 endPos = commonData.spiderObjList[endIndex].transform.position;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);

        Vector3 colliderStartPos = Vector3.MoveTowards(startPos, endPos, 0.1f);
        Vector3 colliderEndPos = Vector3.MoveTowards(endPos, startPos, 0.1f);

        List<Vector2> colliderPoint = new List<Vector2> { colliderStartPos, colliderEndPos };
        col.SetPoints(colliderPoint);
    }
}
