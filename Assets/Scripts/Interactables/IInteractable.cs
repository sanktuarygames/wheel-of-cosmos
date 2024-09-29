using UnityEngine;
using UnityEngine.Events;

interface IInteractable
{
    public void Interact(GameObject interactor = null);
}
