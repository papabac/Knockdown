using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingTarget : MonoBehaviour
{
    [SerializeField] private float moveDistance = 4f;
    [SerializeField] private float moveSpeed = 2f;

    private Vector3 startPosition;
    private Rigidbody rb;

    private bool isHit = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (isHit)
            return;

        float x = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        transform.position = startPosition + new Vector3(x, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isHit = true;

        rb.isKinematic = false;
        rb.useGravity = true;

        Vector3 direction = collision.transform.forward;
        rb.AddForce(direction * 6f, ForceMode.Impulse);
    }
}