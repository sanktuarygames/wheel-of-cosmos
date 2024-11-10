using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterView : MonoBehaviour
{
    // public GameObject characterTemplate;
    public static CharacterView instance { get; private set; }

    // There will be an adapter to control the displayables, as there will be a template for every character
    private Character character;
    public GameObject slicePrefab;
    public GameObject arrowPrefab;

    [Header("Character Display")]
    public TMP_Text characterName;
    public Image characterImage;

    [Header("Character Stats")]
    // public TMP_Text currentHealth;
    // public TMP_Text maxHealth;
    // public TMP_Text currentArmor;
    // public TMP_Text maxArmor;
    public TMP_InputField currentHealth;
    public TMP_InputField maxHealth;
    public TMP_InputField currentArmor;
    public TMP_InputField maxArmor;

    [Header("Character Elements")]
    public WheelController wheelController;
    public WheelDisplay wheelDisplay;
    public InventoryDisplay inventoryDisplay;
    public ArsenalDisplay arsenalDisplay;

    [Header("Main Panel Management")]
    public GameObject slicesArsenalPanel;
    public GameObject skyrsPanel;
    public GameObject skillsPanel;
    public TMP_Text slicesArsenalPanelTitle;
    public TMP_Text skyrsPanelTitle;
    public TMP_Text skillsPanelTitle;

    [Header("Selected Item Actions Panel")]
    public GameObject sliceSelectedActionsPanel;
    public GameObject arrowSelectedActionsPanel;


    void Awake() {
        instance = this;
        if (instance != this) {
            Destroy(this);
        }
    }
    

    void OnEnable() {
        LoadCharacter();
        Selector.instance?.OnSelectItem.AddListener(ShowSelectedItemActionsPanel);
        Selector.instance?.OnUnselectItem.AddListener(HideSelectedItemActionsPanel);
    }

    void OnDisable() {
        Selector.instance?.OnSelectItem.RemoveListener(ShowSelectedItemActionsPanel);
        Selector.instance?.OnUnselectItem.RemoveListener(HideSelectedItemActionsPanel);
    }

    void Start() {
        // LoadCharacter();
        ShowArsenalSlicesPanel();
        HideSelectedItemActionsPanel();
    }

    public void LoadCharacter() {
        character = GameMaster.Instance?.currentCharacter;
        if (character == null) return;
        characterName.text = character.characterName;
        characterImage.sprite = character.characterSO.icon;
        currentHealth.text = character.currentHealth.ToString();
        currentArmor.text = character.currentArmor.ToString();
        maxHealth.text = character.currentMaxHealth.ToString();
        maxArmor.text = character.currentMaxArmor.ToString();
        LoadWheel();
        LoadInventory();
    }

    private void LoadWheel() {
        Debug.Log("LoadWheel");
        wheelDisplay.SetupDisplay(character.wheel);
    }

    public void AddSliceValue() {
        Debug.Log("AddSliceValue");
        if (Selector.instance.currentSelectedObject == null) return;
        Debug.Log("AddSliceValue");
        SliceDisplay sliceDisplay = Selector.instance.currentSelectedObject.GetComponent<SliceDisplay>();
        if (sliceDisplay == null) return;
        Debug.Log("AddSliceValue");
        character.wheel.AddSliceValue(sliceDisplay.currentSlice);
        sliceDisplay.SetupDisplay(character.wheel.currentSlices[character.wheel.FindBySlice(sliceDisplay.currentSlice)]);
    }

    public void RemoveSliceValue() {
        SliceDisplay sliceDisplay = Selector.instance.currentSelectedObject.GetComponent<SliceDisplay>();
        if (sliceDisplay == null) return;
        character.wheel.RemoveSliceValue(sliceDisplay.currentSlice);
        sliceDisplay.SetupDisplay(character.wheel.currentSlices[character.wheel.FindBySlice(sliceDisplay.currentSlice)]);
    }

    public void DisableSlice() {
        SliceDisplay sliceDisplay = Selector.instance.currentSelectedObject.GetComponent<SliceDisplay>();
        if (sliceDisplay == null) return;
        character.wheel.DisableSlice(sliceDisplay.currentSlice);
        sliceDisplay.SetupDisplay(character.wheel.currentSlices[character.wheel.FindBySlice(sliceDisplay.currentSlice)]);
        Selector.instance.Unselect();
    }

    public void LoadInventory() {
        inventoryDisplay.SetupDisplay(character.inventory);
    }

    public void AddArrowInventory() {
        ArrowSelectable arrowSelectable = Selector.instance.currentSelectedObject.GetComponent<ArrowSelectable>();
        ArrowArsenal arrowArsenal = Selector.instance.currentSelectedObject.GetComponent<ArrowArsenal>();

        if (arrowSelectable != null) {
            character.inventory.AddArrowBySO(arrowSelectable.GetComponent<ArrowDisplay>().currentArrow.arrowSO);
            inventoryDisplay.SetupDisplay(character.inventory);
        } else if (arrowArsenal != null) {
            Debug.Log("Added arrow to inventory" + arrowArsenal.GetComponent<ArrowDisplay>().currentArrow);
            character.inventory.AddArrowBySO(arrowArsenal.GetComponent<ArrowDisplay>().currentArrow.arrowSO);
            Debug.Log("Added arrow to inventory");
            Debug.Log(character.inventory.currentArrows.Count);
            inventoryDisplay.SetupDisplay(character.inventory);
        } else {
            Debug.Log("Shouldnt be here");
        }
    }

    public void RemoveArrowInventory() {
        ArrowSelectable arrowSelectable = Selector.instance.currentSelectedObject.GetComponent<ArrowSelectable>();
        ArrowArsenal arrowArsenal = Selector.instance.currentSelectedObject.GetComponent<ArrowArsenal>();

        if (arrowSelectable != null) {
            character.inventory.RemoveArrowBySO(arrowSelectable.GetComponent<ArrowDisplay>().currentArrow.arrowSO);
            inventoryDisplay.SetupDisplay(character.inventory);
        } else if (arrowArsenal != null) {
            character.inventory.RemoveArrowBySO(arrowArsenal.GetComponent<ArrowDisplay>().currentArrow.arrowSO);
            inventoryDisplay.SetupDisplay(character.inventory);
        } else {
            Debug.Log("Shouldnt be here");
        }
    }
    
    public void ShowSelectedItemActionsPanel(GameObject item) {
        if (item.GetComponent<SliceSelectable>() != null || item.GetComponent<SliceArsenal>() != null) {
            sliceSelectedActionsPanel.SetActive(true);
            arrowSelectedActionsPanel.SetActive(false);
        } else if (item.GetComponent<ArrowSelectable>() != null || item.GetComponent<ArrowArsenal>() != null) {
            sliceSelectedActionsPanel.SetActive(false);
            arrowSelectedActionsPanel.SetActive(true);
        }
    }
    public void HideSelectedItemActionsPanel(GameObject item = null) {
        sliceSelectedActionsPanel.SetActive(false);
        arrowSelectedActionsPanel.SetActive(false);
    }

    public void ShowArsenalSlicesPanel() {
        skyrsPanel.SetActive(false);
        skillsPanel.SetActive(false);
        slicesArsenalPanel.SetActive(true);
        slicesArsenalPanelTitle.color = new Color(1, 1, 1, 1);
        skyrsPanelTitle.color = new Color(0, 0, 0, 1);
        skillsPanelTitle.color = new Color(0, 0, 0, 1);
        Selector.instance.Unselect();
    }

    public void ShowSkyrsPanel() {
        skyrsPanel.SetActive(true);
        skillsPanel.SetActive(false);
        slicesArsenalPanel.SetActive(false);
        slicesArsenalPanelTitle.color = new Color(0, 0, 0, 1);
        skyrsPanelTitle.color = new Color(1, 1, 1, 1);
        skillsPanelTitle.color = new Color(0, 0, 0, 1);
        Selector.instance.Unselect();
    }

    public void ShowSkillsPanel() {
        skyrsPanel.SetActive(false);
        skillsPanel.SetActive(true);
        slicesArsenalPanel.SetActive(false);
        slicesArsenalPanelTitle.color = new Color(0, 0, 0, 1);
        skyrsPanelTitle.color = new Color(0, 0, 0, 1);
        skillsPanelTitle.color = new Color(1, 1, 1, 1);
        Selector.instance.Unselect();
    }

    public void Spin() {
        if (wheelController.isSpining) return;
        wheelController.Spin();
    }

    public void SwapSlicesWheel(Slice initialSlice, Slice finalSlice) {
        character.wheel.SwapSlices(initialSlice, finalSlice);
        wheelDisplay.SetupDisplay(character.wheel);
    }

    public void SwapSlicesArsenal(Slice initialSlice, Slice finalSlice) {
        character.arsenal.SwapSlices(initialSlice, finalSlice);
        arsenalDisplay.SetupDisplay(character.arsenal);
    }

    public void SwapArrows(Arrow initialArrow, Arrow finalArrow) {
        Debug.Log("SwapArrows" + initialArrow + " - " + finalArrow);
        character.wheel.SwapArrows(initialArrow, finalArrow);
        wheelDisplay.SetupDisplay(character.wheel);
    }

    public void AddSliceToWheel(Slice slice, Slice nextSlice = null) {
        if (nextSlice != null) {
            character.wheel.AddSlice(nextSlice, character.wheel.FindBySlice(slice));
        } else {
            character.wheel.AddSlice(slice);
        }
        character.arsenal.LockSlice(slice);
        wheelDisplay.SetupDisplay(character.wheel);
        // arsenalDisplay.SetupDisplay(character.arsenal);
    }

    public void AddArrowToWheel(Arrow arrow, Arrow nextArrow = null) {
        Debug.Log("AddArrowToWheel" + arrow.name + " - " + nextArrow.name);
        if (nextArrow != null) {
            character.wheel.AddArrow(nextArrow, character.wheel.FindByArrow(arrow));
        } else {
            character.wheel.AddArrow(arrow);
        }
        character.inventory.RemoveArrowBySO(nextArrow.arrowSO);
        wheelDisplay.SetupDisplay(character.wheel);
        inventoryDisplay.SetupDisplay(character.inventory);
    }

    public void ReturnSliceToArsenal(Slice slice) {
        character.wheel.RemoveSlice(slice);
        character.arsenal.AddSlice(slice);
        wheelDisplay.SetupDisplay(character.wheel);
        // arsenalDisplay.SetupDisplay(character.arsenal);
    }

    public void ReturnArrowToInventory(Arrow arrow) {
        character.wheel.DisableArrow(arrow);
        character.inventory.AddArrowBySO(arrow.arrowSO);
        wheelDisplay.SetupDisplay(character.wheel);
        inventoryDisplay.SetupDisplay(character.inventory);
    }
}
