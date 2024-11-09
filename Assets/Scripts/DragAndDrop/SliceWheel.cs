using UnityEngine;

public class SliceWheel : Selectable
{
    
    [Header("Selection Render Properties")]
    public Material highlightMaterial;
    public Material defaultMaterial;
    public Slice slice;
    // Dialog display
    // Effects


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

    public override void Select(GameObject currentlySelectedObject = null)
    {
        base.Select();
        if (currentlySelectedObject == null) {
            // Just selects the object
            transform.parent.GetComponent<MeshRenderer>().material = highlightMaterial;
            return;
        }
    
        SliceWheel currentlySelectedSlice = currentlySelectedObject.GetComponent<SliceWheel>();
        if (currentlySelectedSlice != null)
        {
            // Get the slice data and change

            Transform tempTransform = transform.parent;
            transform.parent = currentlySelectedObject.transform.parent;
            currentlySelectedObject.transform.parent = tempTransform;

            transform.localPosition = Vector3.zero;
            currentlySelectedObject.transform.localPosition = Vector3.zero;

            transform.localRotation = Quaternion.identity;
            currentlySelectedObject.transform.localRotation = Quaternion.identity;

            Unselect();
        }

        SliceInventory currentlySelectedSliceInventory = currentlySelectedObject.GetComponent<SliceInventory>();
        if (currentlySelectedSliceInventory != null) {
            // Get the slice data and load it here. May include animations and shit in the future
        }
    }

    public override void Unselect(GameObject currentlySelectedObject = null)
    {
        base.Unselect();
        // Depending on what was selected, we might need to do something, but for the moment there's no scenario, it's just prepared for that
        transform.parent.GetComponent<MeshRenderer>().material = defaultMaterial;
    }
}
