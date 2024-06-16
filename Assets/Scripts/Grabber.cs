using UnityEngine;
using UnityEngine.Events;

public class Grabber : MonoBehaviour
{

    public LayerMask grabLayerMask;
    public float dragForce = 20f;
    
    [Header("Y Boundaries")]
    public Vector2 yGrabBoundaries = new Vector2(-1f, 1f);


    private GameObject selectedObject;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                // Check if the object is in layer ground
                if (hit.collider != null && hit.collider.gameObject.GetComponent<Slice>())
                {
                    // Grab
                    Debug.Log(hit.collider.gameObject.name);
                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                    selectedObject.GetComponent<Slice>().Grab();
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(1))
                {
                    selectedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    selectedObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    Debug.Log(selectedObject.transform.rotation.eulerAngles.x);
                    if (selectedObject.transform.rotation.eulerAngles.x <= 265 || selectedObject.transform.rotation.eulerAngles.x >= 275)
                    {
                        Debug.Log("Fixing");
                        selectedObject.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
                        selectedObject.transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
                    }
                    Debug.Log("Rotating");
                    selectedObject.transform.rotation = Quaternion.Euler(new Vector3(
                        selectedObject.transform.rotation.eulerAngles.x,
                        selectedObject.transform.rotation.eulerAngles.y + 90f,
                        selectedObject.transform.rotation.eulerAngles.z)
                    );
                }

                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);


                if (Vector3.Distance(selectedObject.transform.position, worldPosition) < 0.1f)
                {
                    selectedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    return;
                }
                // Calculate the direction from the transform position to the position
                Vector3 direction = worldPosition - selectedObject.transform.position;
                direction = direction.normalized;
                if (selectedObject.transform.position.y > selectedObject.GetComponent<Slice>().yGrabBoundaries.x && selectedObject.transform.position.y < selectedObject.GetComponent<Slice>().yGrabBoundaries.y)
                {
                    direction.y = 1.2f;
                }
                selectedObject.GetComponent<Rigidbody>().velocity = direction * dragForce;
                // selectedObject.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));

            }
        }
        else if (Input.GetMouseButtonUp(0) && selectedObject != null)
        {
            // Drop
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            // selectedObject.transform.position = new Vector3(worldPosition.x, 0f, worldPosition.z);
            selectedObject.GetComponent<Slice>().Drop();
            selectedObject = null;
            Cursor.visible = true;
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, 1000f, grabLayerMask);

        return hit;
    }
}
