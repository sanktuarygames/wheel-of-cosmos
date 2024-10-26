using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
    public ArrowSO arrowSO;
    public ArrowType currentType;

    [SerializeField]
    private MeshRenderer meshRenderer = null;

    void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // SO methods
    public void Initialize(ArrowSO newSO) {
        arrowSO = newSO;
        ChangeType(arrowSO.type);
    }

    public void UpdateDisplay() {
        meshRenderer.material = currentType.material;
    }


    public void ChangeType(ArrowType newType) {
        currentType = newType;
    }

    // Arrow methods
    public Slice GetSelectedSlice() {
        return new Slice();
    }

}