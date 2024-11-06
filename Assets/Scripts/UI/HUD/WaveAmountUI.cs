using TMPro;
using UnityEngine;

public class WaveAmountUI : MonoBehaviour
{
    [SerializeField] private TMP_Text waveAmountText;
    public void UpdateWave(int wave)
    {
        waveAmountText.text = $"Wave: {wave}";
    }
}
