using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public int interval;
    private int timer;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 0)
        {
            sound.Play();
            timer = interval;
        }
        else
        {
            timer--;
        }
    }
}
