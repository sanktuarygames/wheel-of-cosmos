using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInputController))]
public class Selector : MonoBehaviour
{
    public static Selector instance { get; private set; }

    [Header("Grab Properties")]
    public LayerMask interactableMask;
    private GameObject currentSelectedObject;
    [SerializeField] PlayerInputController playerInputController = null;
    [HideInInspector] public UnityEvent<GameObject> onSelectItem;
    public UnityEvent<GameObject> OnSelectItem => onSelectItem;
    [HideInInspector] public UnityEvent<GameObject> onUnselectItem;
    public UnityEvent<GameObject> OnUnselectItem => onUnselectItem;

    void Awake()
    {
        instance = this;
        if (instance != this)
        {
            Destroy(this);
        }
        if (playerInputController == null)
        {
            playerInputController = GetComponent<PlayerInputController>();
        }
        playerInputController.OnLeftClickEvent.AddListener(HandlePress);
    }

    void HandlePress(bool isPressed) {
        // Debug.Log("HandlePress" + isPressed);
        // When pressing the button
        if (isPressed)
        {
            // It hits an object in the interactable layer
            RaycastHit hit = CastRay();
            if (hit.collider != null )
            {
                GameObject selectableGameObject = hit.collider.gameObject;
                if (selectableGameObject != null)
                {
                    IInteractable interactableItem = selectableGameObject.GetComponent<IInteractable>();
                    if (interactableItem != null)
                    {
                        // Activate Interactable
                        interactableItem.Interact(this.gameObject);
                    }

                    ISelectable selectable = selectableGameObject.GetComponent<ISelectable>();
                    if (selectable != null)
                    {
                        Debug.Log("Selectable found" + selectableGameObject);
                        Debug.Log("Current selected object" + currentSelectedObject);
                        // If no object is currently selected
                        if (currentSelectedObject == null)
                        {
                            Debug.Log("No object selected");
                            // Select
                            selectable.Select();
                            currentSelectedObject = selectableGameObject;
                            onSelectItem.Invoke(currentSelectedObject);
                        } 
                        // If the same object is selected
                        else if (currentSelectedObject.GetComponent<ISelectable>() == selectable) {
                            Debug.Log("Same object selected");
                            // Unselect
                            currentSelectedObject.GetComponent<ISelectable>().Unselect();
                            onUnselectItem.Invoke(currentSelectedObject);
                            currentSelectedObject = null;
                        }
                        // If a different object is selected
                        else {
                            Debug.Log("Different object selected");
                            // Unselect
                            currentSelectedObject.GetComponent<ISelectable>().Unselect();
                            onUnselectItem.Invoke(currentSelectedObject);
                            // Select
                            selectable.Select(currentSelectedObject);
                            currentSelectedObject = selectableGameObject;
                            onSelectItem.Invoke(currentSelectedObject);
                            
                            // This controls not leting a selected object when swapping slices
                            if (currentSelectedObject.GetComponent<SliceWheel>() != null)
                            {
                                // I'm sorry, we'll make it right. 
                                // But why not just put all the select logic here, for every specific type of selectable? maybe this is da way
                                currentSelectedObject = null;
                            }
                        }
                    }
                    
                }
            }
        }
    }

    public void Unselect() {
        if (instance.currentSelectedObject != null)
        {
            instance.currentSelectedObject.GetComponent<ISelectable>().Unselect();
            instance.onUnselectItem.Invoke(instance.currentSelectedObject);
            instance.currentSelectedObject = null;
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
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, 5000f, interactableMask);

        return hit;
    }
}
