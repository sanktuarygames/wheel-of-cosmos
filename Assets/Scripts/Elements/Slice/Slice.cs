using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slice : MonoBehaviour
{
    public SliceSO sliceSO;
    public string currentTitle;
    public int currentValue;
    public SliceType currentType;
    public SliceEffect currentEffect;

    public bool isLocked = false;
    public bool isVoid = false;

    // SO methods
    public void Initialize(SliceSO newSO)
    {
        sliceSO = newSO;
        ChangeValue(sliceSO.initialValue);
        ChangeEffect(sliceSO.effect);
        ChangeType(sliceSO.type);
        name = sliceSO.name + " [" + currentValue + "]";
        currentTitle = sliceSO.title;
    }

    public void LoadSlice(Slice slice) {
        ChangeValue(slice.currentValue);
        ChangeEffect(slice.currentEffect);
        ChangeType(slice.currentType);
        name = slice.sliceSO.name + " [" + currentValue + "]";
        currentTitle = slice.currentTitle;
    }

    public void ChangeTitle()
    {
        currentTitle = sliceSO.title;
    }

    // Slice methods
    public void ChangeType(SliceType newType)
    {
        currentType = newType;
    }

    public void ChangeValue(int value)
    {
        currentValue = value;
        name = sliceSO.name + " [" + currentValue + "]";
    }

    public void ChangeEffect(SliceEffect effect)
    {
        currentEffect = effect;
    }
}
