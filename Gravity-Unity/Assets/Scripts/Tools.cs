using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools 
{
    #region singleton pattern
    static Tools ins;

    public static Tools Ins
    {
        get
        {
            if(ins == null)
            {
                ins = new Tools();
            }
            return ins;
        }
    }

    Tools()
    {

    }
    #endregion

    public void ShowUI(GameObject uiOb)
    {
        uiOb.SetActive(true);
        uiOb.GetComponent<CanvasGroup>().alpha = 0;

        uiOb.GetComponent<UIManage>().ShowUI();
    }

    public void HideUI(GameObject uiOb)
    {
        uiOb.GetComponent<UIManage>().HideUI();
    }
}
