using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    void Update()
    {
        fallingValue -=  Time.deltaTime * fallingSpeed;

        Color fallingcolor = new Color(text.color.r, text.color.g, text.color.b, text.color.a - fallingValue);
        text.color = fallingcolor;

        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - fallingValue);

        if(text.color.a <= 0f)
        {
            print("Delete ghost");
            Destroy(gameObject);
        }
    }
}
