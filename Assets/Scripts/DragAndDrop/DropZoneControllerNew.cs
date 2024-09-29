using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneControllerNew : MonoBehaviour
{
    List<DropZoneNew> dropZones;
    // Start is called before the first frame update
    void Start()
    {
        dropZones = new List<DropZoneNew>();
        for (int i = 0; i < transform.childCount; i++)
        {
            dropZones.Add(transform.GetChild(i).GetComponent<DropZoneNew>());
        }
    }

    public DropZoneNew GetClosestDropZone(Vector3 position)
    {
        DropZoneNew closestPosition = null;
        float nearestDistance = Mathf.Infinity;
        foreach (DropZoneNew dropZone in dropZones)
        {
            float currentDistance = Vector3.Distance(position, dropZone.transform.position);
            if (currentDistance < nearestDistance)
            {
                closestPosition = dropZone;
                nearestDistance = currentDistance;
            }
        }
        return closestPosition;
    }

    public void HighlightClosestDropZone(Vector3 position)
    {
        DropZoneNew closestPosition = GetClosestDropZone(position);
        if (closestPosition != null)
        {
            closestPosition.Highlight();
        }
    }

    public void UnhighlightAllDropZones()
    {
        foreach (DropZoneNew dropZone in dropZones)
        {
            dropZone.Unhighlight();
        }
    }

    public void RemoveAllItems()
    {
        foreach (DropZoneNew dropZone in dropZones)
        {
            dropZone.RemoveItem();
        }
    }

    public DropZoneNew GetEmptyDropZone()
    {
        foreach (DropZoneNew dropZone in dropZones)
        {
            if (dropZone.currentItem == null)
            {
                return dropZone;
            }
        }
        return null;
    }
}
