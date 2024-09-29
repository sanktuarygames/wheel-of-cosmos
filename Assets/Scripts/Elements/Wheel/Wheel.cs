using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class Wheel : MonoBehaviour
{
    public GameObject[] arrowPositions;
    public GameObject[] slicePositions;
    public WheelSO wheelSO;
    private Arrow[] currentArrows;
    private Slice[] currentSlices;
    
    // SO methods
    public void Initialize(WheelSO newSO) {
        wheelSO = newSO;
    }
}