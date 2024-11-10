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
    }

    void Update()
    {
        if (isSelected)
        {
            // Display Effects
        }
    }

    public void LoadSlice(Slice slice) {
        this.slice = slice;
        sliceDisplay.SetupDisplay(slice);
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
            GameMaster.Instance.currentCharacter.wheel.SwapSlices(currentlySelectedObject, gameObject);
            // TODO: Update wheel display
            
        }
        // If a slice from the arsenal is selected
        else if (currentlySelectedSliceArsenal != null) {
            // Get the slice data and load it here. May include animations and shit in the future

            // Lock the slice in the arsenal
            GameMaster.Instance.currentCharacter.arsenal.LockSlice(currentlySelectedSliceArsenal.slice);
            
            // Load the arsenal slice data in the selected slice

            GameMaster.Instance.currentCharacter.wheel.ChangeSlice(slice, currentlySelectedSliceArsenal.slice);
            GetComponent<SliceDisplay>().SetupDisplay(currentlySelectedSliceArsenal.slice);

            // TODO: Update wheel and arsenal display
        }
    }
}
