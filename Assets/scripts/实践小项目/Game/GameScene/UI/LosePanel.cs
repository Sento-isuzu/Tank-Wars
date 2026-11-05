using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : BasePanel<LosePanel>
{
    public ButtonGUI btnBack;
    public ButtonGUI btnAgain;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        btnBack.Onclick += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        };
        btnAgain.Onclick += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
        };
        HideMe();
    }
    public override void ShowMe()
    {
        base.ShowMe();
        Cursor.lockState = CursorLockMode.Confined;
    }
}
