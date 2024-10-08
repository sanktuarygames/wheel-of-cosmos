using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Wheel : MonoBehaviour
{
    public WheelSO wheelSO;
    public DropZone[] arrowPositions;
    public DropZone[] slicePositions;
    public List<Arrow> currentArrows;
    public Slice[] currentSlices;

    public Wheel(WheelSO newSO) {
        Initialize(newSO);
    }
    
    // SO methods
    public void Initialize() {
        
    }

    public void Initialize(WheelSO newSO) {
        wheelSO = newSO;
        
    }
}