using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoliageBounce : MonoBehaviour
{
    public Animator bounceAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider collisionVolume)
    {
        if (collisionVolume.gameObject.CompareTag("Player")) // if object with tag "player" enters the collision volume
        {
            bounceAnim.SetBool("Stepped On", true);
        }
    }

    private void OnTriggerExit(Collider collisionVolume)
    {
        if (collisionVolume.gameObject.CompareTag("Player")) // if object with tag "player" exits the collision volume
        {
            bounceAnim.SetBool("Stepped On", false);
        }
    }
}
