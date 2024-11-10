using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
    public ArrowSO arrowSO;
    public ArrowType currentType;

    public void Initialize() {
        Initialize(arrowSO);
    }

    public void Initialize(ArrowSO newSO) {
        arrowSO = newSO;
        ChangeType(arrowSO.type);
    }


    public void ChangeType(ArrowType newType) {
        currentType = newType;
    }
}