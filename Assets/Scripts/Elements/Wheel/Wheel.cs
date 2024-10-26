using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Wheel : MonoBehaviour
{
    private WheelSO wheelSO;
    public DropZoneController arrowPositions;
    public DropZoneController slicePositions;
    public Arrow[] currentArrows = new Arrow[6];
    public Slice[] currentSlices = new Slice[6];

    public void Initialize() {
        Initialize(wheelSO);
    }

    public void Initialize(WheelSO newSO) {
        wheelSO = newSO;
        for (int i = 0; i < wheelSO.initialSlices.Length; i++) {
            currentSlices[i] = new GameObject("Slice").AddComponent<Slice>();
            currentSlices[i].Initialize(wheelSO.initialSlices[i]);
            // Use dropzone controller to add the slices to the places
            currentSlices[i].transform.SetParent(transform);
        }

        for (int i = 0; i < wheelSO.initialArrows.Length; i++) {
            currentArrows[i] = new GameObject("Arrow").AddComponent<Arrow>();
            currentArrows[i].Initialize(wheelSO.initialArrows[i]);
            currentArrows[i].transform.SetParent(transform);
            // Use dropzone controller to add the arrows to the places
        }
        
    }

    public void AddArrow(Arrow arrow) {
        for (int i = 0; i < currentArrows.Length; i++) {
            if (currentArrows[i] == null) {
                currentArrows[i] = arrow;
                break;
            }
        }
    }

    public void RemoveArrow(Arrow arrow) {
        for (int i = 0; i < currentArrows.Length; i++) {
            if (currentArrows[i] == arrow) {
                currentArrows[i] = null;
                break;
            }
        }
    }

    public void AddSlice(Slice slice) {
        for (int i = 0; i < currentSlices.Length; i++) {
            if (currentSlices[i] == null) {
                currentSlices[i] = slice;
                break;
            }
        }
    }

    public void RemoveSlice(Slice slice) {
        for (int i = 0; i < currentSlices.Length; i++) {
            if (currentSlices[i] == slice) {
                currentSlices[i] = null;
                break;
            }
        }
    }
}