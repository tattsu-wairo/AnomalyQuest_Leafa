using System.Collections.Generic;
using UnityEngine;

// CreateAssetMenu属性を使用することで`Assets > Create > ScriptableObjects > CommonData`という項目が表示される
// それを押すとこの`CommonData`が`CommonData`という名前でアセット化されてassetsフォルダに入る
[CreateAssetMenu(fileName = "CommonData", menuName = "ScriptableObjects/CommonData")]
public class CommonData : ScriptableObject
{
    [Header("スパイダーの出現数")]
    public int spiderNum;

    [Header("")]
    public float speed;

    public List<GameObject> spiderObjList;

    public List<GameObject> lineObjList;

    public List<int> lineCountList;
}