using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public float rotateSpeed = 5;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up,rotateSpeed*Time.deltaTime);
    }
}
