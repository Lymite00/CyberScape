using UnityEngine;

public class PushObject : MonoBehaviour
{
    public Transform startTransform;  // Başlangıç Transform
    public Transform endTransform;    // Hedef Transform
    public float transitionSpeed = 2.0f; // Geçiş hızı

    private bool pushBool = false;
    private float transitionProgress = 0f;

    public float pushForce = 10.0f;
    private void Start()
    {
        pushBool = GameController.instance.isButtonPressed;
    }

    private void Update()
    {
        pushBool = GameController.instance.isButtonPressed;

        if (pushBool)
        {
            transitionProgress += transitionSpeed * Time.deltaTime;
            transitionProgress = Mathf.Clamp01(transitionProgress);

            transform.position = Vector3.Lerp(startTransform.position, endTransform.position, transitionProgress);

            if (transitionProgress >= 1.0f)
            {
                transform.position = endTransform.position;
            }
        }
        else
        {
            transitionProgress -= transitionSpeed * Time.deltaTime;
            transitionProgress = Mathf.Clamp01(transitionProgress);

            transform.position = Vector3.Lerp(startTransform.position, endTransform.position, transitionProgress);

            if (transitionProgress <= 0f)
            {
                transform.position = startTransform.position;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        if (otherRigidbody != null)
        {
            otherRigidbody.AddForce(collision.gameObject.transform.position* pushForce, ForceMode.Impulse);
        }
    }
}