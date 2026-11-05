using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public ButtonGUI btnClose;

    //控件多，直接用list数组存储
    private List<LabelGUI> rankName=new List<LabelGUI>();
    private List<LabelGUI> rankScore=new List<LabelGUI>();
    private List<LabelGUI> rankTime=new List<LabelGUI>();
    void Start()
    {
        for (int i = 1; i <=9; i++) 
        {
            rankName.Add(this.transform.Find("Texture/RankName/rankName" + i).GetComponent<LabelGUI>());
            rankScore.Add(this.transform.Find("Texture/RankScore/rankScore" + i).GetComponent<LabelGUI>());
            rankTime.Add(this.transform.Find("Texture/RankTime/rankTime" + i).GetComponent<LabelGUI>());
        }
        //处理事件监听
        btnClose.Onclick += () => 
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };
        //同样开始游戏时就隐藏
        HideMe ();
    }
    public override void ShowMe()
    {
        base.ShowMe();
        UpadateRankInfo();
    }
    private void UpadateRankInfo()
    {
        //更新排行榜面板逻辑
        List<RankInfo> list = GameDataMgr.Instance.rankData.ranklist;
        for (int i = 0; i < list.Count; i++) 
        {
            //名字
            rankName[i].content.text = list[i].name;
            //分数
            rankScore[i].content.text=list[i].score.ToString();
            //时间 存储时间的单位是s
            //把秒数转换为 时 分 秒
            int time = (int)list[i].Time;
            rankTime[i].content.text = "";
            //转换
            if (time/3600>0)
            {
                rankTime[i].content.text += time / 3600 + "时";
            }
            if (time % 3600 / 60>0|| rankTime[i].content.text!="")
            {
                rankTime[i].content.text += time % 3600 / 60 + "分";
            }
            rankTime[i].content.text += time % 60 + "秒";
        }
    }

}
