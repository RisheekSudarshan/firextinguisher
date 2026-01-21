using UnityEngine;

public class RotateSiren : MonoBehaviour
{
    public float rotationSpeed = 120f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
