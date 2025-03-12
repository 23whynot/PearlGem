using System.Collections;
using UnityEngine;

namespace CodeBase.Gameplay.Zone
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}