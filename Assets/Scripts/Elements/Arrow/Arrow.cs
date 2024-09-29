using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
    public ArrowSO arrowSO;
    private ArrowType currentType;

    [SerializeField]
    private MeshRenderer meshRenderer = null;

    void Start() {
        if (meshRenderer == null) {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        UpdateSOValues();
    }

    // SO methods
    public void Initialize(ArrowSO newSO) {
        arrowSO = newSO;
        UpdateSOValues();
    }

    public void UpdateSOValues() {
        ChangeType(arrowSO.type);
    }

    public void ChangeType(ArrowType newType) {
        currentType = newType;
        meshRenderer.material = currentType.material;
    }

    // Arrow methods
    public Slice GetSelectedSlice() {
        return new Slice();
    }

}