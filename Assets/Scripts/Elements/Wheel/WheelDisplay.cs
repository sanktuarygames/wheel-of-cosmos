using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class WheelDisplay : MonoBehaviour
{
    [Header("Wheel")]
    public GameObject sliceDisplayPrefab;
    public GameObject arrowDisplayPrefab;
    public Transform wheelParent;
    public Transform arrowParent;
    [HideInInspector] public Wheel wheel;
    public ArrowSO voidArrowSO;

    public void SetupDisplay(Wheel wheel)
    {
        this.wheel = wheel;
        for(int i = 0; i < wheelParent.childCount; i++) {
            Transform slicePosition = wheelParent.GetChild(i);
            if (slicePosition.transform.childCount > 0) {
                Destroy(slicePosition.transform.GetChild(0).gameObject);
            }

            if (wheel.currentSlices[i] != null) {
                GameObject sliceDisplay = Instantiate(sliceDisplayPrefab, slicePosition);
                sliceDisplay.transform.SetParent(slicePosition);
                sliceDisplay.GetComponent<SliceDisplay>().SetupDisplay(wheel.currentSlices[i]);
                sliceDisplay.name = wheel.currentSlices[i].currentType.typeName + " - " + wheel.currentSlices[i].currentValue;
            }
        }

        for (int i = 0; i < arrowParent.childCount; i++) {
            Transform arrowPosition = arrowParent.GetChild(i);
            if (arrowPosition.transform.childCount > 0) {
                Destroy(arrowPosition.transform.GetChild(0).gameObject);
            }

            if (wheel.currentArrows[i] != null) {
                GameObject arrowDisplay = Instantiate(arrowDisplayPrefab, arrowPosition);
                arrowDisplay.transform.SetParent(arrowPosition);
                arrowDisplay.GetComponent<ArrowDisplay>().SetupDisplay(wheel.currentArrows[i]);
                arrowDisplay.name = wheel.currentArrows[i].currentType.typeName;
            }
        }
    }
}