using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WAVEdisplay : MonoBehaviour
{
    private WaveSpawner waveSpawner;
    private int WAVE;
    public Text WAVEText;
    void Start()
    {
        waveSpawner = GameObject.FindGameObjectWithTag("WAVE").GetComponent<WaveSpawner>();
        WAVE = waveSpawner.WAVECOUNT;
    }

    // Update is called once per frame
    void Update()
    {
        WAVE = waveSpawner.WAVECOUNT;

        WAVEText.text = WAVE.ToString();
    }
}
