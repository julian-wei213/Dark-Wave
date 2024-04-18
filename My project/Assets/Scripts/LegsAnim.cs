using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsAnim : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (h != 0)
        {
            anim.SetInteger("Direction", 1);
        }
        else
        {
            anim.SetInteger("Direction", 0);
        }
    }
}
