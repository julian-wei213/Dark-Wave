using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainAmmoDisplay : MonoBehaviour
{
    private Player player;
    private int Ammo;
    public Text MainAmmoText;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Ammo = player.MainAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        Ammo = player.MainAmmo;

        MainAmmoText.text = Ammo.ToString();
    }
}
