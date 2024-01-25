using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] private float minSpeed = 1.0f;
    [SerializeField] private float pushForce = 5.0f;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private Transform particleTransform;
    [SerializeField] private GameObject portalParticle;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private AnimationClip destroyAnim;
    [SerializeField] private GameObject gameFinishedParticle;

    public AudioSource aSource;
    public AudioClip hammerSound;
    public AudioClip portalSound;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float speed = rb.velocity.magnitude;
        if (speed < minSpeed)
        {
            // Hız eşik değerinin altındaysa rastgele bir yönde itme uygula
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            rb.AddForce(randomDirection * pushForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishPoint"))
        {
            Debug.Log("Oyun tamamlandı.");
        }
        if (other.gameObject.CompareTag("DeadPoint"))
        {
            // Ölüm noktasına çarpıldığında sahneyi yeniden yükle
            int activeSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            UnityEngine.SceneManagement.SceneManager.LoadScene(activeSceneIndex);
        }
        if (other.gameObject.CompareTag("FinishPoint"))
        {
            playerAnim.SetTrigger("isFinished");
            Particle();
            CanvasController.instance.FinishGame();
        }
        if (other.gameObject.CompareTag("P1"))
        {
            CanvasController.instance.IncreaseSlider();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("P2"))
        {
            CanvasController.instance.IncreaseSlider();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("P3"))
        {
            CanvasController.instance.IncreaseSlider();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("PortalEntry"))
        {
            aSource.PlayOneShot(portalSound);
        }
        if (other.gameObject.CompareTag("PortalExit"))
        {
            aSource.PlayOneShot(portalSound);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platforms"))
        {
            Instantiate(portalParticle, particleTransform.position, Quaternion.identity);
        }
        if (other.gameObject.CompareTag("Hammer"))
        {
            aSource.PlayOneShot(hammerSound);
        }
    }

    public void Particle()
    {
        Instantiate(gameFinishedParticle, transform.position, Quaternion.identity);
    }
}
