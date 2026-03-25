using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float distance = 12f;
    public float height = 6f;

    public float sensitivity = 0.2f;
    public float smoothSpeed = 10f;

    // ซูม
    public float zoomSpeed = 2f;
    public float minDistance = 3f;
    public float maxDistance = 20f;

    float yaw = 0f;
    float pitch = 20f;
     
        
    void LateUpdate()
    {
        // หมุนกล้องเมื่อคลิกขวา
        if (Mouse.current.rightButton.isPressed)
        {
            yaw += Mouse.current.delta.x.ReadValue() * sensitivity;
            pitch -= Mouse.current.delta.y.ReadValue() * sensitivity;
            pitch = Mathf.Clamp(pitch, -10f, 80f);
        }

        // ===== ซูมเมาส์ =====
        float scroll = Mouse.current.scroll.ReadValue().y;
        distance -= scroll * zoomSpeed * Time.deltaTime;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // ตำแหน่งกล้องแบบ Roblox
        Vector3 direction = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 targetPosition = player.position + rotation * direction;

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(player.position + Vector3.up * 2f);
    }
}
