using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance=new GameDataMgr();
    public static GameDataMgr Instance {  get =>instance;  }

    //音效数据对象
    public MusicData musicData;
    //排行榜数据
    public RankList rankData;

    private GameDataMgr() 
    {
        //去初始化 游戏数据
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData),"Music") as MusicData;
        if (!musicData.NotFrist)
        {
            musicData.NotFrist = true;
            musicData.isOpenMusic = true;
            musicData.isOpenSound = true;
            musicData.bkMusic = 0.1f;
            musicData.bkSound = 0.1f;
            PlayerPrefsDataMgr.Instance.SaveData(musicData,"Music");
        }
        //初始化 读取 排行榜数据
        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList),"Rank") as RankList;
    }
    //排行榜更改的数据
    public void AddRankInfo(string name,int score,float time)
    {
        rankData.ranklist.Add(new RankInfo(name,score,time));
        //排序
        rankData.ranklist.Sort((a, b) => a.Time < b.Time ? -1 : (a.Time > b.Time ? 1 : 0));
        //移除9以外的数
        for (int i = rankData.ranklist.Count-1; i >=9; i--) 
        {
            rankData.ranklist.RemoveAt(i);
        }
        //存储
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "Rank");
    }

    //开启或者关闭背景音乐
    public void OpenOrCloseBKMusic(bool isOpen)
    {
        musicData.isOpenMusic= isOpen;

        MusicBase.Instance.ChangeOpen(isOpen);
        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(musicData,"Music");
    }
    //开启或者关闭背景音效
    public void OpenOrCloseBKSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;

        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    //改变背景音乐大小
    public void ChangeBKMusic(float value)
    {
        musicData.bkMusic = value;

        MusicBase.Instance.ChangeValue(value);
        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    //改变背景音效方法
    public void ChangeBKSound(float value)
    {
        musicData.bkSound = value;
        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

}
