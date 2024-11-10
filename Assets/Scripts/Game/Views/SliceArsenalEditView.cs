using System;
using UnityEngine;

public class SliceArsenalEditView : MonoBehaviour
{
    // Uses
    public Slice editSlice;
    [SerializeField] private CharacterView characterView;

    void OnEnable()
    {
        // This should call the WheelViewMaster to show the slice edit view
    }

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
    }

    public void RemoveSlice() {
        // This should call the WheelViewMaster to remove the slice from the wheel
    }

    public void Return() {
        // This should call the NavigationMaster to return to the wheel view
    }
}
