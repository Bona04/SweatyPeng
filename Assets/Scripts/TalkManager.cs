using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
    
}
public class TalkManager : MonoBehaviour
{

    [SerializeField] private GameObject sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;

    private bool isDialogue = false;
    private int count = 0;

    [SerializeField] private Dialogue[] dialogue;

    public void ShowDialogue()
    {
        sprite_DialogueBox.gameObject.SetActive(true);
        txt_Dialogue.gameObject.SetActive(true);

        count = 0;
        isDialogue = true;

        NextDialogue();

    }

    private void HideDialogue()
    {
        sprite_DialogueBox.gameObject.SetActive(false);
        txt_Dialogue.gameObject.SetActive(false);

        isDialogue = false;
    }
    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;
        count++;
    }

    void Update()
    {
        if(isDialogue)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (count < dialogue.Length)
                    NextDialogue();
                else HideDialogue();
            }
        }
    }

}
