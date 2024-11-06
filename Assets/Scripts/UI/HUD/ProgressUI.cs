using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgressUI : MonoBehaviour
{
    [SerializeField] private TMP_Text waveScoreText;
    [SerializeField] private TMP_Text enemyScoreText;
    private void Start()
    {
        waveScoreText.text = $"Max wave: {PlayerPrefs.GetInt("MaxWave")}";
        enemyScoreText.text = $"High enemies killed: {PlayerPrefs.GetInt("HighEnemiesKilled")}";
    }
}
