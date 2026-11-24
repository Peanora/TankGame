using UnityEngine;

/// <summary>
/// 游戏数据管理类（单例）
/// </summary>
public class GameDataMgr
{
    //单例模式
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance { get => instance; }


    //音效数据对象
    public MusicData musicData;
    //排行榜数据对象
    public RankList rankData;

    //构造函数
    private GameDataMgr()
    {
        //初始化游戏数据
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData),"Music") as MusicData;
        //如果第一次进入游戏 没有音效数据 那么所有的数据要不是false 要不是0
        if (!musicData.notFirst)
        {
            musicData.isOpenBK = true;
            musicData.isOpenSound = true;
            musicData.bkValue = 1;
            musicData.soundValue = 1;
            musicData.notFirst = true;

            //保存数据
            PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
        }
        //初始化读取排行榜数据
        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "Rank") as RankList;
    }

    //提供一些API给外部 方便数据的改变存储

    //提供一个在排行榜中添加数据的方法
    public void AddRankInfo(string name,int score,float time)
    {
        rankData.list.Add(new RankInfo(name, score, time));
        rankData.list.Sort((a,b)=>a.time<b.time?-1:1);
        for(int i=rankData.list.Count-1;i>=10;--i)
        {
            rankData.list.RemoveAt(i);
        }
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "Rank");
    }

    //开启或者关闭背景音乐
    public void OpenOrCloseBKMusic(bool isOpen)
    {
        musicData.isOpenBK = isOpen;

        //在这里控制场景上的背景音乐开关
        BKMusic.Instance.ChangeOpen(isOpen);

        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

    //开启或关闭音效
    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

    //改变背景音乐音量
    public void ChangeBKMusicValue(float value)
    {
        musicData.bkValue = value;

        //在这里控制场景上的背景音乐大小
        BKMusic.Instance.ChangeValue(value);

        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

    //改变音效音量
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
}
