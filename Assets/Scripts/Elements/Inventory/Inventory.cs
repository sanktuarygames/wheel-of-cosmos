using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventorySO inventorySO;
    public GameObject inventoryPrefab;
    public Arrow[] arrows;

    public void Initialize()
    {
        Initialize(inventorySO);
    }
    public void Initialize(InventorySO inventorySO)
    {
        this.inventorySO = inventorySO;
        // arrows = new Arrow[inventorySO.initialArrows.Length];
        // for (int i = 0; i < inventorySO.initialArrows.Length; i++)
        // {
        //     arrows[i] = Instantiate(inventoryPrefab, transform).GetComponent<Arrow>();
        //     arrows[i].Initialize(inventorySO.initialArrows[i]);
        // }
    }
}
