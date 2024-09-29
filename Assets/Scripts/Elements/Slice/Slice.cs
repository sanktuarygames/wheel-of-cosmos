using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slice : MonoBehaviour
{
    public SliceSO sliceSO;
    private int currentValue;
    private SliceType currentType;
    private Effect[] currentEffects;

    [SerializeField]
    private MeshRenderer meshRenderer = null;
    

    [Header("Display Properties")]
    private string titleTextString = "";
    private string valueTextString = "";
    public TMP_Text titleText = null;
    public TMP_Text valueText = null;

    void Start()
    {
        if (meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        UpdateSOValues();
    }

    // SO methods
    public void Initialize(SliceSO newSO)
    {
        sliceSO = newSO;
        UpdateSOValues();
    }

    public void UpdateSOValues()
    {
        ChangeType(sliceSO.type);
        ChangeValue(sliceSO.initialValue);
        ChangeEffects(sliceSO.effects);
        ChangeTitle(sliceSO.title);
    }

    // Slice methods
    public void ChangeType(SliceType newType)
    {
        currentType = newType;
        meshRenderer.material = currentType.material;
    }

    public void ChangeValue(int value)
    {
        currentValue = value;
        ChangeValueText();
    }

    public void ChangeValueText()
    {
        valueTextString = currentValue.ToString();
        if (currentValue == 0)
        {
            valueTextString = "";
        }
        valueText.text = valueTextString;
    }

    public void ChangeEffects(Effect[] effects)
    {
        currentEffects = effects;
    }

    public void ChangeTitle(string title)
    {
        titleTextString = title;
        titleText.text = titleTextString;
    }
}
