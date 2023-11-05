using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialouge/DialougeObject")]
public class DialougeObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialouge;
    [SerializeField] private responseObject[] responses;

    public string[] Dialouge => dialouge;

    public bool hasResponses => responses != null && responses.Length > 0;

    public responseObject[] ResponseObjects => responses;
}
