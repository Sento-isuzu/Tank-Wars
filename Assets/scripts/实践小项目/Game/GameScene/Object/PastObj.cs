using UnityEngine;
using UnityEngine.SceneManagement;

public class PastObj : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            //显示结束场景
            WinPanel.Instance.ShowMe();
        }
    }
}
