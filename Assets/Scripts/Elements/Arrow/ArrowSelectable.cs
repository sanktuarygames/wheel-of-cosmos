using UnityEngine;

public class ArrowSelectable : Selectable
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
    }
    
    public void LoadDisplay() {
        if (currentArrow == null) return;
        LoadArrow(currentArrow);
    }

    public void LoadArrow(Arrow arrow) {
        this.currentArrow = arrow;
        arrowDisplay.SetupDisplay(arrow);
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

        // If an arrow from the arsenal is selected
        if (currentlySelectedArrowArsenal != null)
        {
            // We give the value of the arsenal arrow to the current arrow
            LoadArrow(currentlySelectedArrowArsenal.currentArrow);
        }
        // If another arrow from the wheel is selected
        else if (currentlySelectedArrowSelectable != null)
        {
           GameMaster.Instance.currentCharacter.wheel.SwapArrows(currentlySelectedObject, gameObject);
           // TODO: Update the wheel display to show the new arrow positions
        }
    }
}
