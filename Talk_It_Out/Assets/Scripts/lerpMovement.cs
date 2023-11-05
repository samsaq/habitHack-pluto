using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpMovement : MonoBehaviour
{
    public Vector3 endPosition;
    private Vector3 startPosition;

    [SerializeField] private float movementDuration = 1.5f;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        dialogueSystem.choicesToDialouge += swapStartAndEnd;
        dialogueSystem.dialougeToChoices += swapStartAndEnd;
    }

    private void swapStartAndEnd()
    {
        Vector3 oldStart = startPosition;
        startPosition = endPosition; endPosition = oldStart;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / movementDuration;

        transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.SmoothStep(0,1,percentageComplete));
    }
}
