using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    

    private float timer = 1f;
    void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer < 0) {
            Destroy(gameObject);
        }
    }
}
