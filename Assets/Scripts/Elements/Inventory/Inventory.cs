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

    public void AddArrow(ArrowSO arrowSO)
    {
        Arrow newArrow = new GameObject("Arrow").AddComponent<Arrow>();
        newArrow.Initialize(arrowSO);
        newArrow.transform.SetParent(transform);
        currentArrows.Add(newArrow);
    }

    public void RemoveArrow(Arrow arrow)
    {
        currentArrows.Remove(arrow);
        Destroy(arrow.gameObject);
    }

    public void RemoveArrowBySO(ArrowSO arrowSO)
    {
        Arrow arrow = currentArrows.Find(a => a.arrowSO == arrowSO);
        if (arrow != null) {
            currentArrows.Remove(arrow);
            Destroy(arrow.gameObject);
        }
    }
}
