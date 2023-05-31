using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    public GameObject spiderObjPrefab;
    public GameObject lineObjPrefab;
    public CommonData commonData;
    public Transform rangeA;
    public Transform rangeB;

    private GameObject spawnSpiderObj;

    private Vector3 startPos;
    private Vector3 endPos;
    private List<LineObj> lineNumberList;

    // Start is called before the first frame update
    void Start()
    {
        commonData.spiderObjList.Clear();
        commonData.lineObjList.Clear();
        for (int i = 0; i < commonData.spiderNum; i++)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            int x = Random.Range((int)rangeA.position.x, (int)rangeB.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            int y = Random.Range((int)rangeA.position.y, (int)rangeB.position.y);
            spawnSpiderObj = Instantiate(spiderObjPrefab, new Vector3(x, y, 0), Quaternion.identity);
            spawnSpiderObj.GetComponent<SpiderObj>().Set(commonData.lineCountList[i]);
            commonData.spiderObjList.Add(spawnSpiderObj);
        }

        for (int i = 0; i < commonData.spiderObjList.Count - 1; i++)
        {
            GameObject lineObj;
            switch (i)
            {
                case 0:
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 1);
                    commonData.lineObjList.Add(lineObj);
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 3);
                    commonData.lineObjList.Add(lineObj);
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 4);
                    commonData.lineObjList.Add(lineObj);
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 5);
                    commonData.lineObjList.Add(lineObj);
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 6);
                    commonData.lineObjList.Add(lineObj);
                    break;
                case 1:
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 2);
                    commonData.lineObjList.Add(lineObj);
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 3);
                    commonData.lineObjList.Add(lineObj);
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 5);
                    commonData.lineObjList.Add(lineObj);
                    break;
                case 2:
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 3);
                    commonData.lineObjList.Add(lineObj);
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 4);
                    commonData.lineObjList.Add(lineObj);
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 5);
                    commonData.lineObjList.Add(lineObj);
                    break;
                case 3:
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 4);
                    commonData.lineObjList.Add(lineObj);
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 6);
                    commonData.lineObjList.Add(lineObj);
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 7);
                    commonData.lineObjList.Add(lineObj);
                    break;
                case 4:
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 5);
                    commonData.lineObjList.Add(lineObj);
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 6);
                    commonData.lineObjList.Add(lineObj);
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 7);
                    commonData.lineObjList.Add(lineObj);
                    break;
                case 5:
                    break;
                case 6:
                    lineObj = Instantiate(lineObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    lineObj.GetComponent<LineObj>().Set(i, 7);
                    commonData.lineObjList.Add(lineObj);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (commonData.lineObjList.Count <= 0) return;
        foreach (GameObject lineObj in commonData.lineObjList)
        {
            lineObj.GetComponent<LineObj>().UpdateLinePos(commonData);
            lineObj.GetComponent<LineObj>().SetColor(Color.white);
        }

        for (int i = 0; i < commonData.lineObjList.Count - 1; i++)
        {
            Vector2 startPoint1 = commonData.lineObjList[i].GetComponent<LineObj>().GetLineColliderStartPos();
            Vector2 endPoint1 = commonData.lineObjList[i].GetComponent<LineObj>().GetLineColliderEndPos();
            for (int j = i + 1; j < commonData.lineObjList.Count; j++)
            {
                Vector2 startPoint2 = commonData.lineObjList[j].GetComponent<LineObj>().GetLineColliderStartPos();
                Vector2 endPoint2 = commonData.lineObjList[j].GetComponent<LineObj>().GetLineColliderEndPos();
                var isCrossing = IsLineCrossing(startPoint1, endPoint1, startPoint2, endPoint2);
                if (isCrossing)
                {
                    commonData.lineObjList[i].GetComponent<LineObj>().SetColor(Color.red);
                    commonData.lineObjList[j].GetComponent<LineObj>().SetColor(Color.red);
                }
            }
        }

        for (int i = 0; i < commonData.spiderObjList.Count; i++)
        {
            for (int j = 0; j < commonData.lineObjList.Count; j++)
            {
                if (commonData.lineObjList[j].GetComponent<LineObj>().startIndex == i) continue;
                if (commonData.lineObjList[j].GetComponent<LineObj>().endIndex == i) continue;
                Vector2 startLinePos = commonData.lineObjList[j].GetComponent<LineObj>().GetLineStartPos(commonData);
                Vector2 endLinePos = commonData.lineObjList[j].GetComponent<LineObj>().GetLineEndPos(commonData);
                Vector2 spiderPos = commonData.spiderObjList[i].transform.position;
                float radius = 0.3f;
                if (IsLineIntersectedCircle(startLinePos, endLinePos, spiderPos, radius))
                {
                    commonData.lineObjList[j].GetComponent<LineObj>().SetColor(Color.red);
                }
            }
        }
    }

    // 線分の交差判定
    private static bool IsLineCrossing(Vector2 startPoint1, Vector2 endPoint1, Vector2 startPoint2, Vector2 endPoint2)
    {
        // ベクトルP1Q1
        var vector1 = endPoint1 - startPoint1;
        // ベクトルP2Q2
        var vector2 = endPoint2 - startPoint2;
        //
        // 以下条件をすべて満たすときが交差となる
        //
        //    P1Q1 x P1P2 と P1Q1 x P1Q2 が異符号
        //                かつ
        //    P2Q2 x P2P1 と P2Q2 x P2Q1 が異符号
        //
        return LineCross(vector1, startPoint2 - startPoint1) * LineCross(vector1, endPoint2 - startPoint1) < 0 &&
               LineCross(vector2, startPoint1 - startPoint2) * LineCross(vector2, endPoint1 - startPoint2) < 0;
    }

    // 2次元ベクトルの外積を返す
    private static float LineCross(Vector2 vector1, Vector2 vector2)
        => vector1.x * vector2.y - vector1.y * vector2.x;

    private bool IsLineIntersectedCircle(Vector2 a, Vector2 b, Vector2 p, float radius)
    {
        Vector2 ap = p - a;
        Vector2 ab = b - a;
        Vector2 bp = p - b;
        Vector2 normalAB = ab.normalized;

        float lenAX = Vector2.Dot(normalAB, ap);

        float shortestDistance = 0.0f;
        if (lenAX < 0)
        {
            shortestDistance = ap.magnitude;
        }
        else if (lenAX > ab.magnitude)
        {
            shortestDistance = bp.magnitude;
        }
        else
        {
            shortestDistance = Mathf.Abs(Vector3.Cross(normalAB, ap).magnitude);
        }

        Vector2 X = a + ab * lenAX;
        return shortestDistance < radius;
    }

}
