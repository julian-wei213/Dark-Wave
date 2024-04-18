using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_switch : MonoBehaviour
{
    public Sprite[] SpriteArray;
    public SpriteRenderer spriteRenderer;
    private Inventory inventory;
    public string CurrentGun = "";
    public int CurrentSlot = -1;
    public GameObject akFlash;
    public GameObject p90Flash;
    public GameObject coltFlash;
    public GameObject shotgunFlash;
    public GameObject flashlightLight;
    private weapons weapons;
    private Player player;


    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<weapons>();
        akFlash.SetActive(false);
        p90Flash.SetActive(false);
        coltFlash.SetActive(false);
        shotgunFlash.SetActive(false);
        flashlightLight.SetActive(false);
    }

    private async void Update() {
        if (CurrentGun == "") {
            spriteRenderer.sprite = null;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (inventory.MainIsFull[0] == true) {
                if (inventory.Main[0].transform.Find("ak47(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[0];
                    CurrentGun = "ak47";
                } else if (inventory.Main[0].transform.Find("p90(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[1];
                    CurrentGun = "p90";
                } else if (inventory.Main[0].transform.Find("shotgun(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[6];
                    CurrentGun = "shotgun";
                }
            } else {
                spriteRenderer.sprite = null;
                CurrentGun = "";
            }

            CurrentSlot = 1;

        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (inventory.MainIsFull[1] == true) {
                if (inventory.Main[1].transform.Find("ak47(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[0];
                    CurrentGun = "ak47";
               } else if (inventory.Main[1].transform.Find("p90(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[1];
                    CurrentGun = "p90";
                } else if (inventory.Main[1].transform.Find("shotgun(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[6];
                    CurrentGun = "shotgun";
                }

            } else {
                spriteRenderer.sprite = null;
                CurrentGun = "";
            }

            CurrentSlot = 2;
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            if (inventory.SideIsFull[0] == true) {
                spriteRenderer.sprite = SpriteArray[2];

                CurrentGun = "colt";
            } else {
                spriteRenderer.sprite = null;
                CurrentGun = "";
            }

            CurrentSlot = 3;
        } else if  (Input.GetKeyDown(KeyCode.Alpha4)) {

            if (inventory.ConsumableIsFull[0] == true) {
                if (inventory.Consumable[0].transform.Find("flashlightbutton(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[4];
                    CurrentGun = "flashlight";
                } else if (inventory.Consumable[0].transform.Find("health(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[3];
                    CurrentGun = "health";
                } else if (inventory.Consumable[0].transform.Find("glowstick 1(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[5];
                    CurrentGun = "glowstick";
                }
            } else {
                spriteRenderer.sprite = null;
                CurrentGun = "";
            }

            CurrentSlot = 4;

        } else if  (Input.GetKeyDown(KeyCode.Alpha5)) {

            if (inventory.ConsumableIsFull[1] == true) {
                if (inventory.Consumable[1].transform.Find("flashlightbutton(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[4];
                    CurrentGun = "flashlight";
                } else if (inventory.Consumable[1].transform.Find("health(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[3];
                    CurrentGun = "health";
                } else if (inventory.Consumable[1].transform.Find("glowstick 1(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[5];
                    CurrentGun = "glowstick";
                }
            } else {
                spriteRenderer.sprite = null;
                CurrentGun = "";
            }

            CurrentSlot = 5;
        } else if  (Input.GetKeyDown(KeyCode.Alpha6)) {

            if (inventory.ConsumableIsFull[2] == true) {
                if (inventory.Consumable[2].transform.Find("flashlightbutton(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[4];
                    CurrentGun = "flashlight";
                } else if (inventory.Consumable[2].transform.Find("health(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[3];
                    CurrentGun = "health";
                } else if (inventory.Consumable[2].transform.Find("glowstick 1(Clone)")) {
                    spriteRenderer.sprite = SpriteArray[5];
                    CurrentGun = "glowstick";
                }
            } else {
                spriteRenderer.sprite = null;
                CurrentGun = "";
            }

            CurrentSlot = 6;
        }

        if (CurrentGun == "ak47")
        {
            akFlash.SetActive(true);
            p90Flash.SetActive(false);
            coltFlash.SetActive(false);
            shotgunFlash.SetActive(false);
            flashlightLight.SetActive(false);
            transform.localPosition = new Vector3(0.269f, -0.092f, -0.9595453f);
        }
        else if (CurrentGun == "p90")
        {
            akFlash.SetActive(false);
            p90Flash.SetActive(true);
            coltFlash.SetActive(false);
            shotgunFlash.SetActive(false);
            flashlightLight.SetActive(false);
            transform.localPosition = new Vector3(0.426f, 0.04f, -0.9595453f);
        }
        else if (CurrentGun == "colt")
        {
            akFlash.SetActive(false);
            p90Flash.SetActive(false);
            coltFlash.SetActive(true);
            shotgunFlash.SetActive(false);
            flashlightLight.SetActive(false);
            transform.localPosition = new Vector3(0.981f, -0.027f, -0.9595453f);
        }
        else if (CurrentGun == "health") 
        {
            akFlash.SetActive(false);
            p90Flash.SetActive(false);
            coltFlash.SetActive(false);
            shotgunFlash.SetActive(false);
            flashlightLight.SetActive(false);
            transform.localPosition = new Vector3(0.738f, -0.027f, -0.9595453f);
        }
        else if (CurrentGun == "flashlight")
        {
            akFlash.SetActive(false);
            p90Flash.SetActive(false);
            coltFlash.SetActive(false);
            shotgunFlash.SetActive(false);
            flashlightLight.SetActive(true);
            transform.localPosition = new Vector3(0.834f, -0.051f, -0.9595453f);
        }
        else if (CurrentGun == "glowstick")
        {
            akFlash.SetActive(false);
            p90Flash.SetActive(false);
            coltFlash.SetActive(false);
            shotgunFlash.SetActive(false);
            flashlightLight.SetActive(false);
            transform.localPosition = new Vector3(0.834f, -0.051f, -0.9595453f);
        }
        else if (CurrentGun == "shotgun")
        {
            akFlash.SetActive(false);
            p90Flash.SetActive(false);
            coltFlash.SetActive(false);
            shotgunFlash.SetActive(true);
            flashlightLight.SetActive(false);
            transform.localPosition = new Vector3(0.28f, -0.08f, 0f);
        }

        weapons.currentWeapon = CurrentGun;
    }
}
