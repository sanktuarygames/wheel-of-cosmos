using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliceProperties : MonoBehaviour
{
    [Header("Dependencies")]

    public SliceType sliceType;
    private string sliceName;

    [Header("Properties")]
    Dictionary<SliceType, string> _sliceTypeHandler = new Dictionary<SliceType, string>(){
        {SliceType.Red, "Red"},
        {SliceType.Blue, "Blue"},
        {SliceType.Green, "Green"},
        {SliceType.Pink, "Pink"},
        {SliceType.Cursed, "Cursed"},
        {SliceType.Stellar, "Stellar"},
        {SliceType.Void, "Void"},
    };
    public int sliceValue;
    public int sliceValueMax = 3;
    private string sliceValueTextString = "";
    public string sliceEffectTextString = "";
    public TMP_Text sliceValueText = null;
    public TMP_Text sliceEffectText = null;
    private Material sliceMaterial;

    private void OnValidate() {
        ChangeType(sliceType);
        ChangeEffect(sliceEffectTextString);
        ChangeValueText();
    }

    void Start()
    {
        ChangeType(sliceType);
        ChangeEffect(sliceEffectTextString);
        ChangeValueText();
    }

    public void Change(SliceType type, string effect, int value)
    {
        ChangeType(type);
        ChangeEffect(effect);
        ChangeValue(value);
    }

    public void ChangeType(SliceType newType)
    {
        sliceType = newType;
        Debug.Log("Materials/SliceMaterial/" + _sliceTypeHandler[sliceType]);
        sliceMaterial = Resources.Load<Material>("SliceMaterials/" + _sliceTypeHandler[sliceType]);
        GetComponent<Renderer>().material = sliceMaterial;
        sliceName = _sliceTypeHandler[sliceType] + "Slice";
        transform.name = sliceName;
    }

    public void ChangeValue(int value)
    {
        sliceValue = value;
        ChangeValueText();
    }

    public void AddValue(int value)
    {
        sliceValue += value;
        ChangeValueText();
        
    }

    public void ChangeValueText()
    {
        sliceValueTextString = sliceValue.ToString();
        if (sliceValue == 0)
        {
            sliceValueTextString = "";
        }
        sliceValueText.text = sliceValueTextString;
    }

    public void ChangeEffect(string value)
    {
        sliceEffectTextString = value;
        sliceEffectText.text = sliceEffectTextString;
    }
}