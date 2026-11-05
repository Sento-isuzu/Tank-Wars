using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    public ButtonGUI btnBegin;
    public ButtonGUI btnEnd;
    public ButtonGUI btnSetting;
    public ButtonGUI btnRank;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        btnBegin.Onclick += () =>
        {
            //切换场景
            SceneManager.LoadScene("GameScene");
        };
        btnEnd.Onclick += () =>
        {
            Application.Quit();
            //结束游戏
        };
        btnSetting.Onclick += () =>
        {
            //打开设置面板
            SettingPanel.Instance.ShowMe();
            HideMe();
        };
        btnRank.Onclick += () =>
        {
            //打开排行榜
            RankPanel.Instance.ShowMe();
            HideMe();
        };

    }

}
