using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // (77)

public class Damage : MonoBehaviour
{
    public Image image; // (75)
    public float flashSpeed; // (76)

    private Coroutine coroutine; // (80)

    void Start()
    {
        CharacterManager.Instance.Player.condition.onTakeDamage += Flash; // (83)
    }

    public void Flash()
    {
        if (coroutine != null) // (82)
        {
            StopCoroutine(coroutine);
        }
        image.enabled = true; // (81) // 이미지 켜고
        image.color = new Color(1f, 100f / 255f, 100f / 255f);
        coroutine = StartCoroutine(FadeAway());
    }

    private IEnumerator FadeAway()
    {
        float startAlpha = 0.3f; // (77)
        float a = startAlpha;

        while (a > 0)
        {
            a -= (startAlpha / flashSpeed) * Time.deltaTime;
            image.color = new Color(1f, 100f / 255f, 100f / 255f, a);
            yield return null; // (78) // 반환할게 없으면 null
        }
        image.enabled = false; // (79)
    }
}