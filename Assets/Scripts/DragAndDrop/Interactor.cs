using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInputController))]
public class Interactor : MonoBehaviour
{
    public static Interactor instance { get; private set; }

    [Header("Grab Properties")]
    public LayerMask grabLayerMask;
    private GameObject selectedObject;
    [SerializeField] PlayerInputController playerInputController = null;
    [HideInInspector] public UnityEvent<GameObject> onGrabItem;
    public UnityEvent<GameObject> OnGrabItem => onGrabItem;
    [HideInInspector] public UnityEvent<GameObject> onDropItem;
    public UnityEvent<GameObject> OnDropItem => onDropItem;

    void Awake()
    {
        instance = this;
        if (instance != this)
        {
            Destroy(this);
        }
        playerInputController = GetComponent<PlayerInputController>();
        playerInputController.OnLeftClickEvent.AddListener(HandlePress);
    }

    void HandlePress(bool isPressed) {
        if (isPressed)
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null )
                {
                    IInteractable interactableItem = hit.collider.gameObject.GetComponent<IInteractable>();
                    if (interactableItem != null)
                    {
                        // Activate Interactable
                        interactableItem.Interact(this.gameObject);
                    }

                    // if grabbable interface, grab
                    IGrabbable grabbableItem = hit.collider.gameObject.GetComponent<IGrabbable>();
                    if (grabbableItem != null)
                    {
                        // Grab
                        Debug.Log(hit.collider.gameObject.name);
                        selectedObject = hit.collider.gameObject;
                        Cursor.visible = false;
                        grabbableItem.Grab();
                        onGrabItem.Invoke(selectedObject);
                    }
                }
            } else {
                // Drag object
            }
        } else {
            if (selectedObject != null)
            {
                IGrabbable grabbableItem = selectedObject.GetComponent<IGrabbable>();
                if (grabbableItem != null)
                {
                    // Drop
                    grabbableItem.Drop();
                    selectedObject = null;
                    Cursor.visible = true;
                    onDropItem.Invoke(selectedObject);
                }
            }
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
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, 5000f, grabLayerMask);

        return hit;
    }
}
