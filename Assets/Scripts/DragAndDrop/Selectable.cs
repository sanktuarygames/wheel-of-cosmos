using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Selectable : MonoBehaviour, ISelectable
{
    public bool isSelected { get; set; } = false;

    public virtual void Select(GameObject currentlySelectedObject = null) {
        isSelected = true;
    }

    public virtual void Unselect(GameObject currentlySelectedObject = null)
    {
        isSelected = false;
    }
}
