using System.Collections;
using UnityEngine;

public static class MonobehaviourExtensions
{
    public static PausableCoroutine StartPausableCoroutine(this MonoBehaviour owner, IEnumerator coroutine)
    {
        return new PausableCoroutine(owner, coroutine);
    }
}
