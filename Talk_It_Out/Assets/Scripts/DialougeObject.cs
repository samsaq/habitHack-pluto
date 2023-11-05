using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialouge/DialougeObject")]
public class DialougeObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialouge;
    [SerializeField] private responseObject[] responses;

    public string[] Dialouge => dialouge;

    public responseObject[] ResponseObjects => responses;
}
