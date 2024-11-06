using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillsAmountUI : MonoBehaviour
{
    [SerializeField] private TMP_Text killsAmountText;
    public void UpdateKills(int kills)
    {
        killsAmountText.text = $"Killed enemies: {kills}";
    }
}
