using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialouge/ChoicesObject")]
public class choicesObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] choices = new string[3];

    public string[] Choices => choices;
}
