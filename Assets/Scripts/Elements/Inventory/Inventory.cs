using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public InventorySO inventorySO;
    public GameObject inventoryPrefab;
    public List<Arrow> currentArrows;

    public void Initialize()
    {
        Initialize(inventorySO);
    }
    public void Initialize(InventorySO newInventorySO)
    {
        inventorySO = newInventorySO;
        currentArrows = new List<Arrow>();
        for (int i = 0; i < inventorySO.initialArrows.Length; i++) {
            currentArrows.Add(new GameObject("Arrow").AddComponent<Arrow>());
            currentArrows[i].Initialize(inventorySO.initialArrows[i]);
            currentArrows[i].transform.SetParent(transform);
        }
    }

    // TODO: not working
    public void AddArrow(Arrow arrow)
    {   
        Arrow newArrow = new GameObject("Arrow").AddComponent<Arrow>();
        newArrow.LoadArrow(arrow);
        newArrow.transform.SetParent(transform);
        currentArrows.Add(arrow);
        // not okay
    }

    public void AddArrowBySO(ArrowSO arrowSO)
    {
        Arrow newArrow = new GameObject("Arrow").AddComponent<Arrow>();
        newArrow.Initialize(arrowSO);
        newArrow.transform.SetParent(transform);
        currentArrows.Add(newArrow);
    }

    // TODO: not working
    public void RemoveArrow(Arrow arrow)
    {
        Arrow currentArrow = currentArrows.Find(a => a == arrow);
        currentArrows.Remove(currentArrow);
        // we should be destroying the arrows?
        // Destroy(currentArrow.gameObject);
    }

    public void RemoveArrowBySO(ArrowSO arrowSO)
    {
        Arrow currentArrow = currentArrows.Find(a => a.arrowSO == arrowSO);
        if (currentArrow != null) {
            currentArrows.Remove(currentArrow);
            // Destroy(currentArrow.gameObject);
        }
    }
}
