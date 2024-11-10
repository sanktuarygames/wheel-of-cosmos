using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class WheelDisplay : MonoBehaviour
{
    [Header("Wheel")]
    public GameObject sliceDisplayPrefab;
    public Wheel wheel;

    public void SetupDisplay(Wheel wheel)
    {
        this.wheel = wheel;
        for(int i = 0; i < transform.childCount; i++) {
            Transform slicePosition = transform.GetChild(i);
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
    }
}