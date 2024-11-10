using UnityEngine;
using TMPro;

[RequireComponent(typeof(MeshRenderer))]
public class SliceDisplay : MonoBehaviour
{
    [Header("Slice")]
    private MeshRenderer meshRenderer;
    public Slice currentSlice;

    [Header("Display Properties")]
    public TMP_Text titleText = null;
    public TMP_Text valueText = null;

    public void SetupDisplay(Slice slice)
    {
        currentSlice = slice;
        GetComponent<MeshRenderer>().material = slice.currentType.material;
        if (slice.currentValue == 0)
        {
           valueText.text = "";
        } else {
            valueText.text = slice.currentValue.ToString();
        }
        titleText.text = slice.currentTitle;
        name = slice.currentType.name + " [" + slice.currentValue + "]";
    }
}