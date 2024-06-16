using UnityEngine;

public class Void : MonoBehaviour
{
    [Header("Current Slice")]
    private Slice currentSlice = null;
    Transform cosmos;

    void Start()
    {
        cosmos = GameObject.Find("Cosmos").transform;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Slice>())
        {
            currentSlice = other.GetComponent<Slice>();
            if (!currentSlice.isGrabbed)
            {
                currentSlice.transform.SetParent(cosmos);
                Destroy(currentSlice.gameObject, 0f);
            }
        }
    }
}
