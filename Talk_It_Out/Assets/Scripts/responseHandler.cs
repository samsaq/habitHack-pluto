using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class responseHandler : MonoBehaviour
{
    //References to the dialougeOptions that we'll need to set (the objects with the text, not the ones with the exact same name, its their children)
    [SerializeField] private GameObject dialougeOption1GameObject;
    [SerializeField] private GameObject dialougeOption2GameObject;
    [SerializeField] private GameObject dialougeOption3GameObject;

    private dialogueSystem dialogue_System;

    private bool responsesDisplayed = false;

    private void Start()
    {
        dialogue_System = GetComponent<dialogueSystem>();
    }

    public void showResponses(responseObject[] responses)
    {

        dialougeOption1GameObject.GetComponent<TMP_Text>().text = "1) " + responses[0].ResponseText;
        dialougeOption1GameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        dialougeOption1GameObject.GetComponent<Button>().onClick.AddListener(() => onPickedResponse(responses[0]));

        dialougeOption2GameObject.GetComponent<TMP_Text>().text= "2) " + responses[1].ResponseText;
        dialougeOption2GameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        dialougeOption2GameObject.GetComponent<Button>().onClick.AddListener(() => onPickedResponse(responses[1]));

        dialougeOption3GameObject.GetComponent<TMP_Text>().text = "3) " + responses[2].ResponseText;
        dialougeOption3GameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        dialougeOption3GameObject.GetComponent<Button>().onClick.AddListener(() => onPickedResponse(responses[2]));

        responsesDisplayed = true;
    }

    private void onPickedResponse(responseObject response)
    {
        //change ui element visibility as needed
        dialogue_System.beginDialougeEndChoice();
        responsesDisplayed = false;

        dialogue_System.showDialougeStream(response.ResultDialouge);
    }
}
