using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name; // name of NPC

    [TextArea(3, 10)]
    public string[] lines; // array of lines to load into the queue

}
