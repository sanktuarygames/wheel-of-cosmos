using UnityEngine;

public class SliceInventory : Selectable
{
    
    [Header("Selection Render Properties")]
    public Material highlightMaterial;
    public Material defaultMaterial;
    private MeshRenderer highlightRenderer;
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
        // Si lo que habia seleccionado es otro slice de la ruleta, cambia posicion
        SliceWheel currentlySelectedSlice = currentlySelectedObject.GetComponent<SliceWheel>();
        if (currentlySelectedSlice != null)
        {
            Transform tempTransform = transform;
            transform.position = currentlySelectedObject.transform.position;
            transform.rotation = currentlySelectedObject.transform.rotation;
            transform.localScale = currentlySelectedObject.transform.localScale;

            currentlySelectedObject.transform.position = tempTransform.position;
            currentlySelectedObject.transform.rotation = tempTransform.rotation;
            currentlySelectedObject.transform.localScale = tempTransform.localScale;
        }
        if (currentlySelectedSlice == this) {
            // Si es el mismo slice, deselecciona
            Unselect();
        }
        
        if (currentlySelectedSlice != null)
        {
            currentlySelectedSlice.Unselect();
        }
    }

    public override void Unselect(GameObject currentlySelectedObject = null)
    {
        base.Unselect();
    }
}
