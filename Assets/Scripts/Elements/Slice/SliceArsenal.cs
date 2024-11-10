using TMPro;
using UnityEngine;

public class SliceArsenal : Selectable
{
    [Header("Slice Arsenal Properties")]
    public Slice slice;
    public bool isLocked = false;

    [Header("Selection Properties")]
    public Material highlightMaterial;
    public Material defaultMaterial;

    [Header("Display Properties")]
    public SliceDisplay sliceDisplay;


    void Start()
    {
    }

    void Update()
    {
        if (isSelected)
        {
            // Display Effects
        }
    }

    public void LoadDisplay() {
        if (slice == null) return;
        LoadDisplay(slice);
    }

    public void LoadDisplay(Slice slice) {
        this.slice = slice;
        sliceDisplay.SetupDisplay(slice);
    }

    public override void Select(GameObject currentlySelectedObject = null)
    {
        base.Select();
        if (currentlySelectedObject == null) {
            transform.parent.GetComponent<MeshRenderer>().material = highlightMaterial;
            return;
        }
    }

    public override void Unselect(GameObject currentlySelectedObject = null)
    {
        base.Unselect();
        transform.parent.GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    public override void HandleInteraction(GameObject currentlySelectedObject) {
        SliceSelectable currentlySelectedSlice = currentlySelectedObject.GetComponent<SliceSelectable>();
        SliceArsenal currentlySelectedSliceArsenal = currentlySelectedObject.GetComponent<SliceArsenal>();

        // If a slice from the wheel is selected
        if (currentlySelectedSlice != null)
        {
            // Remove the slice from the wheel
            GameMaster.Instance.currentCharacter.wheel.RemoveSlice(currentlySelectedSlice.slice);
            // Find the slice in the arsenal list and lock it
            GameMaster.Instance.currentCharacter.arsenal.LockSlice(slice);
            // TODO: Update wheel and arsenal display
                        
        }
        // If a slice from the arsenal is selected
        else if (currentlySelectedSliceArsenal != null) {
            // Swap the positions of the two slices
            GameMaster.Instance.currentCharacter.arsenal.SwapSlices(currentlySelectedObject, gameObject);
            // TODO: Update the arsenal display
        }
    }
}
