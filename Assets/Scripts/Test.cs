using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject isDone;
    [SerializeField] private GameObject isNotDone;
    [SerializeField] private GameObject isPaused;
    [SerializeField] private GameObject isNotPaused;
    [SerializeField] private Slider slider;
    [SerializeField] private float chunkDuration;
    [SerializeField] private float coroutineDuration = 5;

    private PausableCoroutine testCoroutine;

    public void StartCoroutine()
    {
        if (testCoroutine == null)
        {
            testCoroutine = this.StartPausableCoroutine(TestCoroutine());
            Pause(false);
        }
    }

    private void Update()
    {
        if (testCoroutine != null && !testCoroutine.IsDone)
        {
            isDone.SetActive(false);
            isNotDone.SetActive(true);
        }
        else
        {
            isDone.SetActive(true);
            isNotDone.SetActive(false);
        }
    }

    public void TogglePause()
    {
        if (testCoroutine != null)
            Pause(!testCoroutine.Paused);
    }

    public void Pause(bool value)
    {
        if (testCoroutine != null)
            testCoroutine.Paused = value;

        if (testCoroutine != null && !testCoroutine.Paused)
        {
            isPaused.SetActive(false);
            isNotPaused.SetActive(true);
        }
        else
        {
            isPaused.SetActive(true);
            isNotPaused.SetActive(false);
        }
    }

    private IEnumerator TestCoroutine()
    {
        float elapsed = 0;

        while (elapsed <= coroutineDuration)
        {
            slider.value = elapsed / coroutineDuration;

            elapsed += chunkDuration < Time.deltaTime ? Time.deltaTime : chunkDuration;
            Debug.Log(elapsed);

            yield return new WaitForSeconds(chunkDuration);
        }

        slider.value = 1;

        testCoroutine = null;
    }
}
