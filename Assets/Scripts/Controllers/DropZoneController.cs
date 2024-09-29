using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneController : MonoBehaviour
{
    List<DropZone> dropZones;
    // Start is called before the first frame update
    void Start()
    {
        dropZones = new List<DropZone>();
        for (int i = 0; i < transform.childCount; i++)
        {
            dropZones.Add(transform.GetChild(i).GetComponent<DropZone>());
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

    public void RemoveAllSlices()
    {
        foreach (DropZone dropZone in dropZones)
        {
            dropZone.RemoveSlice();
        }
    }

    public DropZone GetEmptyDropZone()
    {
        foreach (DropZone dropZone in dropZones)
        {
            if (dropZone.currentSlice == null)
            {
                return dropZone;
            }
        }
        return null;
    }
}
