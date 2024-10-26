using System;
using UnityEngine;

public class SliceEditView : MonoBehaviour
{
    // Uses
    public Slice editSlice;

    public void ChangeSliceType(SliceType newType)
    {
        editSlice.ChangeType(newType);
    }

    public void ChangeSliceValue(int value)
    {
        int newValue = editSlice.currentValue + value;
        editSlice.ChangeValue(newValue);
    }

    public void ChangeSliceEffect(string title)
    {
        editSlice.ChangeTitle(title);
    }

    public void RemoveSlice() {
        // This should call the WheelViewMaster to remove the slice from the wheel
    }

    public void Return() {
        // This should call the NavigationMaster to return to the wheel view
    }
}
