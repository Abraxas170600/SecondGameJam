using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public void TimePause(float state)
    {
        Time.timeScale = state;
    }
}
