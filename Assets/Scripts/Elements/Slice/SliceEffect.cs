using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SliceType", menuName = "Elements/SliceType", order = 1)]
[Serializable]
public class SliceEffect: ScriptableObject
{
    public int id;
    public string display;
    public string effectDescription;
    public SliceType type;
    public Effect[] effects;

}
