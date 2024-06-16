using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class Wheel : MonoBehaviour
{

    [Header("Wheel")]
    public int minSpins = 1;
    public int maxSpins = 6;
    private int spins = 0;
    public int spinSpeed = 13;
    public float wheelSpeed = 0.1f;
    public Vector3 direction = new Vector3(0, 1, 0);
    public float rotationAngle = 60;
    bool rotating = false;
    public Rigidbody rb;
    IEnumerator spinRoutine;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Spin()
    {
        spins = Random.Range(minSpins, maxSpins);
        spinRoutine = RotateObject();
        StartCoroutine(spinRoutine);
    }

    public void ResetSpin()
    {
        rotating = false;
    }

    IEnumerator RotateObject()
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;

        float counter = 0;
        while (counter < spins * spinSpeed)
        {
            counter++;
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y + rotationAngle,
                transform.eulerAngles.z
            );
            Debug.Log("Rotating");
            Debug.Log(transform.eulerAngles);

            yield return new WaitForSeconds(wheelSpeed);
        }
        rotating = false;
    }

    void Update()
    {

        // if (isDragging) {
        // 	theSpeed = new Vector3(-Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0F);
        // 	avgSpeed = Vector3.Lerp(avgSpeed, theSpeed, Time.deltaTime * 5);
        // } else {
        // 	if (isDragging) {
        // 		theSpeed = avgSpeed;
        // 		isDragging = false;
        // 	}
        // 	float i = Time.deltaTime * lerpSpeed;
        // 	theSpeed = Vector3.Lerp(theSpeed, Vector3.zero, i);
        // }

        // transform.Rotate(Vector3.up * theSpeed.x * rotationSpeed, Space.World);
    }
}