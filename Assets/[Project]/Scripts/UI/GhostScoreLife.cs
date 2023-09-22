using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GhostScoreLife : MonoBehaviour
{
    [SerializeField] AnimationCurve textAlphaCurve;
    [SerializeField] float yOffSet;
    [SerializeField] float speed;
    float positionTime;
    float alphaTime;
    TextMeshProUGUI text;
    RectTransform rectTransform;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        rectTransform = (RectTransform)transform;
        alphaTime = 1;
    }

    void Update()
    {
        positionTime += Time.deltaTime * speed;
        Vector3 newPosition = new Vector3(0, yOffSet * positionTime, 0);
        rectTransform.anchoredPosition = newPosition;

        alphaTime -= Time.deltaTime * speed;
        text.alpha = alphaTime;

        if(alphaTime <= 0)
        {
            Destroy(gameObject);
        }
    }   
}
