using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slice : MonoBehaviour
{
    public SliceSO sliceSO;
    public int currentValue;
    public SliceType currentType;
    public SliceEffect currentEffect;

    [SerializeField]
    private MeshRenderer meshRenderer = null;
    

    [Header("Display Properties")]
    private string titleTextString = "";
    private string valueTextString = "";
    public TMP_Text titleText = null;
    public TMP_Text valueText = null;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // SO methods
    public void Initialize(SliceSO newSO)
    {
        sliceSO = newSO;
        ChangeValue(sliceSO.initialValue);
        ChangeEffect(sliceSO.effect);
        ChangeTitle(sliceSO.title);
        ChangeType(sliceSO.type);
    }

    public void UpdateDisplay()
    {
        meshRenderer.material = currentType.material;
        valueText.text = valueTextString;
        titleText.text = titleTextString;
    }

    public void UpdateSOValues()
    {
        ChangeType(sliceSO.type);
        ChangeValue(sliceSO.initialValue);
        ChangeEffect(sliceSO.effect);
        ChangeTitle(sliceSO.title);
    }

    // Slice methods
    public void ChangeType(SliceType newType)
    {
        currentType = newType;
    }

    public void ChangeValue(int value)
    {
        currentValue = value;
        valueTextString = currentValue.ToString();
        if (currentValue == 0)
        {
            valueTextString = "";
        }
    }

    public void ChangeValueText()
    {
    }

    public void ChangeEffect(SliceEffect effect)
    {
        currentEffect = effect;
    }

    public void ChangeTitle(string title)
    {
        titleTextString = title;
    }
}
