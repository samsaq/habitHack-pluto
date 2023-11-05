using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class dialogueSystem : MonoBehaviour
{
    //The events to switch from dialouge to choices and choices to dialouge
    public static event Action dialougeToChoices;
    public static event Action choicesToDialouge;

    [SerializeField] private DialougeObject introDialouge;

    //Get references to everything we need to manage
    //Character Right References
    [SerializeField] private Image characterRightImage;
    [SerializeField] TMP_Text characterRightName;

    //Character Left References
    [SerializeField] private Image characterLeftImage;
    [SerializeField] private TMP_Text characterLeftName;

    //Dialouge Option References
    [SerializeField] private TMP_Text dialougeOption1;
    [SerializeField] private TMP_Text dialougeOption2;
    [SerializeField] private TMP_Text dialougeOption3;

    //Dialouge Text References
    [SerializeField] private TMP_Text dialougeText;

    //Dialouge Background Reference
    [SerializeField] private Image dialougeBackground;

    private typeWriterEffect typeWriter;
    private responseHandler responseHandler;

    // Start is called before the first frame update
    void Start()
    {
        responseHandler = GetComponent<responseHandler>();
        typeWriter = GetComponent<typeWriterEffect>();
        showDialougeStream(introDialouge);
    }

    public void showDialougeStream (DialougeObject dialouge)
    {
        StartCoroutine(stepThroughDialouge(dialouge));
    }

    private IEnumerator stepThroughDialouge (DialougeObject dialougeObject)
    {
        for (int i = 0; i < dialougeObject.Dialouge.Length; i++)
        {
            string dialouge = dialougeObject.Dialouge[i];
            yield return typeWriter.Run(dialouge, dialougeText);

            if(i == dialougeObject.Dialouge.Length - 1 && dialougeObject.hasResponses)
            {
                break;
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if(dialougeObject.hasResponses)
        {
            endDialougeBeginChoice();
            responseHandler.showResponses(dialougeObject.ResponseObjects);
        }

    }



    private void endDialougeBeginChoice()
    {
        //disable the dialouge text object and enable the dialouge choice objects
        //move the character left and right objects up to make room

        dialougeText.transform.parent.gameObject.SetActive(false);
        dialougeOption1.transform.parent.transform.parent.gameObject.SetActive(true);


        //we'll need to handle the text background here

        //character section movement handled by event
        dialougeToChoices?.Invoke();

    }

    public void beginDialougeEndChoice() 
    {
        //disable the dialouge choice objects and enalbe the dialouge text object
        //move the character left and right objects up to make room
        dialougeOption1.transform.parent.transform.parent.gameObject.SetActive(false);
        dialougeText.transform.parent.gameObject.SetActive(true);

        //we'll need to handle the text background here

        choicesToDialouge?.Invoke();
    }

}
