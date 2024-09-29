using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wheel", menuName = "Elements/Wheel", order = 1)]
public class WheelSO : ScriptableObject
{
    public ArrowSO[] initialArrows;
    public SliceSO[] initialSlices;
}
