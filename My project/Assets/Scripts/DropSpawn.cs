using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawn : MonoBehaviour
{
    public GameObject[] prefabs;
    public float ThrowPower = 10f;
    public float PickUpCooldown = 3f;
    private Inventory inventory;
    private weapon_switch ws;
    private MainSlot Mslot1;
    private MainSlot Mslot2;
    private SideSlot Sslot;
    private ConSlot Cslot1;
    private ConSlot Cslot2;
    private ConSlot Cslot3;
    private GameObject item;
    private Player player;
    private int offset;
    
    private void Start() {
        player = GetComponent<Player>();
        Mslot1 = GameObject.Find("main_slot (1)").GetComponent<MainSlot>();
        Mslot2 = GameObject.Find("main_slot (2)").GetComponent<MainSlot>();
        Sslot = GameObject.Find("side_slot (1)").GetComponent<SideSlot>();
        Cslot1 = GameObject.Find("con_slot (1)").GetComponent<ConSlot>();
        Cslot2 = GameObject.Find("con_slot (2)").GetComponent<ConSlot>();
        Cslot3 = GameObject.Find("con_slot (3)").GetComponent<ConSlot>();
        ws = GameObject.Find("Gun").GetComponent<weapon_switch>();

        foreach (GameObject prefab in prefabs) {
            prefab.transform.localScale = new Vector2( Mathf.Abs(prefab.transform.localScale.x), prefab.transform.localScale.y);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F) && ws.CurrentGun != "") { 

            if (ws.CurrentGun == "ak47") {
                item = prefabs[0];
                if (ws.CurrentSlot == 1) {
                    Mslot1.Drop_Item();
                    Drop();
                } else {
                    Mslot2.Drop_Item();
                    Drop();
                }
                ws.CurrentGun = "";
            }
            else if (ws.CurrentGun == "p90") {
                item = prefabs[1];
                if (ws.CurrentSlot == 2) {
                    Mslot2.Drop_Item();
                    Drop();
                } else {
                    Mslot1.Drop_Item();
                    Drop();
                }
                ws.CurrentGun = "";
            }
            else if  (ws.CurrentGun == "colt") {
                item = prefabs[2];
                Sslot.Drop_Item();
                Drop();

                ws.CurrentGun = "";
            }
            else if  (ws.CurrentGun == "health") {
                item = prefabs[3];
                if (ws.CurrentSlot == 4) {
                    Cslot1.Drop_Item();
                    Drop();
                } else if (ws.CurrentSlot == 5){
                    Cslot2.Drop_Item();
                    Drop();
                } else if (ws.CurrentSlot == 6) {
                    Cslot3.Drop_Item();
                    Drop();
                }

                ws.CurrentGun = "";
            }
            else if  (ws.CurrentGun == "flashlight") {
                item = prefabs[4];
                if (ws.CurrentSlot == 4) {
                    Cslot1.Drop_Item();
                    Drop();
                } else if (ws.CurrentSlot == 5){
                    Cslot2.Drop_Item();
                    Drop();
                } else if (ws.CurrentSlot == 6) {
                    Cslot3.Drop_Item();
                    Drop();
                }

                ws.CurrentGun = "";
            }
            else if  (ws.CurrentGun == "glowstick") {
                item = prefabs[5];
                if (ws.CurrentSlot == 4) {
                    Cslot1.Drop_Item();
                    Drop();
                } else if (ws.CurrentSlot == 5){
                    Cslot2.Drop_Item();
                    Drop();
                } else if (ws.CurrentSlot == 6) {
                    Cslot3.Drop_Item();
                    Drop();
                }

                ws.CurrentGun = "";
            }
            else if (ws.CurrentGun == "shotgun") {
                item = prefabs[6];
                if (ws.CurrentSlot == 1) {
                    Mslot1.Drop_Item();
                    Drop();
                } else {
                    Mslot2.Drop_Item();
                    Drop();
                }
                ws.CurrentGun = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && ws.CurrentGun != "") {
            if (ws.CurrentGun == "health" && player.Health != player.MaxHealth) {
                player.HealDamage(30);
                if (ws.CurrentSlot == 4) {
                    Cslot1.Drop_Item();
                } else if  (ws.CurrentSlot == 5) {
                    Cslot2.Drop_Item();
                } else if  (ws.CurrentSlot == 6) {
                    Cslot3.Drop_Item();
                }
            
                ws.CurrentGun = "";
            }
        }
    }
    public void Drop() {
        if (player.isFacingRight) {
             offset = 3;
             item.transform.localScale = new Vector2(Mathf.Abs(item.transform.localScale.x), item.transform.localScale.y);
        } else {
             offset = -3;
             item.transform.localScale = new Vector2(-item.transform.localScale.x, item.transform.localScale.y);
        }
        
        Vector2 Playerpos = new Vector2(player.transform.position.x + offset, player.transform.position.y + 1);
        GameObject clone;
        Rigidbody2D rb;
        
        clone = Instantiate(item, Playerpos, Quaternion.identity);
        rb = clone.GetComponent<Rigidbody2D>();

        if (player.isFacingRight) {
            rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
        } else {
            rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
        }
    }
}
