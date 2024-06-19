using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winPanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
