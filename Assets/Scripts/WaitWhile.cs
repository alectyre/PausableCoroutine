using System;
using UnityEngine;

public class WaitWhile : CustomYieldInstruction
{
    Func<bool> m_Predicate;

    public override bool keepWaiting => m_Predicate.Invoke();

    public WaitWhile(Func<bool> predicate) { m_Predicate = predicate; }
}