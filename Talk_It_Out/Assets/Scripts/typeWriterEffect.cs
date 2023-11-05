using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class typeWriterEffect : MonoBehaviour
{
    [SerializeField] private float typeSpeed = 50f;
    public Coroutine Run(string typeText, TMP_Text typeTarget)
    {
        return StartCoroutine(typeWriteText(typeText, typeTarget));
    }

    private IEnumerator typeWriteText(string typeText, TMP_Text typeTarget)
    {
        float t = 0;
        int charIndex = 0;

        while(charIndex < typeText.Length)
        {
            t += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, typeText.Length);
            
            typeTarget.text = typeText.Substring(0, charIndex);

            yield return null;
        }
    }
}
