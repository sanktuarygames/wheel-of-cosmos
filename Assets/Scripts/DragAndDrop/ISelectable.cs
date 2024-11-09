using UnityEngine;

interface ISelectable
{
    public bool isSelected { get; set; }
    public void Select(GameObject currentlySelectedObject = null);
    public void Unselect(GameObject currentlySelectedObject = null);
}

