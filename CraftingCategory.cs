using UnityEngine;
using TMPro;

namespace Survival.Assets.Scripts
{
    public class CraftingCategory : MonoBehaviour
    {

        [SerializeField] private TMP_Text alertText;

        public void ShowAlert(string msg, float duration = 2f)
        {
            alertText.text = msg;
            alertText.alpha = 1f;
            alertText.gameObject.SetActive(true);

            StopAllCoroutines();
            StartCoroutine(UIFader.FadeOutText(alertText, 2f));
        }

        public void DisableAlert()
        {
            StopAllCoroutines();
            alertText.gameObject.SetActive(false);
        }
    }
}