using UnityEngine;

public class GrabbableSlice : Grabbable
{
    
    [Header("Position Properties")]
    public DropZone currentPosition = null;
    public float positionMaxDistance = 20f;
    public string dropZoneTag = "SliceDropZone";
    DropZoneController dropZoneController;

    public override void Start()
    {
        base.Start();
        dropZoneController = GameObject.FindWithTag(dropZoneTag).GetComponent<DropZoneController>();
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
