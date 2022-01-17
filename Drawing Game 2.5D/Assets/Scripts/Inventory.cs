using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject drawingInventory;
    public Animator inventoryAnim;
    public bool isInventoryOpen;

    private void Start()
    {

        isInventoryOpen = false;

    }
    void Update()
    {
        
        if(Input.GetKeyDown("i")) // if player presses the "i" key
        {
            if(isInventoryOpen == true) // if the inventory is open
            {
                //Time.timeScale = 1; // Unpause the game
                isInventoryOpen = false;
                inventoryAnim.SetBool("Open", false);
            }
            else // if the inventory is closed
            {
                //Time.timeScale = 0; // pause the game
                inventoryAnim.SetBool("Open", true);
                isInventoryOpen = true; // set isInventoryOpen to True

            }

        }

    }

}

