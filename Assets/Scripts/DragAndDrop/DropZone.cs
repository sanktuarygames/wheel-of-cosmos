using UnityEngine;

public class DropZone : MonoBehaviour
{
    public bool IsOccupied
    {
        get { return transform.childCount > 0; }
    }
    [SerializeField] private Material baseMat = null;
    [SerializeField] private Material highlightMat = null;
    public Vector3 offsetPosition;

    [Header("Current Item")]
    public GameObject currentItem = null;
    private Vector3 removePosition = new Vector3(13f, -1f, 0);
    DropZoneController dropZoneController;
    
    void Start()
    {
        // baseMat = GetComponent<MeshRenderer>().material;
        dropZoneController = GetComponentInParent<DropZoneController>();
        if (transform.childCount == 0) return;
        currentItem = transform.GetChild(0)?.gameObject;
    }

    public virtual void RemoveItem()
    {
        if (currentItem != null)
        {
            currentItem.GetComponent<Rigidbody>().isKinematic = false;
            currentItem = null;
        }
    }

    public virtual void AddItem(GameObject slice)
    {
        // If the drop zone is occupied, return the slice to the helper position
        if (currentItem != null)
        {
            if (dropZoneController.GetEmptyDropZone() != null) {
                dropZoneController.GetEmptyDropZone().AddItem(currentItem);
            } else {
                currentItem.transform.position = removePosition; // TODO: this will be the helper position, where created slices will be placed
            }
            RemoveItem();
        }

        currentItem = slice;
        currentItem.transform.SetParent(transform);
        currentItem.transform.localScale = Vector3.one;
        currentItem.transform.position = transform.position + offsetPosition;
        currentItem.transform.rotation = transform.rotation;
        currentItem.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Highlight()
    {
        if (highlightMat != null)
        {
            GetComponent<MeshRenderer>().material = highlightMat;
        }
    }

    public void Unhighlight()
    {
        if (highlightMat != null)
        {
            GetComponent<MeshRenderer>().material = baseMat;
        }
    }
}
