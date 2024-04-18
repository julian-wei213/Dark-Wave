using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightingSwitch : MonoBehaviour
{
    public Light2D lights;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            lightSwitch();
        }
    }

    private void lightSwitch()
    {
        if (lights.intensity == 1)
        {
            lights.intensity = 0;
        }
        else
        {
            lights.intensity = 1;
        }
    }
}
