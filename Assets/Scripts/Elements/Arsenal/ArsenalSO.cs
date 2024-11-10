using UnityEngine;

[CreateAssetMenu(fileName = "Arsenal", menuName = "Elements/Arsenal", order = 1)]

public class ArsenalSO : ScriptableObject
{
    public string title;
    public GameObject arsenalPrefab;
    public SliceSO[] initialArsenalSlices;
}
