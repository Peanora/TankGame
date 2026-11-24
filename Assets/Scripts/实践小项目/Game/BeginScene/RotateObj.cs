using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public float rotateSpeed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up,rotateSpeed * Time.deltaTime);
    }
}
