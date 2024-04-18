using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyShop : MonoBehaviour
{
    private Player player;
    private Inventory inventory;
    public GameObject prefab;
    private price p;
    private GameObject headlight;
    private bullet b;
    public GameObject hlight;
    public int AmmoCount;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        inventory = player.GetComponent<Inventory>();
        p = prefab.GetComponent<price>();
        headlight = GameObject.FindGameObjectWithTag("headlights");
    }

    public void BuyWeapon() {
        if (player.Money < p.value) {
            Debug.Log("NO MONEY");
            return;
        }
        
        if (prefab.CompareTag("Main Weapon")) {
            for (int i = 0; i < inventory.Main.Length; i++) {
                if (inventory.MainIsFull[i] == false) {
                    inventory.MainIsFull[i] = true;
                    player.Money -= p.value;
                    Instantiate(prefab, inventory.Main[i].transform, false);
                    break;
                }
            }
        }
        else if (prefab.CompareTag("Side Arm")) {
            for (int i = 0; i < inventory.Side.Length; i++) {
                if (inventory.SideIsFull[i] == false) {
                    inventory.SideIsFull[i] = true;
                    player.Money -= p.value;
                    Instantiate(prefab, inventory.Side[i].transform, false);
                    break;
                }
            }
        }
        else if (prefab.CompareTag("Consumable")) {
            for (int i = 0; i < inventory.Consumable.Length; i++) {
                if (inventory.ConsumableIsFull[i] == false) {
                    inventory.ConsumableIsFull[i] = true;
                    player.Money -= p.value;
                    Instantiate(prefab, inventory.Consumable[i].transform, false);
                    break;
                }
            }
        }
        else if (prefab.CompareTag("Main Ammo")) {
            if (player.MainAmmo == player.MaxMainAmmo) {
                return;
            }
            else if ((player.MainAmmo + AmmoCount) > player.MaxMainAmmo) {
                player.MainAmmo = player.MaxMainAmmo;
                player.Money -= p.value;
            }
            else {
                player.MainAmmo += AmmoCount;
                player.Money -= p.value;
            }
        }

        else if (prefab.CompareTag("Side Ammo")) {
            if (player.SideAmmo == player.MaxSideAmmo) {
                return;
            }
            else if ((player.SideAmmo + AmmoCount) > player.MaxSideAmmo) {
                player.SideAmmo = player.MaxSideAmmo;
                player.Money -= p.value;
            }
            else {
                player.SideAmmo += AmmoCount;
                player.Money -= p.value;
            }
        }
        else if  (prefab.CompareTag("Damage Pill")) {
            player.bonusDamage += 10;
            player.Money -= p.value;
        }
        else if (prefab.CompareTag("HealthPill")) {
            player.MaxHealth += 10;
            player.Money -= p.value;
        }
        else if (prefab.CompareTag("Speed Pill")) {
            if (player.MOVE_SPEED + 1 <= player.maxSPEED) {
                player.MOVE_SPEED += 1;
                player.Money -= p.value;
            } else {
                Debug.Log("MAX SPEED ACHIEVED");
            }

        }
        else if (prefab.CompareTag("Jump")) {
            if (player.extraJumps == 0) {
                player.extraJumps += 1;
                player.Money -= p.value;
            } else {
                Debug.Log("DOUBLE JUMP ALREADY");
            }
        }
        else if (prefab.CompareTag("headlights")) {
            Debug.Log("buying Lights");
            
            if (!hlight.activeSelf) {
                hlight.SetActive(true);
                player.Money -= p.value;
            }
        }
    }
}
