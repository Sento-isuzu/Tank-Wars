using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    //退出按钮
    public ButtonGUI btnGUI;
    //点击选项
    public ToggleGUI toggleMusic;
    public ToggleGUI toggleSound;
    //滑动条
    public SliderGUI sliderMusic;
    public SliderGUI sliderSound;
    void Start()
    {
        btnGUI.Onclick += () =>
        {
            //退出setting逻辑
            HideMe();
            if (SceneManager.GetActiveScene().name== "BeginScene")
            {
                BeginPanel.Instance.ShowMe();
            }
            
        };
        //音乐开启的逻辑
        toggleMusic.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBKMusic(value);
        //音效开启的逻辑
        toggleSound.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBKSound(value);
        //音乐大小的处理逻辑
        sliderMusic.OnValueChanged += (value) => GameDataMgr.Instance.ChangeBKMusic(value);
        //音效大小的处理逻辑
        sliderSound.OnValueChanged += (value) => GameDataMgr.Instance.ChangeBKSound(value);

        //进游戏时就隐藏自己,在start里面写保证基类awake时就能拿到脚本信息
        HideMe();
    }
    //音乐数据更新
    public void UpdatePanelInfo()
    {
        //取出musicData拿来用
        MusicData data = GameDataMgr.Instance.musicData;

        //设置面板内容
        sliderMusic.nowValue = data.bkMusic;
        sliderSound.nowValue = data.bkSound;
        toggleMusic.isSel=data.isOpenMusic;
        toggleSound.isSel=data.isOpenSound;
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
    public override void ShowMe()
    {
        base.ShowMe();
        //每次显示 面板时 顺便把面板上的设置更改为保存好的数据
        UpdatePanelInfo();
    }

}
