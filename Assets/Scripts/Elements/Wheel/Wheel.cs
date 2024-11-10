using UnityEngine;

public class Wheel : MonoBehaviour
{
    private WheelSO wheelSO;
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
            currentSlices[i].transform.SetParent(transform);
        }

        for (int i = 0; i < wheelSO.initialArrows.Length; i++) {
            currentArrows[i] = new GameObject("Arrow").AddComponent<Arrow>();
            currentArrows[i].Initialize(wheelSO.initialArrows[i]);
            currentArrows[i].transform.SetParent(transform);
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

    public void AddArrow(Arrow arrow, int index) {
        currentArrows[index] = arrow;
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

    public void AddSlice(Slice slice, int index) {
        currentSlices[index] = slice;
    }

    public void RemoveSlice(Slice slice) {
        for (int i = 0; i < currentSlices.Length; i++) {
            if (currentSlices[i] == slice) {
                currentSlices[i] = null;
                break;
            }
        }
    }

    public void ChangeSlice(Slice currentSlice, Slice newSlice) {
        int index = FindBySlice(currentSlice);
        currentSlices[index] = newSlice;
    }

    public void AddSliceValue(Slice slice) {
        for (int i = 0; i < currentSlices.Length; i++) {
            if (currentSlices[i] == slice) {
                currentSlices[i].currentValue++;
                break;
            }
        }
    }

    public void RemoveSliceValue(Slice slice) {
        for (int i = 0; i < currentSlices.Length; i++) {
            if (currentSlices[i] == slice) {
                currentSlices[i].currentValue--;
                break;
            }
        }
    }

    public void DisableSlice(Slice slice) {
        for (int i = 0; i < currentSlices.Length; i++) {
            if (currentSlices[i] == slice) {
                currentSlices[i].Initialize(Resources.Load<SliceSO>("ScriptableObjects/Slices/Void"));
                break;
            }
        }
    }

    public void DisableArrow(Arrow arrow) {
        for (int i = 0; i < currentArrows.Length; i++) {
            if (currentArrows[i] == arrow) {
                currentArrows[i].Initialize(Resources.Load<ArrowSO>("ScriptableObjects/Arrows/Void"));
                break;
            }
        }
    }

    public int FindBySlice(Slice slice) {
        for (int i = 0; i < currentSlices.Length; i++) {
            if (currentSlices[i] == slice) {
                return i;
            }
        }
        return -1;
    }

    public int FindByArrow(Arrow arrow) {
        for (int i = 0; i < currentArrows.Length; i++) {
            if (currentArrows[i] == arrow) {
                return i;
            }
        }
        return -1;
    }

    public void SwapSlices(Slice initialSlice, Slice finalSlice) {
        Debug.Log("Swapping slices " + initialSlice + " " + finalSlice);
        int initialIndex = FindBySlice(initialSlice);
        int finalIndex = FindBySlice(finalSlice);
        currentSlices[initialIndex] = finalSlice;
        currentSlices[finalIndex] = initialSlice;
    }

    public void SwapArrows(Arrow initialArrow, Arrow finalArrow) {
        Debug.Log("Swapping arrows " + initialArrow + " " + finalArrow);
        int initialIndex = FindByArrow(initialArrow);
        int finalIndex = FindByArrow(finalArrow);
        currentArrows[initialIndex] = finalArrow;
        currentArrows[finalIndex] = initialArrow;
    }
}