using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    
    public GameObject clockPart;
    
    public Material normalMaterial;
    public Material lowMaterial;

    public float rotationSpeed = 6.0f; // Dönme hızı derece/saniye
    private float totalRotation = 0.0f;

    void Update()
    {
        timerText.text = GameManager.instance.timer.ToString("F1");
        
        if (GameManager.instance.gameStarted)
        {
            // Toplam dönüş miktarını hesapla
            totalRotation += rotationSpeed * Time.deltaTime;

            // Nesneyi döndür
            clockPart.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            // Toplam dönüş miktarını kontrol et ve 360 derece tamamlandığında durdur
            if (totalRotation >= 360.0f)
            {
                enabled = false; // Dönme işlemi sona ersin
            }

            if (totalRotation<=240f)
            {
                clockPart.GetComponent<MeshRenderer>().material = normalMaterial;
            }
            else if (totalRotation>=240f)
            {
                clockPart.GetComponent<MeshRenderer>().material = lowMaterial;
            }
        }
    }
}
