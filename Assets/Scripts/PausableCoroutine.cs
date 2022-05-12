using System.Collections;
using UnityEngine;

public class PausableCoroutine : IEnumerator
{
    public bool IsDone { get; private set; }
    public bool Paused { get; set; }
    public bool MoveNext() => IsDone == false;
    public object Current { get; }
    public void Reset() { }

    public PausableCoroutine(MonoBehaviour owner, IEnumerator coroutine)
    {
        Current = owner.StartCoroutine(Wrap(coroutine));
    }

    private IEnumerator Wrap(IEnumerator coroutine)
    {
        while (true)
        {
            if (Paused == false)
            {
                if (coroutine.MoveNext())
                    yield return coroutine.Current;
                else
                    break;
            }
            else
                yield return null;
        }
        IsDone = true;
    }
}

