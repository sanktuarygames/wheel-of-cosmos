using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEffect : MonoBehaviour, IPointerClickHandler
{
    public SliceEffect effect;

    [Header("Display Elements")]
    public TMP_Text displayText = null;
    public Image buttonCover = null;
    
    void Start()
    {
        if (displayText == null)
        {
            displayText = GetComponentInChildren<TMP_Text>();
        }
        displayText.material = effect.type.material;

    }

    public void Initialize(SliceEffect newEffect)
    {
        effect = newEffect;
        buttonCover.material = effect.type.material;
        // NOTE: Maybe its needed in the future
        // displayText.material = effect.type.material;

        displayText.text = effect.display;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + effect.display);
    }
}
