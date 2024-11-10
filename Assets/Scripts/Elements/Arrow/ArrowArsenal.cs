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
            // We remove the arrow from the wheel
            GameMaster.Instance.currentCharacter.wheel.RemoveArrow(currentlySelectedArrowSelectable.currentArrow);
            // And we add it to the inventory
            GameMaster.Instance.currentCharacter.inventory.AddArrow(currentlySelectedArrowSelectable.currentArrow.arrowSO);
            // TODO: Update inventory and wheel display
        }
    }
}
