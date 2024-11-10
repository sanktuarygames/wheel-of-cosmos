using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterView : MonoBehaviour
{
    // public GameObject characterTemplate;

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

    private Coroutine sliceEditDelay;

    public float sliceEditTimeout = 0.25f;
    private float sliceEditTimeoutCounter = 0.25f;
    

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

    void Update() {
        if (sliceEditTimeoutCounter > 0) {
            sliceEditTimeoutCounter -= Time.deltaTime;
        } else {
            sliceEditTimeoutCounter = sliceEditTimeout;
            if (sliceEditDelay != null) {
                StopCoroutine(sliceEditDelay);
                sliceEditDelay = null;
            }
        }
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
            character.inventory.AddArrow(arrowSelectable.GetComponent<ArrowDisplay>().currentArrow.arrowSO);
            inventoryDisplay.SetupDisplay(character.inventory);
        } else if (arrowArsenal != null) {
            Debug.Log("Added arrow to inventory" + arrowArsenal.GetComponent<ArrowDisplay>().currentArrow);
            character.inventory.AddArrow(arrowArsenal.GetComponent<ArrowDisplay>().currentArrow.arrowSO);
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

}