using UnityEngine;

public class GrabbableSlice : Grabbable
{
    
    [Header("Position Properties")]
    // public DropZone currentPosition = null;
    public float positionMaxDistance = 20f;
    public string dropZoneTag = "SliceDropZone";
    // DropZoneController dropZoneController;
    GameObject[] dropZoneObjects;
    DropZone closestDropZone;
    DropZone initialDropZone;


    public override void Start()
    {
        base.Start();
        initialDropZone = transform.parent.GetComponent<DropZone>();
        dropZoneObjects = GameObject.FindGameObjectsWithTag(dropZoneTag);

        // dropZoneController = GameObject.FindWithTag(dropZoneTag).GetComponent<DropZoneController>();
    }

    public override void Update()
    {
        base.Update();
        if (isGrabbed)
        {
            float nearestDistance = Mathf.Infinity;
            Debug.Log(dropZoneObjects.Length);
            foreach (GameObject dropZone in dropZoneObjects)
            {
                float currentDistance = Vector3.Distance(transform.position, dropZone.transform.position);
                if (currentDistance < nearestDistance)
                {
                    Debug.Log("Closest drop zone");
                    closestDropZone = dropZone.GetComponent<DropZone>();
                    Debug.Log(closestDropZone.name);
                    nearestDistance = currentDistance;
                    closestDropZone.Highlight();
                }
            }
        }
    }

    public override void Drop()
    {
        base.Drop();
        if (closestDropZone != null)
        {
            closestDropZone.Unhighlight();
            closestDropZone.AddItem(gameObject);
        }
    }

    public override void Grab()
    {
        base.Grab();
        initialDropZone = transform.parent.GetComponent<DropZone>();

        if (initialDropZone != null)
        {
            initialDropZone.RemoveItem();
            initialDropZone = null;
        }
    }
}
