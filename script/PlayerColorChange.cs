using UnityEngine;

public class PlayerColorChange : MonoBehaviour
{
    Renderer playerRenderer;

    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {   //////// 1. แบบบอกชื่อสี
        if (collision.gameObject.CompareTag("colorBox"))
        {
            Color currentColor = playerRenderer.material.color;

            if (currentColor == Color.red)
            {
                playerRenderer.material.color = Color.green;
            }
            else if (currentColor == Color.green)
            {
                playerRenderer.material.color = Color.yellow;
            }
            else
            {
                playerRenderer.material.color = Color.red;
            }
        }

        //////////////////////////// 2. กำหนดสีเอง rgb ช่วงสี 0-1 เป็นทศนิยมได้
        //if (collision.gameObject.CompareTag("colorBox"))
        //{
        //    Color customColor = new Color(1f, 0.5f, 0f); // ส้ม   <<-- new Color(r,g,b) ต้องอยู่ช่วง 0–1
        //    playerRenderer.material.color = customColor;
        //}


        //////////////////////////// 3. กำหนดสีเอง rgba ช่วงสี 0-255 เลขจำนวนเต็ม a คือความโปร่ง-ทึบ 0คือโปร่งใส
        //if (collision.gameObject.CompareTag("colorBox"))
        //{
        //    Color customColor = new Color32(255, 128, 0, 255); // ส้ม <<--new Color(r,g,b,a) ต้องอยู่ช่วง 0–255
        //    playerRenderer.material.color = customColor;
        //}

    }
}