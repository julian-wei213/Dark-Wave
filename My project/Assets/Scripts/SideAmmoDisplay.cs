using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideAmmoDisplay : MonoBehaviour
{
    private Player player;
    private int Ammo;
    public Text SideAmmoText;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Ammo = player.SideAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        Ammo = player.SideAmmo;

        SideAmmoText.text = Ammo.ToString();
    }
}
