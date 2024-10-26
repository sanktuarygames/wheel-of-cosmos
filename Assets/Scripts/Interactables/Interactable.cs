using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

// Base class for all interactable objects. This class will be inherited for expanded functionality.
// Current classes inherited from this class:
// - Descriptable.cs
// - ExplosionCube.cs
// - Grabable.cs

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private UnityEvent onInteract;
    public int id;


    virtual protected void Start()
    {
        id = Random.Range(0, 100000000);
        // Debug.Log("Interactable Start: " + id);
    }

    virtual public void Interact(GameObject interactor)
    {
        // Debug.Log("Interactable Interact(): " + gameObject.name + " by " + interactor.name);
        onInteract.Invoke();
    }

}