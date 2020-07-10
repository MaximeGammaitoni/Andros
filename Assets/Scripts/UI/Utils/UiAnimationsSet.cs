using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UiAnimationsSet
{
    public static void StartFadeIn()
    {
        MenuManager.singleton.StartCoroutine(FadeIn());
    }
    public static void StartFadeOut()
    {
        MenuManager.singleton.StartCoroutine(FadeOut());
    }
    private static IEnumerator FadeOut()
    {
        yield return 0;
    }
    private static IEnumerator FadeIn()
    {
        yield return 0;
    }
}
