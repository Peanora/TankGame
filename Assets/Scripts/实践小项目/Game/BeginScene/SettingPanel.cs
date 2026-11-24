using UnityEngine;
using UnityEngine.SceneManagement;


public class SettingPanel : BasePanel<SettingPanel>
{
    //声明成员变量 关联控件
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;

    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;

    public CustomGUIButton btnClose;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //监听对应的事件 处理逻辑

        //处理音乐的变化
        sliderMusic.changeValue += (value) => GameDataMgr.Instance.ChangeBKMusicValue(value);
        //处理音效的变化
        sliderSound.changeValue += (value) => GameDataMgr.Instance.ChangeSoundValue(value);
        //处理音乐开关
        togMusic.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBKMusic(value);
        //处理音效开关
        togSound.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseSound(value);

        btnClose.clickEvent += () =>
        {
            //关闭设置面板
            this.HideMe();

            if(SceneManager.GetActiveScene().name == "BeginScene")
            {
                BeginPanel.Instance.ShowMe();   
            }
        };
        
        HideMe();
    }

    public void UpdatePanelInfo()
    {
        //我们面板上的信息都是根据音效数据更新的
        MusicData data = GameDataMgr.Instance.musicData;

        //设置面板内容
        sliderMusic.nowValue = data.bkValue;
        sliderSound.nowValue = data.soundValue;
        togMusic.isSel = data.isOpenBK;
        togSound.isSel = data.isOpenSound;
    }

    override public void ShowMe()
    {
        base.ShowMe();

        //更新面板信息
        UpdatePanelInfo();
    }

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
