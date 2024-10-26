using UnityEngine;
using UnityEngine.Events;

// No son buttons, 
public class ButtonCharView : Grabbable
{
    
    [Header("Position Properties")]
    public DropZone currentPosition = null;
    public float positionMaxDistance = 20f;
    DropZoneController dropZoneController;

    public override void Start()
    {
        base.Start();
        DropZone dropZone = GetComponentInParent<DropZone>();
        dropZoneController = dropZone.GetComponentInParent<DropZoneController>();
    }

    public override void Update()
    {
        base.Update();
        if (isGrabbed)
        {
            
            dropZoneController.HighlightClosestDropZone(transform.position);
        }
    }

    public override void Drop()
    {
        base.Drop();
        currentPosition = dropZoneController?.GetClosestDropZone(transform.position);
        if (currentPosition != null)
        {
            currentPosition.Unhighlight();
            currentPosition.AddItem(gameObject);
        }
    }

    public override void Grab()
    {
        base.Grab();

        if (currentPosition != null)
        {
            currentPosition.RemoveItem();
            currentPosition = null;
        }
    }
}