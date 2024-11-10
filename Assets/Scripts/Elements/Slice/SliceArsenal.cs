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
            CharacterView.instance.ReturnSliceToArsenal(currentlySelectedSlice.sliceDisplay.currentSlice);
        }
        // If a slice from the arsenal is selected
        else if (currentlySelectedSliceArsenal != null) {
            CharacterView.instance.SwapSlicesArsenal(currentlySelectedSliceArsenal.sliceDisplay.currentSlice, sliceDisplay.currentSlice);
        }
    }
}
