using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Utils
{
    #region UI Effects

    static public IEnumerator DoFadeOut(CanvasGroup canvasG)
    {
        while (canvasG.alpha > 0)
        {
            canvasG.alpha -= Time.deltaTime * 2;
            yield return null;
        }

        canvasG.interactable = false;
        canvasG.blocksRaycasts = false;
    }

    static public IEnumerator DoFadeIn(CanvasGroup canvasG)
    {
        canvasG.interactable = true;
        canvasG.blocksRaycasts = true;

        while (canvasG.alpha < 1)
        {
            canvasG.alpha += Time.deltaTime * 2;
            yield return null;
        }
    }

    #endregion
}
