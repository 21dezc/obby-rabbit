using UnityEngine;
using TMPro;

public class playerPosition : MonoBehaviour
{
    public string playerTag = "Player";

    private Transform player;
    private TMP_Text posText;

    void Start()
    {
        posText = GetComponent<TMP_Text>();

        GameObject p = GameObject.FindGameObjectWithTag(playerTag);
        if (p != null)
            player = p.transform;
        else
            posText.text = "Player not found";
    }

    void Update()
    {
        if (player == null) return;

        Vector3 p = player.position;

        posText.text =
            "X: " + p.x.ToString("F2") + "\n" +
            "Y: " + p.y.ToString("F2") + "\n" +
            "Z: " + p.z.ToString("F2");
    }
}