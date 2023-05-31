using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderObj : MonoBehaviour
{
    public int maxConectLineCount;
    public int conectLineCount;

    public void Set(int maxLine)
    {
        maxConectLineCount = maxLine;
        conectLineCount = 0;
    }

    public bool CheckLineCount()
    {
        return conectLineCount < maxConectLineCount;
    }
    public int GetMaxConectLineCount()
    {
        return maxConectLineCount;
    }


    public int GetConectLineCount()
    {
        return conectLineCount;
    }

    public GameObject GetSpiderObj()
    {
        return gameObject;
    }

    public Vector3 GetSpiderPos()
    {
        return gameObject.transform.position;
    }
}
