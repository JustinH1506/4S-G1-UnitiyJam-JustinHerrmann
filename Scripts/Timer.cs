using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private int timeValue = 42;

    [SerializeField] private GameObject losePanel;

    private void Start()
    {
        timerText.text = timeValue.ToString();

        StartCoroutine(TimeWait());
    }

    IEnumerator TimeWait()
    {
        yield return new WaitForSeconds(1);

        timeValue--;
        
        timerText.text = timeValue.ToString();

        StartCoroutine(TimeWait());
        
        
        if (timeValue <= 0)
        {
            losePanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
