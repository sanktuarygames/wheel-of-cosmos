using UnityEngine;

public class SliceSelectable : Selectable
{
    
    [Header("Selection Render Properties")]
    public Material highlightMaterial;
    public Material defaultMaterial;

    [Header("Display Properties")]
    public Slice slice;
    public SliceDisplay sliceDisplay;

    void Start()
    {
        sliceDisplay = GetComponent<SliceDisplay>();
    }

    public override void Select(GameObject currentlySelectedObject = null)
    {
        Debug.Log("Selecting " + currentlySelectedObject?.name);
        base.Select();
        if (currentlySelectedObject == null) {
            // Just selects the object
            transform.parent.GetComponent<MeshRenderer>().material = highlightMaterial;
        } else {
            HandleInteraction(currentlySelectedObject);
        }
    }

    public override void Unselect(GameObject currentlySelectedObject = null)
    {
        base.Unselect();
        // Depending on what was selected, we might need to do something, but for the moment there's no scenario, it's just prepared for that
        transform.parent.GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    public override void HandleInteraction(GameObject currentlySelectedObject) {
        SliceSelectable currentlySelectedSlice = currentlySelectedObject.GetComponent<SliceSelectable>();
        SliceArsenal currentlySelectedSliceArsenal = currentlySelectedObject.GetComponent<SliceArsenal>();

        // If a slice from the wheel is selected
        if (currentlySelectedSlice != null)
        {
            CharacterView.instance.SwapSlicesWheel(currentlySelectedSlice.sliceDisplay.currentSlice, sliceDisplay.currentSlice);            
        }
        // If a slice from the arsenal is selected
        else if (currentlySelectedSliceArsenal != null) {
            // Return this slice to the arsenal
            CharacterView.instance.ReturnSliceToArsenal(sliceDisplay.currentSlice);

            // Add the selected slice to the wheel
            CharacterView.instance.AddSliceToWheel(currentlySelectedSliceArsenal.sliceDisplay.currentSlice);
        }
    }
}
