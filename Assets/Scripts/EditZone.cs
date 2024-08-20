using UnityEngine;
using TMPro;

public class EditZone : DropZone
{
    [Header("Dependencies")]
    public SliceProperties currentSliceProperties;

    [Header("Related Objects")]
    public GameObject editUI;
    public GameObject slicePrefab;
    private int currentTypeIndex = 0;
    private bool isEditing = true;  // Change to false when done with the edit mode
    public TMP_InputField valueInput;


    void Start()
    {
        if (currentSlice != null)
        {
            currentSliceProperties = currentSlice.GetComponent<SliceProperties>();
            valueInput.text = "" + currentSliceProperties.sliceEffectText.text;
        }
        editUI.SetActive(isEditing);
    }

    public override void AddSlice(GameObject slice)
    {
        base.AddSlice(slice);
        Debug.Log("Adding slice");
        currentSliceProperties = currentSlice.GetComponent<SliceProperties>();
        valueInput.text = "" + currentSliceProperties.sliceEffectText.text;

        Debug.Log(currentSliceProperties);
    }

    public void StartEdit() {
        editUI.SetActive(true);

    }

    public void ChangeValue(string value) {
        if (currentSliceProperties == null) {
            Debug.Log("No slice properties found");
            return;
        }
        currentSliceProperties.ChangeEffect(value);
    }

    public void AddValue() {
        if (currentSliceProperties == null) {
            Debug.Log("No slice properties found");
            return;
        }
        currentSliceProperties.ChangeValue(1);
    }
    
    public void SubtractValue() {
        if (currentSliceProperties == null) {
            Debug.Log("No slice properties found");
            return;
        }

        currentSliceProperties.ChangeValue(-1);
    }

    public void CreateSlice() {
        if (currentSlice != null) {
            return;
        }
        currentSlice = Instantiate(slicePrefab, transform.position, transform.rotation, transform);
        currentSliceProperties = currentSlice.GetComponent<SliceProperties>();
        valueInput.text = null;
    }

    public void DeleteSlice() {
        if (currentSlice == null) {
            return;
        }
        currentSlice = null;
        Destroy(currentSliceProperties.gameObject);
        valueInput.text = null;
    }

    public void ChangeType() {
        currentTypeIndex++;
        SliceType newType = SliceType.Normal;
        switch (currentTypeIndex) {
            case 0:
                newType = SliceType.Attack;
                break;
            case 1:
                newType = SliceType.Armor;
                break;
            case 2:
                newType = SliceType.Normal;
                break;
            case 3:
                newType = SliceType.Heal;
                break;
            case 4:
                newType = SliceType.Special;
                break;
            case 5:
                newType = SliceType.Super;
                break;
            case 6:
                newType = SliceType.Cursed;
                break;
            case 7:
                currentTypeIndex = -1;
                newType = SliceType.Void;
                break;
        }
        currentSliceProperties.ChangeType(newType);
    }


}
