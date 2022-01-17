using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public AudioSource typingSound;

    public Animator dbAnim;

    private Queue<string> lines; //declare a queue of strings called lines

    // Start is called before the first frame update
    void Start()
    {
        lines = new Queue<string>();
        typingSound = GetComponent<AudioSource>();
    }
    
    public void beginDialogue (Dialogue dialogue)
    {
        dbAnim.SetBool("isOpen", true);
        
        nameText.text = dialogue.name;

        lines.Clear(); //clear lines in the queue

        foreach (string line in dialogue.lines)
        {
            lines.Enqueue(line); // add line to queue
        }

        displayNextLine();
    }

    public void displayNextLine ()
    {
        if (lines.Count == 0) // if there are no more lines in the queue
        {
            endDialogue();
            return;
        }

        string line = lines.Dequeue();
        dialogueText.text = line;
        //StopAllCoroutines(); //stop any coroutines to avoid conflicting animations
        StartCoroutine(TypeLine(line)); //call the TypeLine coroutie
    }

    IEnumerator TypeLine (string line) // define TypeLine coroutine to type out each letter in a line
    {
        typingSound.Play(); // begin playing text typing sound
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray()) //use ToCharArray to convert strings into character array for each letter in the line
        {
            dialogueText.text += letter; // add letter to the dialogue text one by one
            yield return null; // wait a set amount of time
        }
        typingSound.Stop(); // stop playing text typing sound
    }

    void endDialogue()
    {
        dbAnim.SetBool("isOpen", false);
    }
}
