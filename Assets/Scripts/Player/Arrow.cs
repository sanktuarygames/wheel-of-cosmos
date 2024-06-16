using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
    [SerializeField] private int currentMaterial = 0;
    public Material[] materials;

    void Start() {
        if (materials == null || materials.Length == 0) {
            materials = Resources.LoadAll<Material>("ArrowMaterials");
        }
    }

    public void Change() {
        Debug.Log("Hello"); 
        currentMaterial++;
        if (currentMaterial > materials.Length - 1) {
            currentMaterial = 0;
        }
        GetComponent<MeshRenderer>().material = materials[currentMaterial];
    }

}