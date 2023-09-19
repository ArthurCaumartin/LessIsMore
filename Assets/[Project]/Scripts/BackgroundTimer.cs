using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTimer : MonoBehaviour
{
    [SerializeField] LineRenderer backgroundLineRenderer;
    [SerializeField] Gradient topSkyGradien;
    [SerializeField] Gradient botSkyGradien;


    public void SetBackgroundColor(float time)
    { 
        print(time);

        Color topEvaluateColor = topSkyGradien.Evaluate(time);
        Color botEvaluateColor = botSkyGradien.Evaluate(time);

        backgroundLineRenderer.startColor = botEvaluateColor;
        backgroundLineRenderer.endColor = topEvaluateColor;
    }
}
