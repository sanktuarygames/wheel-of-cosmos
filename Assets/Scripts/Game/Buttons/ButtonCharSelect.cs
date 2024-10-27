using UnityEngine;
using UnityEngine.Events;

public class ButtonCharSelect : MonoBehaviour, IInteractable
{
    public bool isSelected = true;
    public string characterCode;
    public Material selectedMaterial;
    public Material unselectedMaterial;

    [HideInInspector] public UnityEvent onInteract;
    private MeshRenderer meshRenderer;
    [SerializeField] private GameSetupView gameSetupView;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        SelectCharacter();
    }

    public void SelectCharacter()
    {
        if (!isSelected)
        {
            meshRenderer.material = unselectedMaterial;
            gameSetupView.RemoveCharacter(characterCode);
        } else {
            meshRenderer.material = selectedMaterial;
            gameSetupView.AddCharacter(characterCode);

        }
    }

    public virtual void Interact(GameObject interactor = null)
    {
        isSelected = !isSelected;
        SelectCharacter();
    }
}
