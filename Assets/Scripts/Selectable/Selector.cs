using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInputController))]
public class Selector : MonoBehaviour
{
    public static Selector instance { get; private set; }

    [Header("Grab Properties")]
    public LayerMask interactableMask;
    public GameObject currentSelectedObject;

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

    public void HandleSelect(GameObject gameObject) {
        if (gameObject == null) return;

        if (currentSelectedObject == null)
        {
            gameObject.GetComponent<ISelectable>().Select();
            currentSelectedObject = gameObject;
            onSelectItem.Invoke(currentSelectedObject);
        } else if (currentSelectedObject == gameObject)
        {
            currentSelectedObject.GetComponent<ISelectable>().Unselect();
            onUnselectItem.Invoke(currentSelectedObject);
            currentSelectedObject = null;
        } else {
            if (currentSelectedObject.GetComponent<SliceSelectable>() != null){
                if (gameObject.GetComponent<SliceArsenal>() != null || gameObject.GetComponent<SliceSelectable>() != null)
                {
                    currentSelectedObject.GetComponent<SliceSelectable>().Unselect();
                    gameObject.GetComponent<SliceSelectable>().HandleInteraction(currentSelectedObject);
                    onUnselectItem.Invoke(currentSelectedObject);
                    currentSelectedObject = null;
                } else {
                    SelectNext(gameObject);
                }
            } else if (currentSelectedObject.GetComponent<SliceArsenal>() != null){
                if (gameObject.GetComponent<SliceArsenal>() != null || gameObject.GetComponent<SliceSelectable>() != null)
                {
                    currentSelectedObject.GetComponent<SliceArsenal>().Unselect();
                    gameObject.GetComponent<SliceArsenal>().HandleInteraction(currentSelectedObject);
                    onUnselectItem.Invoke(currentSelectedObject);
                    currentSelectedObject = null;
                } else {
                    SelectNext(gameObject);
                }
            } else if (currentSelectedObject.GetComponent<ArrowSelectable>() != null){
                if (gameObject.GetComponent<ArrowArsenal>() != null || gameObject.GetComponent<ArrowSelectable>() != null)
                {
                    currentSelectedObject.GetComponent<ArrowSelectable>().HandleInteraction(gameObject);
                    currentSelectedObject = null;
                } else {
                    SelectNext(gameObject);
                }
            } else if (currentSelectedObject.GetComponent<ArrowArsenal>() != null) {
                if (gameObject.GetComponent<ArrowSelectable>() != null)
                {
                    currentSelectedObject.GetComponent<ArrowArsenal>().HandleInteraction(gameObject);
                    currentSelectedObject = null;
                } 
                else {
                    SelectNext(gameObject);
                }
            }
        }
    }

    public void SelectNext(GameObject gameObject) {
        if (currentSelectedObject != null)
        {
            currentSelectedObject.GetComponent<ISelectable>().Unselect();
            onUnselectItem.Invoke(currentSelectedObject);
            gameObject.GetComponent<ISelectable>().Select();
            onSelectItem.Invoke(gameObject);
            currentSelectedObject = gameObject;
        }
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
                        return;
                    }

                    ISelectable selectable = selectableGameObject.GetComponent<ISelectable>();
                    if (selectable != null)
                    {
                        HandleSelect(selectableGameObject);
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
