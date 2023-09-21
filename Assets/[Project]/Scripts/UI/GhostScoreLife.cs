using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GhostScoreLife : MonoBehaviour
{
    [SerializeField] float fallingSpeed;
    RectTransform rectTransform;
    TextMeshProUGUI text;
    float fallingValue;

    void Start()
    {
        rectTransform = (RectTransform)transform;
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Initialise(RectTransform creatorRectTransform)
    {
        rectTransform = creatorRectTransform;
    }

    void Update()
    {
        float lerpTime = 1;
        lerpTime -= Time.deltaTime;

        Color newColorText = new Color(text.color.r, text.color.g, text.color.b, lerpTime);
        text.color = newColorText;

        fallingValue = fallingSpeed * Mathf.InverseLerp(1, 0, lerpTime);
        Vector2 newRectPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + fallingValue);
        rectTransform.anchoredPosition = newRectPosition;

        if(lerpTime <= 0)
        {
            print("Delete ghost");
            Destroy(gameObject);
        }
    }
}
