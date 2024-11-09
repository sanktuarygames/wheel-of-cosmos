using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneController : MonoBehaviour
{
    public string dropZoneTag;
    public List<DropZone> dropZones;
    public bool isFrozen = true;


    void Awake()
    {
        dropZones = new List<DropZone>();
        GameObject[] dropZoneObjects = GameObject.FindGameObjectsWithTag(dropZoneTag);
        for (int i = 0; i < transform.childCount; i++)
        {
            dropZones[i] = transform.GetChild(i).GetComponent<DropZone>();
        }
    }

    public DropZone GetClosestDropZone(Vector3 position)
    {
        DropZone closestPosition = null;
        float nearestDistance = Mathf.Infinity;
        foreach (DropZone dropZone in dropZones)
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
        DropZone closestPosition = GetClosestDropZone(position);
        if (closestPosition != null)
        {
            closestPosition.Highlight();
        }
    }

    public void UnhighlightAllDropZones()
    {
        foreach (DropZone dropZone in dropZones)
        {
            dropZone.Unhighlight();
        }
    }

    public void RemoveAllItems()
    {
        foreach (DropZone dropZone in dropZones)
        {
            dropZone.RemoveItem();
        }
    }

    public DropZone GetEmptyDropZone()
    {
        foreach (DropZone dropZone in dropZones)
        {
            if (dropZone.currentItem == null)
            {
                return dropZone;
            }
        }
        return null;
    }
}
