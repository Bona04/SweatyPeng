using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSentence : MonoBehaviour
{
    public string[] sentences;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Dialogue")
        {
            DialogueManager.instance.Ondialogue(sentences);
        }

    }

    
}
