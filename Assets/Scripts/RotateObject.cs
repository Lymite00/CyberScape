using System;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Transform startTransform;  // Başlangıç Transform
    public Transform endTransform;    // Hedef Transform
    public float rotationSpeed; // Döndürme hızı

    private bool rotateBool = false;
    private float rotationProgress = 0f;
    
    public float pushForce = 10.0f;

    private void Start()
    {
        rotateBool = GameController.instance.isButtonPressed;
    }

    private void Update()
    {
        rotateBool = GameController.instance.isButtonPressed;
        if (rotateBool)
        {
            rotationProgress += rotationSpeed * Time.deltaTime;
            rotationProgress = Mathf.Clamp(rotationProgress, 0f, 1f);

            transform.rotation = Quaternion.Slerp(startTransform.rotation, endTransform.rotation, rotationProgress);

            if (rotationProgress >= 1.0f)
            {
                transform.rotation = endTransform.rotation;
            }
        }
        else
        {
            rotationProgress -= rotationSpeed * Time.deltaTime;
            rotationProgress = Mathf.Clamp(rotationProgress, 0f, 1f);
            
            transform.rotation = Quaternion.Slerp(startTransform.rotation, endTransform.rotation, rotationProgress);

            if (rotationProgress <= 0f)
            {
                transform.rotation = startTransform.rotation;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (collision.gameObject.CompareTag("Hammer"))
        {
            if (otherRigidbody != null)
            {
                Vector3 pushDirection = collision.contacts[0].normal;
                otherRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
        if (otherRigidbody != null)
        {
            otherRigidbody.AddForce(other.gameObject.transform.position* pushForce, ForceMode.Impulse);
        }
        
    }
}
