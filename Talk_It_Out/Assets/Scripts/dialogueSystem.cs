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

    // Start is called before the first frame update
    void Start()
    {
        typeWriter = GetComponent<typeWriterEffect>();
        showDialougeStream(introDialouge);
    }

    public void showDialougeStream (DialougeObject dialouge)
    {
        StartCoroutine(stepThroughDialouge(dialouge));
    }

    private IEnumerator stepThroughDialouge (DialougeObject dialougeObject)
    {
        foreach (string dialouge in dialougeObject.Dialouge)
        {
            yield return typeWriter.Run(dialouge, dialougeText);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        endDialougeBeginChoice();

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

    private void beginDialougeEndChoice() 
    {
        //disable the dialouge choice objects and enalbe the dialouge text object
        //move the character left and right objects up to make room
        dialougeOption1.transform.parent.transform.parent.gameObject.SetActive(false);
        dialougeText.transform.parent.gameObject.SetActive(true);

        //we'll need to handle the text background here

        choicesToDialouge?.Invoke();
    }

    private void displayChoices(choicesObject choiceData)
    {
        //assume the right objects are enabled and disabled (this should only be run after beginDialougeEndChoices()

        //use the typewriter on the choices after taking data from the choiceObject



    }
}
