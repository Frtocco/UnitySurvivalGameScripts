using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace Survival.Assets.Scripts
{
    public static class UIFader
    {
        public static IEnumerator Fade(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
        {
            float time = 0f;
            canvasGroup.alpha = startAlpha;

            while (time < duration)
            {
                time += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, time / duration);
                yield return null;
            }

            canvasGroup.alpha = 1;
        }

        public static IEnumerator FadeOut(CanvasGroup canvasGroup, float duration)
        {
            yield return Fade(canvasGroup, canvasGroup.alpha, 0f, duration);
        }

        public static IEnumerator FadeIn(CanvasGroup canvasGroup, float duration)
        {
            yield return Fade(canvasGroup, canvasGroup.alpha, 1f, duration);
        }


        public static IEnumerator FadeOutText(TMP_Text text, float duration)
        {
            float time = 0f;
            text.alpha = 1;

            while (time < duration)
            {
                time += Time.deltaTime;
                text.alpha = Mathf.Lerp(1, 0, time / duration);
                yield return null;
            }

        }
    }
}