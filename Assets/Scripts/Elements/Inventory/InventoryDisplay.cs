using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class InventoryDisplay : MonoBehaviour
{

    [Header("Inventory")]
    public TMP_Text redArrowsText;
    public TMP_Text blueArrowsText;
    public TMP_Text greenArrowsText;
    public TMP_Text stellarArrowsText;
    public TMP_Text cursedArrowsText;
    public TMP_Text artificialArrowsText;
    private int redArrows;
    private int blueArrows;
    private int greenArrows;
    private int stellarArrows;
    private int cursedArrows;
    private int artificialArrows;
    public List<ArrowDisplay> arrowDisplay;

    void Start()
    {
        Initialize();
    }

    public void SetupDisplay(Inventory inventory)
    {
        Initialize();
        foreach (Arrow arrow in inventory.currentArrows)
        {
            AddArrow(arrow.currentType.baseType);
        }
        UpdateDisplay();
    }

    public void Initialize()
    {
        redArrows = 0;
        blueArrows = 0;
        greenArrows = 0;
        stellarArrows = 0;
        cursedArrows = 0;
        artificialArrows = 0;
    }

    public void UpdateDisplay() {
        redArrowsText.text = redArrows.ToString();
        blueArrowsText.text = blueArrows.ToString();
        greenArrowsText.text = greenArrows.ToString();
        stellarArrowsText.text = stellarArrows.ToString();
        cursedArrowsText.text = cursedArrows.ToString();
        artificialArrowsText.text = artificialArrows.ToString();
    }

    public void AddArrow(BaseType baseType)
    {
        switch (baseType)
        {
            case BaseType.Red:
                redArrows++;
                redArrowsText.text = redArrows.ToString();
                break;
            case BaseType.Blue:
                blueArrows++;
                blueArrowsText.text = blueArrows.ToString();
                break;
            case BaseType.Green:
                greenArrows++;
                greenArrowsText.text = greenArrows.ToString();
                break;
            case BaseType.Stellar:
                stellarArrows++;
                stellarArrowsText.text = stellarArrows.ToString();
                break;
            case BaseType.Cursed:
                cursedArrows++;
                cursedArrowsText.text = cursedArrows.ToString();
                break;
            case BaseType.Artificial:
                artificialArrows++;
                artificialArrowsText.text = artificialArrows.ToString();
                break;
            case BaseType.Void:
                break;
        }
    }

    public void RemoveArrow(BaseType baseType)
    {
        switch (baseType)
        {
            case BaseType.Red:
                redArrows--;
                redArrowsText.text = redArrows.ToString();
                break;
            case BaseType.Blue:
                blueArrows--;
                blueArrowsText.text = blueArrows.ToString();
                break;
            case BaseType.Green:
                greenArrows--;
                greenArrowsText.text = greenArrows.ToString();
                break;
            case BaseType.Stellar:
                stellarArrows--;
                stellarArrowsText.text = stellarArrows.ToString();
                break;
            case BaseType.Cursed:
                cursedArrows--;
                cursedArrowsText.text = cursedArrows.ToString();
                break;
            case BaseType.Artificial:
                artificialArrows--;
                artificialArrowsText.text = artificialArrows.ToString();
                break;
            case BaseType.Void:
                break;
        }
    }
}