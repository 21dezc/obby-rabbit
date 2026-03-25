using UnityEngine;
using TMPro;

public class showHP : MonoBehaviour
{
    public string playerTag = "Player";

    private playerStat playerStat;
    private TMP_Text hpText;

    void Start()
    {
        hpText = GetComponent<TMP_Text>();

        GameObject p = GameObject.FindGameObjectWithTag(playerTag);
        if (p != null)
        {
            playerStat = p.GetComponent<playerStat>();
        }
        else
        {
            hpText.text = "Player not found";
        }
    }

    void Update()
    {
        if (playerStat == null) return;

        hpText.text = "HP : " + playerStat.hp.ToString();
    }
}