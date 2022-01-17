using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteract : MonoBehaviour
{
    public bool isInteracted;
    public GameObject TextureEditor;
    public GameObject Overworld;

    public void Start()
    {
        TextureEditor.SetActive(false);
    }
    public void InteractWith()
    {

        if(!isInteracted)
        {

            isInteracted = true; // set isInteracted to true
            Debug.Log("Interaction Started"); // print to debug log

            Time.timeScale = 0; // pause the game

            Overworld.SetActive(false);
            TextureEditor.SetActive(true);
        }else
        {
            isInteracted = false; // set isInteracted to false, allows player to draw again.
        }

    }

}
