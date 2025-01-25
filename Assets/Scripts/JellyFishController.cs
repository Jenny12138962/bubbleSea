using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class JellyFishController : MonoBehaviour
{
    public float sprintSpeed = 5.0f;
    public float rotateSpeed = 1.0f;
    public float sprintDuration = 2.0f;
    public float pauseDuration = 2.0f;
    public float rotationDuration = 1.0f;
    private Transform trans;
    private bool isSprinting = false;
    private bool isRotating = false;
    private Quaternion endRotation;

    void Awake()
    {
        trans = GetComponent<Transform>();
    }

    void Start()
    {
        trans.rotation = Random.rotation;
        StartCoroutine(SprintRoutine());
    }

    void Update()
    {
        if (isSprinting)
        {
            trans.Translate(Vector3.up * sprintSpeed * Time.deltaTime);
        }
        if (isRotating)
        {
            trans.rotation = Quaternion.RotateTowards (
                trans.rotation,
                endRotation,
                rotateSpeed * Time.deltaTime
            );
        }
    }

    IEnumerator SprintRoutine()
    {
        while (true)
        {
            endRotation = Random.rotation;
            isSprinting = true;
            yield return new WaitForSeconds(sprintDuration);
            isSprinting = false;
            isRotating = true;
            yield return new WaitForSeconds(rotationDuration);
            isRotating = false;
            yield return new WaitForSeconds(pauseDuration);
        }
    }
}