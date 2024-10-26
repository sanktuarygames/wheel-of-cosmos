using UnityEngine;
using UnityEngine.Events;

public class ButtonNavigation : MonoBehaviour, IInteractable
{
    [SerializeField]
    public View view;
    public void Navigate()
    {
        NavigationMaster.Instance.ShowView(view);
    }

    public virtual void Interact(GameObject interactor = null)
    {
        Navigate();
    }
}
