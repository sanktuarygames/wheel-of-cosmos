using UnityEngine;

public class Void : MonoBehaviour
{
    [Header("Current Grabbable")]
    private Grabbable currentGrabbable = null;
    Transform cosmos;

    void Start()
    {
        cosmos = GameObject.Find("Cosmos").transform;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Grabbable>())
        {
            currentGrabbable = other.GetComponent<Grabbable>();
            if (!currentGrabbable.isGrabbed)
            {
                currentGrabbable.transform.SetParent(cosmos);
                Destroy(currentGrabbable.gameObject, 0f);
            }
        }
    }
}
