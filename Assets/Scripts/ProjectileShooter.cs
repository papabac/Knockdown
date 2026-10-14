using UnityEngine;

[RequireComponent(typeof(PlayerInputController))]
public class ProjectileShooter : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform firePoint;

    [Header("Throw")]
    [SerializeField] private float throwForce = 20f;

    private PlayerInputController input;

    private void Awake()
    {
        input = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        if (input.ThrowPressed)
        {
            ThrowBall();
        }
    }

    private void ThrowBall()
    {
        GameObject ball = Instantiate(
            ballPrefab,
            firePoint.position,
            Quaternion.identity);

        Rigidbody rb = ball.GetComponent<Rigidbody>();

        Collider ballCollider = ball.GetComponent<Collider>();
        Collider playerCollider = GetComponent<CharacterController>();

        Physics.IgnoreCollision(ballCollider, playerCollider);

        rb.AddForce(
            firePoint.forward * throwForce,
            ForceMode.Impulse);
    }
}