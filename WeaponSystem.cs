using Unity.VisualScripting;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
  //weapon system for a player instance dec 24 2025

    private int slots = 2; //ammount of waepons that can be held at a time

    private Weapon[] inventory;


    void Start()
    {
        inventory = new Weapon[slots];
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            inventory[1].is_selected = true;
            inventory[2].is_selected = false;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)){
            inventory[1].is_selected = false;
            inventory[2].is_selected = true;
        }
    }
}

