using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteract : MonoBehaviour
{

    public Dialogue dialogue;

    public void triggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().beginDialogue(dialogue);
    }

}
