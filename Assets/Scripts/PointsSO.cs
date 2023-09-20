using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PointHole", menuName = "ScriptableObjects/Points", order = 1)]
public class PointsSO : ScriptableObject
{
    [Range(1, 20)] public int amountPoints;
    public bool isEnd;
}
