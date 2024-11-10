using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Arsenal : MonoBehaviour
{
    public ArsenalSO arsenalSO;
    public GameObject arsenalPrefab;
    public Slice[] currentSlices = new Slice[12];

    public void Initialize()
    {
        Initialize(arsenalSO);
    }
    public void Initialize(ArsenalSO newArsenalSO)
    {
        arsenalSO = newArsenalSO;
        currentSlices = new Slice[12];

        for (int i = 0; i < arsenalSO.initialArsenalSlices.Length; i++) {
            currentSlices[i] = new GameObject("SliceArsenal").AddComponent<Slice>();
            currentSlices[i].Initialize(arsenalSO.initialArsenalSlices[i]);
            currentSlices[i].transform.SetParent(transform);
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

    public void UnlockSlice(Slice slice) {
        for (int i = 0; i < currentSlices.Length; i++) {
            if (currentSlices[i] == slice) {
                currentSlices[i].isLocked = false;
                break;
            }
        }
    }   

    public void LockSlice(Slice slice) {
        for (int i = 0; i < currentSlices.Length; i++) {
            if (currentSlices[i] == slice) {
                currentSlices[i].isLocked = true;
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

    public void AddSliceBySO(SliceSO sliceSO) {
        Slice newSlice = new GameObject("SliceArsenal").AddComponent<Slice>();
        newSlice.Initialize(sliceSO);
        newSlice.transform.SetParent(transform);
        AddSlice(newSlice);
    }

    public void SwapSlices(GameObject initialSlice, GameObject finalSlice) {
        Slice initial = initialSlice.GetComponent<SliceDisplay>().currentSlice;
        Slice final = finalSlice.GetComponent<SliceDisplay>().currentSlice;
        int initialIndex = FindBySlice(initial);
        int finalIndex = FindBySlice(final);
        currentSlices[initialIndex] = final;
        currentSlices[finalIndex] = initial;
    }
}
