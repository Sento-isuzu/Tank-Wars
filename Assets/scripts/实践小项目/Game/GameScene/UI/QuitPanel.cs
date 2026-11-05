using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public ButtonGUI btnQuit1;
    public ButtonGUI btnQuit2;
    public ButtonGUI btnGoOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //关闭面板按钮
        btnQuit1.Onclick += () =>
        {
            HideMe();
        };
        //退出按钮
        btnQuit2.Onclick += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        };
        //继续游戏按钮
        btnGoOn.Onclick += () =>
        {
            HideMe();
        };
        HideMe();
    }

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
