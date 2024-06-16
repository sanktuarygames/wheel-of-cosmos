using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using Unity.Mathematics;


public enum SliceType
{
    Attack,
    Armor,
    Heal,
    Cursed,
    Special,
    Ability,
    Combined,
    Gray,
}
public class SliceProperties : MonoBehaviour
{
    [Header("Dependencies")]

    public SliceType sliceType;
    private string sliceName;

    [Header("Properties")]
    Dictionary<SliceType, string> _sliceTypeHandler = new Dictionary<SliceType, string>(){
        {SliceType.Attack, "Attack"},
        {SliceType.Armor, "Armor"},
        {SliceType.Heal, "Heal"},
        {SliceType.Cursed, "Cursed"},
        {SliceType.Special, "Special"},
        {SliceType.Ability, "Ability"},
        {SliceType.Combined, "Combined"},
        {SliceType.Gray, "Gray"},
    };
    public int sliceValue;
    private string sliceValueTextString;
    public string sliceEffectTextString  = null;
    public TMP_Text sliceValueText = null;
    public TMP_Text sliceEffectText = null;
    private Material sliceMaterial;

    void Start()
    {
        // Use the material to set the color of the slice based on the slice type
        ChangeType(sliceType);
        ChangeEffect(sliceEffectTextString);
        ChangeValueText();
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
        sliceValue += value;
        ChangeValueText();
    }

    public void ChangeValueText() {
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