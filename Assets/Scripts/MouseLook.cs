using UnityEngine;

[RequireComponent(typeof(PlayerInputController))]
public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSensitivity = 0.1f;

    private PlayerInputController input;

    private float xRotation = 0f;

    private void Awake()
    {
        input = GetComponentInParent<PlayerInputController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {
        Vector2 look = input.LookInput * mouseSensitivity;

        // vertical rotation 
        xRotation -= look.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // horizontal rotation 
        playerBody.Rotate(Vector3.up * look.x);
    }
}