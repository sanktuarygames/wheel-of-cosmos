using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterView : MonoBehaviour
{
    private Character character;
    public GameObject slicePrefab;
    public GameObject arrowPrefab;

    [Header("Character Display")]
    public TMP_Text characterName;
    public Image characterImage;

    [Header("Character Stats")]
    public TMP_Text currentHealth;
    public TMP_Text currentArmor;
    public TMP_Text maxHealth;
    public TMP_Text maxArmor;

    [Header("Character Elements")]
    public Wheel displayWheel;
    private Wheel wheel;
    public Inventory inventory;

    [Header("Wheel Management")]
    public DropZoneController arrowPositions;
    public DropZoneController slicePositions;

    [Header("Item Management")]
    public Slice auxSlice;
    public GameObject sliceEditPanel;
    public GameObject inventoryPanel;
    // There will be an event listener for when the char is updated
    // There will be a listener for the ongrab
    // There will be a listener for the ondrop
    // There will be a listener for the ondrag
    public Interactor interactor;

    
    private void OnEnable() {
        LoadCharacter();
        interactor.OnGrabItem.AddListener(OnGrabItem);

        
    }
    public void LoadCharacter() {
        character = GameMaster.Instance.currentCharacter;
        if (character == null) return;
        // characterName.text = character.characterName;
        // characterImage.sprite = character.characterSO.icon;
        currentHealth.text = character.currentHealth.ToString();
        currentArmor.text = character.currentArmor.ToString();
        maxHealth.text = "/" + character.currentMaxHealth.ToString();
        maxArmor.text = "/" + character.currentMaxArmor.ToString();
        wheel = character.wheel;
        inventory = character.inventory;
        LoadWheel();
    }

    private void LoadWheel() {
        Debug.Log("Loading wheel");
        int i = 0;
        foreach(DropZone dropZone in slicePositions.dropZones) {
            Destroy(dropZone.transform.GetChild(0).gameObject);

            if (wheel.currentSlices[i] != null) {
                GameObject newSlice = Instantiate(slicePrefab, dropZone.transform);
                newSlice.GetComponent<Slice>().Initialize(wheel.currentSlices[i].sliceSO);
                newSlice.name = newSlice.GetComponent<Slice>().currentType.typeName + " - " + newSlice.GetComponent<Slice>().currentValue;
                newSlice.GetComponent<Slice>().UpdateDisplay();
            }
            i++;
        }
    
        i = 0;
        foreach(DropZone dropZone in arrowPositions.dropZones) {
            if (dropZone.transform.childCount > 0) {
                Destroy(dropZone.transform.GetChild(0).gameObject);
            }

            if (wheel.currentArrows[i] != null) {
                GameObject newArrow = Instantiate(arrowPrefab, dropZone.transform);
                newArrow.GetComponent<Arrow>().Initialize(wheel.currentArrows[i].arrowSO);
                Debug.Log("Arrow type: " + newArrow.GetComponent<Arrow>().currentType);
                Debug.Log(newArrow);
                newArrow.name = newArrow.GetComponent<Arrow>().currentType.typeName  + " Arrow";
                newArrow.GetComponent<Arrow>().UpdateDisplay();
            }
            i++;
        }
    }

    public void LoadInventory() {
    }
    
    private void OnGrabItem(GameObject item) {
        if (item.GetComponent<Slice>() != null) {
            Slice slice = item.GetComponent<Slice>();
            ShowSliceEdit(slice);
        } else if (item.GetComponent<Arrow>() != null) {
            Arrow arrow = item.GetComponent<Arrow>();
            Debug.Log("Arrow grabbed: " + arrow.currentType.typeName);
        }
    }
    public void ShowSliceEdit(Slice slice) {
        if (slice == null) return;
        sliceEditPanel.SetActive(true);
        inventoryPanel.SetActive(false);
    }

    public void ShowInventory() {
        inventoryPanel.SetActive(true);
        sliceEditPanel.SetActive(false);
    }

    public void Spin() {

    }

}