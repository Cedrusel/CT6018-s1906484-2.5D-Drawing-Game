using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // use Unity Events

public class Interaction : MonoBehaviour
{

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public Animator ibubbleAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isInRange) // check if the player is in range
        {

            if (Input.GetKeyDown(interactKey)) // check if player is pressing the set key to interact with object
            {

                interactAction.Invoke(); // trigger event

            }

        }

    }

    private void OnTriggerEnter(Collider collisionVolume)
    {
        if (collisionVolume.gameObject.CompareTag("Player")) // if the player (tagged with Player) enters the collision trigger
        {

            isInRange = true; // set isInRange to true
            ibubbleAnim.SetBool("inRange", true); // set bubble animation inRange bool to true
            Debug.Log("Player is in range!"); // write a message to the debug log to confirm

        }
    }

    private void OnTriggerExit(Collider collisionVolume)
    {
        if (collisionVolume.gameObject.CompareTag("Player")) // if the player (tagged with Player) exits the collision trigger
        {

            isInRange = false; // set isInRange to false
            ibubbleAnim.SetBool("inRange", false); // set bubble animation inRange bool to false
            Debug.Log("Player is now out of range!"); // write a message to the debug log to confirm

        }
    }
}
