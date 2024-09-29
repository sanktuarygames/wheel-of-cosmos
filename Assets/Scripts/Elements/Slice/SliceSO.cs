using UnityEngine;

[CreateAssetMenu(fileName = "Slice", menuName = "Elements/Slice", order = 1)]
public class SliceSO : ScriptableObject
{
    public string title = "";
    public string description = "";
    public int initialValue = 1;
    public int maxValue = 3;
    public SliceType type;
    public Effect[] effects;
}
