using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BackgroundColor : MonoBehaviour
{
    [SerializeField] LineRenderer backgroundLineRenderer;
    [SerializeField] Gradient topSkyGradien;
    [SerializeField] Gradient botSkyGradien;

    public void BackgroundTransition(float duration, Action afterColorTransition)
    {
        DOTween.To((time) =>
        {
            Color topTargetColor = topSkyGradien.Evaluate(0);
            Color botTargetColor = botSkyGradien.Evaluate(0);

            Color topStartColor = backgroundLineRenderer.endColor;
            Color botStartColor = backgroundLineRenderer.startColor;

            Color lerpTopColor = Color.Lerp(topStartColor, topTargetColor, time);
            Color lerpBotColor = Color.Lerp(botStartColor, botTargetColor, time);

            backgroundLineRenderer.startColor = lerpBotColor;
            backgroundLineRenderer.endColor = lerpTopColor;
        }, 0, 1, duration)
        .SetEase(Ease.Linear)
        .OnComplete(() => 
        {
            afterColorTransition();
        });
    }

    public void SetBackgroundTimerColor(float time)
    { 
        Color topEvaluateColor = topSkyGradien.Evaluate(time);
        Color botEvaluateColor = botSkyGradien.Evaluate(time);

        backgroundLineRenderer.startColor = botEvaluateColor;
        backgroundLineRenderer.endColor = topEvaluateColor;
    }
}
