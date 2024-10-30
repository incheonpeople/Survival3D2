using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")] //(6)
    public float moveSpeed; //(7)
    public float jumpPower; // (35)
    private Vector2 curMovementInput; //(8) 인풋시스템이 작동하게 해주는 클래스
    public LayerMask groundLayerMask; // (37)

    [Header("Look")] // (20)
    public Transform CameraContainer; // (28)
    public float minXLook; // (21)
    public float maxXLook; // (22)
    private float camCurXRot; // (23)
    public float lookSensitivity; // (24)
    private Vector2 mouseDelta;  // (25)

    private Rigidbody _rigidbody; //(9)

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate() // (19) Update → FixedUpdate
    {
        Move(); // (17)
    }
    private void LateUpdate()
    {
        CameraLook(); // (33)
    }


    void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x; //(13)
        dir *= moveSpeed; //(14)
        dir.y = _rigidbody.velocity.y; //(15) // 셋팅된 값을

        _rigidbody.velocity = dir; // (16) velocity에 넣어준다.
    }
    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity; // (29)
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook); // (30)
        CameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0); // (31)

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0); // (32)
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) // (10) // (18) Started → Performed
        {
            curMovementInput = context.ReadValue<Vector2>(); // (11)
        }
        else if (context.phase == InputActionPhase.Canceled) // (12)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context) // (26)
    {
        mouseDelta = context.ReadValue<Vector2>(); // (27) // 값을 계속 받아오니깐 값만 불러오면됨
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded()) // (33) //(41) && IsGrounded()
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse); // (34) //(36) 5 → jumpPower 
        }
    }
    bool IsGrounded() // (38)
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down) // (39)
        };
        for (int i = 0; i < rays.Length; i++) // (40)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }



}

