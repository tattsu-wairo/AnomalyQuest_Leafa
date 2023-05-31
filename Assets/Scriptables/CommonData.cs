using System.Collections.Generic;
using UnityEngine;

// CreateAssetMenu�������g�p���邱�Ƃ�`Assets > Create > ScriptableObjects > CommonData`�Ƃ������ڂ��\�������
// ����������Ƃ���`CommonData`��`CommonData`�Ƃ������O�ŃA�Z�b�g�������assets�t�H���_�ɓ���
[CreateAssetMenu(fileName = "CommonData", menuName = "ScriptableObjects/CommonData")]
public class CommonData : ScriptableObject
{
    [Header("�X�p�C�_�[�̏o����")]
    public int spiderNum;

    [Header("")]
    public float speed;

    public List<GameObject> spiderObjList;

    public List<GameObject> lineObjList;

    public List<int> lineCountList;
}