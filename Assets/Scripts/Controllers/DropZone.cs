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

    [Header("Current Slice")]
    public GameObject currentSlice = null;
    private Vector3 removePosition = new Vector3(13f, -1f, 0);
    DropZoneController dropZoneController;
    
    void Start()
    {
        // baseMat = GetComponent<MeshRenderer>().material;
        dropZoneController = GetComponentInParent<DropZoneController>();
        if (transform.childCount == 0) return;
        currentSlice = transform.GetChild(0)?.gameObject;
        currentSlice.transform.localScale = Vector3.one;
    }

    public virtual void RemoveSlice()
    {
        if (currentSlice != null)
        {
            currentSlice.GetComponent<Rigidbody>().isKinematic = false;
            currentSlice = null;
        }
    }

    public virtual void AddSlice(GameObject slice)
    {
        if (currentSlice != null)
        {
            if (dropZoneController.GetEmptyDropZone() != null) {
                dropZoneController.GetEmptyDropZone().AddSlice(currentSlice);
            } else {
                currentSlice.transform.position = removePosition; // TODO: this will be the helper position, where created slices will be placed
            }
            RemoveSlice();
        }

        currentSlice = slice;
        currentSlice.transform.SetParent(transform);
        currentSlice.transform.localScale = Vector3.one;
        currentSlice.transform.position = transform.position + offsetPosition;
        currentSlice.transform.rotation = transform.rotation;
        currentSlice.GetComponent<Rigidbody>().isKinematic = true;
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
