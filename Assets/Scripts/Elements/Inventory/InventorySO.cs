using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Elements/Inventory", order = 1)]

public class InventorySO : ScriptableObject
{
    public string title;
    public GameObject inventoryPrefab;
    public ArrowSO[] initialArrows;
}
