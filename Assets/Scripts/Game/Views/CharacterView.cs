using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterView : MonoBehaviour
{
    public GameObject characterTemplate;

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
    public Wheel displayWheel;
    private Wheel wheel;
    public Inventory inventory;

    [Header("Wheel Management")]
    public DropZoneController arrowPositions;
    public DropZoneController slicePositions;

    [Header("Item Management")]
    public Slice editSlice;
    public GameObject sliceEditPanel;
    public GameObject inventoryPanel;

    private Coroutine sliceEditDelay;

    public float sliceEditTimeout = 0.25f;
    private float sliceEditTimeoutCounter = 0.25f;
    

    void Awake() {
        Interactor.instance.onGrabItem.AddListener(OnGrabItem);
        Interactor.instance.onDropItem.AddListener(OnDropItem);
    }

    void OnDestroy() {
        Interactor.instance.onGrabItem.RemoveListener(OnGrabItem);
        Interactor.instance.onDropItem.RemoveListener(OnDropItem);
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
    private void OnEnable() {
        LoadCharacter();
    }
    public void LoadCharacter() {
        character = GameMaster.Instance.currentCharacter;
        if (character == null) return;
        characterName.text = character.characterName;
        characterImage.sprite = character.characterSO.icon;
        currentHealth.text = character.currentHealth.ToString();
        currentArmor.text = character.currentArmor.ToString();
        maxHealth.text = character.currentMaxHealth.ToString();
        maxArmor.text = character.currentMaxArmor.ToString();
        wheel = character.wheel;
        inventory = character.inventory;
        LoadWheel();
    }

    private void LoadWheel() {
        Debug.Log("Loading wheel");
        int i = 0;
            foreach(DropZone dropZone in slicePositions.dropZones) {
                if (dropZone.transform.childCount > 0) {
                    Destroy(dropZone.transform.GetChild(0).gameObject);
                }

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
            // if (sliceEditDelay != null) StopCoroutine(sliceEditDelay);
            // sliceEditDelay = StartCoroutine(ToggleSliceEditDelay("ShowEditSlice"));

            Animator charAnimator = characterTemplate.GetComponent<Animator>();
            float currentTime = (charAnimator.GetCurrentAnimatorStateInfo(0).length - charAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime) * charAnimator.GetCurrentAnimatorStateInfo(0).speed;
            charAnimator.Play("ShowEditSlice", 0, currentTime < 0 ? 0 : currentTime);

            // characterTemplate.GetComponent<Animator>().SetTrigger("Show");
            // characterTemplate.GetComponent<Animator>().PlayInFixedTime("Show");
        } else if (item.GetComponent<Arrow>() != null) {
            // We could highlight the dropzones here
            Arrow arrow = item.GetComponent<Arrow>();
            Debug.Log("Arrow grabbed: " + arrow.currentType.typeName);
        }
    }

    private void OnDropItem(GameObject item) {
        if (item.GetComponent<Slice>() != null) {
            Slice slice = item.GetComponent<Slice>();
            if (sliceEditDelay != null) StopCoroutine(sliceEditDelay);
            sliceEditDelay = StartCoroutine(ToggleSliceEditDelay("HideEditSlice"));

            Animator charAnimator = characterTemplate.GetComponent<Animator>();
            float currentTime = (charAnimator.GetCurrentAnimatorStateInfo(0).length - charAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime) * charAnimator.GetCurrentAnimatorStateInfo(0).speed;
            charAnimator.Play("HideEditSlice", 0, currentTime < 0 ? 0 : currentTime);

            // Animator charAnimator = characterTemplate.GetComponent<Animator>();
            // charAnimator.Play("HideEditSlice",0, charAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime/2);

            // characterTemplate.GetComponent<Animator>().SetTrigger("Hide", layer);
        } else if (item.GetComponent<Arrow>() != null) {
            // We could hide the highlight of the dropzones here
            Arrow arrow = item.GetComponent<Arrow>();
            Debug.Log("Arrow dropped: " + arrow.currentType.typeName);
        }
    }
    public void ShowSliceEdit(Slice slice) {
        Debug.Log("Showing slice edit");
        // if (slice == null) return;
        StartCoroutine(ToggleSliceEditDelay("ShowEditSlice"));
        // sliceEditPanel.SetActive(true);
        // inventoryPanel.SetActive(false);
        
    }

    IEnumerator ToggleSliceEditDelay(string animation) {
        yield return new WaitForSeconds(0.25f);
        Animator charAnimator = characterTemplate.GetComponent<Animator>();
        charAnimator.Play(animation, 0, charAnimator.GetCurrentAnimatorStateInfo(0).length - (charAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime * charAnimator.GetCurrentAnimatorStateInfo(0).speed));
        sliceEditDelay = null;
    }

    public void ShowInventory() {
        inventoryPanel.SetActive(true);
        sliceEditPanel.SetActive(false);
    }

    public void Spin() {
        displayWheel.GetComponentInChildren<WheelController>().Spin();

    }

}