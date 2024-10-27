using UnityEngine;

[CreateAssetMenu(fileName = "Arrow", menuName = "Elements/Arrow", order = 1)]
public class ArrowSO : ScriptableObject
{
    public string title = "";
    public ArrowType type = null;
    public Effect[] effects;
}