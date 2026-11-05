using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    public ButtonGUI buttonSure;
    public TextFieldGUI fieldName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        buttonSure.Onclick += () =>
        {
            Time.timeScale = 1;
            //存储时间
            GameDataMgr.Instance.AddRankInfo(fieldName.content.text,
                GamePanel.Instance.nowScore,GamePanel.Instance.nowTime);
            //加载开始场景
            SceneManager.LoadScene("BeginScene");
        };
        HideMe();
    }
    public override void ShowMe()
    {
        base.ShowMe();
        Cursor.lockState = CursorLockMode.Confined;
    }
}
