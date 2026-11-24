using System.Collections.Generic;
// using UnityEditor.Build.Content;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    //关联public的控件对象

    public CustomGUIButton btnClose;

    //控件较多，拖动工作量过大 直接查找
    private List<CustomGUILabel>labPM = new List<CustomGUILabel>();
    private List<CustomGUILabel> labName = new List<CustomGUILabel>();
    private List<CustomGUILabel> labScore = new List<CustomGUILabel>();
    private List<CustomGUILabel> labTime = new List<CustomGUILabel>();

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 1; i <= 10; ++i)
        {
            labName.Add(this.transform.Find("Name/labName" + i).GetComponent<CustomGUILabel>());
            labScore.Add(this.transform.Find("Score/labScore" + i).GetComponent<CustomGUILabel>());
            labTime.Add(this.transform.Find("Time/labTime" + i).GetComponent<CustomGUILabel>());
        }
        //处理事件监听逻辑
        btnClose.clickEvent += () =>
        {
            this.HideMe();
            BeginPanel.Instance.ShowMe();
        };

        // GameDataMgr.Instance.AddRankInfo("测试数据",100,8432);

        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }

    public void UpdatePanelInfo()
    {
        //获取排行榜数据 并在此处更新
        List<RankInfo>list=GameDataMgr.Instance.rankData.list;
        //根据列表更新面板数据
        for(int i = 0; i < list.Count; ++i)
        {
            labName[i].content.text = list[i].name;
            labScore[i].content.text = list[i].score.ToString();
            int time=(int)list[i].time;
            labTime[i].content.text = "";
            if (time / 3600 > 0)
            {
                labTime[i].content.text += (time / 3600) + "时";
            }
            if(time%3600/60>0||labTime[i].content.text!="")
            {
                labTime[i].content.text += (time % 3600 / 60) + "分";
            }
            labTime[i].content.text += (time % 60) + "秒";

        }
    }
}
