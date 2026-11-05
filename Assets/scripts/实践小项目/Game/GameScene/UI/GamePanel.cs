using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePanel : BasePanel<GamePanel>
{
    //时间、分数
    public LabelGUI labScore;
    public LabelGUI labTime;
    //设置、退出
    public ButtonGUI btnS;
    public ButtonGUI btnQ;
    //血量
    public TextureGUI texHp;

    //控制血条的宽
    public float hpW = 402;

    //记录当前分数
    [HideInInspector]
    public int nowScore=0;

    //时间相关
    [HideInInspector]
    public float nowTime = 0;

    private int time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        btnS.Onclick += () =>
        {
            Cursor.lockState = CursorLockMode.Confined;
            //设置面板
            SettingPanel.Instance.ShowMe();
            //暂停时间
            Time.timeScale = 0;
        };
        btnQ.Onclick += () =>
        {
            Cursor.lockState = CursorLockMode.Confined;
            //返回开始界面
            //弹出一个确定退出的按钮
            QuitPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cursor.lockState= CursorLockMode.Confined;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        //通过帧间隔记录时间
        nowTime += Time.deltaTime;
        //转换时间
        time = (int)nowTime;
        labTime.content.text = "";
        //转换
        if (time / 3600 > 0)
        {
            labTime.content.text += time / 3600 + "时";
        }
        if (time % 3600 / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += time % 3600 / 60 + "分";
        }
        labTime.content.text += time % 60 + "秒";


    }

    //
    public void AddScore(int score)
    {
        nowScore+=score;
        //改变当前得分数
        labScore.content.text=nowScore.ToString();
    }
    //更新血条的方法
    public void UpdateHp(int maxHP,int Hp)
    {
        texHp.guiPos.width=(float)Hp/maxHP*hpW;
    }
}
