using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            WinPanel.Instance.ShowMe();
            // SceneManager.LoadScene("BeginScene");
        }
    }
}
