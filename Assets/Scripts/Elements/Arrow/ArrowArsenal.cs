using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ArrowArsenal : Selectable
{
    [Header("Arrow Properties")]
    public Arrow currentArrow;
    public ArrowDisplay arrowDisplay;
    
    [Header("Selection Render Properties")]
    public Material highlightMaterial;
    public Material defaultMaterial;

    void Start()
    {
        arrowDisplay = GetComponent<ArrowDisplay>();
        arrowDisplay.SetupDisplay();
    }

    public override void Select(GameObject currentlySelectedObject = null)
    {
        base.Select();
        transform.parent.GetComponent<MeshRenderer>().material = highlightMaterial;
        
    }

    public override void Unselect(GameObject currentlySelectedObject = null)
    {
        base.Unselect();
        transform.parent.GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    public override void HandleInteraction(GameObject currentlySelectedObject) {
        ArrowArsenal currentlySelectedArrowArsenal = currentlySelectedObject.GetComponent<ArrowArsenal>();
        ArrowSelectable currentlySelectedArrowSelectable = currentlySelectedObject.GetComponent<ArrowSelectable>();

        // Selected arrow arsenal will be used to swap positions in the future
        if (currentlySelectedArrowSelectable != null)
        {
            CharacterView.instance.ReturnArrowToInventory(currentlySelectedArrowSelectable.arrowDisplay.currentArrow);
        }
    }
}
