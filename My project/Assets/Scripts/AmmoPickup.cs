using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private Player player;
    public GameObject prefab;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (prefab.CompareTag("Main Ammo")) {
                Debug.Log("Main Ammo");
                if (player.MainAmmo < player.MaxMainAmmo) {
                    player.MainAmmo += 10;
                    Destroy(gameObject);
                }
            }
            else if (prefab.CompareTag("Side Ammo")) {
                Debug.Log("Side Ammo");
                if (player.SideAmmo < player.MaxSideAmmo) {
                    player.SideAmmo += 10;
                    Destroy(gameObject);
                }
            }
        }

        
    }
}
