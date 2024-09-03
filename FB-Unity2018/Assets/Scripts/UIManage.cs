using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIManage : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public float time = 0.5f;

    public void ShowUI()
    {
        canvasGroup.DOFade(1, time);
    }

    public void HideUI()
    {
        canvasGroup.DOFade(0, time).onComplete = () =>
        {
           gameObject.SetActive(false);
        };

    }

   
}
