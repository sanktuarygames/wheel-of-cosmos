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

    public void SwapSlices(GameObject initialSlice, GameObject finalSlice) {
        Slice initial = initialSlice.GetComponent<SliceDisplay>().currentSlice;
        Slice final = finalSlice.GetComponent<SliceDisplay>().currentSlice;
        int initialIndex = FindBySlice(initial);
        int finalIndex = FindBySlice(final);
        currentSlices[initialIndex] = final;
        currentSlices[finalIndex] = initial;
    }

    public void SwapArrows(GameObject initialArrow, GameObject finalArrow) {
        Arrow initial = initialArrow.GetComponent<ArrowDisplay>().currentArrow;
        Arrow final = finalArrow.GetComponent<ArrowDisplay>().currentArrow;
        int initialIndex = FindByArrow(initial);
        int finalIndex = FindByArrow(final);
        currentArrows[initialIndex] = final;
        currentArrows[finalIndex] = initial;
    }
}