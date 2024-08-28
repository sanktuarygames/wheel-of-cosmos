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
    Transform cosmos;
    
    void Start()
    {
        // baseMat = GetComponent<MeshRenderer>().material;
        cosmos = GameObject.Find("Cosmos").transform;
        if (transform.childCount == 0) return;
        currentSlice = transform.GetChild(0)?.gameObject;
        currentSlice.transform.localScale = Vector3.one;
    }

    public virtual void RemoveSlice()
    {
        if (currentSlice != null)
        {
            // currentSlice.transform.SetParent(cosmos, true);
            // currentSlice.transform.localScale = transform.parent.localScale;
            currentSlice.GetComponent<Rigidbody>().isKinematic = false;
            currentSlice = null;
        }
    }

    public virtual void AddSlice(GameObject slice)
    {
        if (currentSlice != null)
        {
            currentSlice.transform.position = removePosition;
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
