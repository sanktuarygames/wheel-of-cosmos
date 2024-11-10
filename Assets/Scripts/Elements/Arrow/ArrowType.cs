using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ArrowType", menuName = "Elements/ArrowType", order = 1)]
[Serializable]
public class ArrowType: ScriptableObject
{
    public int id;
    public string typeName;
    public BaseType baseType;
    public Material material;
}

