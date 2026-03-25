using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CubeMove : MonoBehaviour
{
    public float speed = 5f;
    public float sprintMultiplier = 1.8f;
    public float jumpForce = 5f;
    public float rotationSpeed = 10f;

    public float fallOfMap = -20f; // ความสูงที่ถือว่าตกแมพ

    Rigidbody rb;
    bool isGrounded = false;
    bool jumpQueued = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    
    {
        // ===== ตกแมพ → กลับซีนแรก =====
        if (transform.position.y < fallOfMap)
        {
            SceneManager.LoadScene("SampleScene"); 
        }

        // ===== กระโดด =====
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            jumpQueued = true;
        }
    }

    void FixedUpdate()
    {
        Vector2 dir = Vector2.zero;

        if (Keyboard.current.aKey.isPressed) dir.x -= 1;
        if (Keyboard.current.dKey.isPressed) dir.x += 1;
        if (Keyboard.current.wKey.isPressed) dir.y += 1;
        if (Keyboard.current.sKey.isPressed) dir.y -= 1;

        float currentSpeed = speed;
        if (Keyboard.current.leftShiftKey.isPressed)
            currentSpeed *= sprintMultiplier;

        // ===== เดินตามกล้อง (แบบ Roblox) =====
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * dir.y + right * dir.x;
        move.Normalize();

        // MOVE
        rb.MovePosition(rb.position + move * currentSpeed * Time.fixedDeltaTime);

        // หมุนตัวละครตามทิศเดิน
        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime));
        }

        // JUMP
        if (jumpQueued && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        jumpQueued = false;
    }

    void OnCollisionEnter(Collision collision)
   {
        // เหยียบพื้น
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;

        // ===== โดน Enemy → ตาย =====
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    SceneManager.LoadScene("SampleScene");
        //}
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
    
    

}
