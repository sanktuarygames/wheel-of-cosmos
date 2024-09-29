using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SliceType", menuName = "Elements/SliceType", order = 1)]
[Serializable]
public class SliceType: ScriptableObject
{
    public int id;
    public string typeName;
    public Material material;

}
