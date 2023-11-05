using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class responseObject
{
    [SerializeField] private string responseText;
    [SerializeField] private DialougeObject resultDialouge;

    public string ResponseText => responseText;

    public DialougeObject ResultDialouge => resultDialouge;
}
