using UnityEngine;
using UnityEngine.Events;

public class ButtonCharSelect : MonoBehaviour, IInteractable
{
    private bool isSelected = false;
    public string characterCode;
    public Material selectedMaterial;
    public Material unselectedMaterial;

    [HideInInspector] public UnityEvent onInteract;
    private MeshRenderer meshRenderer;
    [SerializeField] private GameSetupView gameSetupView;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = unselectedMaterial;
    }

    public void SelectCharacter()
    {
        if (isSelected)
        {
            meshRenderer.material = unselectedMaterial;
            isSelected = false;
            gameSetupView.RemoveCharacter(characterCode);
        } else {
            meshRenderer.material = selectedMaterial;
            isSelected = true;
            gameSetupView.AddCharacter(characterCode);

        }
    }

    public virtual void Interact(GameObject interactor = null)
    {
        SelectCharacter();
    }
}
