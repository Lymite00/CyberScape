using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseScreen : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Dönme hızı (derece/saat cinsinden)

    void Update()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.rotation = transform.rotation * Quaternion.Euler(0, rotationAmount,0 );
    }

}
