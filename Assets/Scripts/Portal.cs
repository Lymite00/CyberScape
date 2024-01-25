using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform portalExit;
    
    [SerializeField] private float transitionTime;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private Vector3 playerVel;
    public GameObject player;
    public GameObject particle;
    
    
    void Start()
    {
        player=GameObject.FindWithTag("Player");
        playerRb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PortalEntry"))
        {
            portalExit = GameObject.FindWithTag("PortalExit").GetComponent<Transform>();
            StartCoroutine(Transition());
            Instantiate(particle, other.transform.position, Quaternion.identity);
        }
    }

    private IEnumerator Transition()
    {
        player.transform.GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(transitionTime);
        player.gameObject.transform.position = portalExit.transform.position;
        Instantiate(particle, portalExit.position, Quaternion.identity);
        playerRb.velocity = playerVel;
        player.transform.GetChild(0).gameObject.SetActive(true);
        player.transform.GetChild(1).gameObject.SetActive(true);
    }
}
