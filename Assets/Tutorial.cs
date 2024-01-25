using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;
    public GameObject image1;
    public GameObject image2;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        image1.SetActive(true);
        image2.SetActive(false);
        StartCoroutine(Tut());
    }

    public IEnumerator Tut()
    {
        yield return new WaitForSeconds(5f);
        image1.SetActive(false);
        image2.SetActive(true);
        yield return new WaitForSeconds(3f);
        image2.SetActive(false);
    }
}
