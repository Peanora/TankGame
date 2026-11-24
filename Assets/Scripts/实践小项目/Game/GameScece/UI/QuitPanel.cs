using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnGoOn;
    public CustomGUIButton btnClose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        btnQuit.clickEvent += () =>
        {
            //回到主界面
            SceneManager.LoadScene("BeginScene");
        };

        btnGoOn.clickEvent += () =>
        {
            HideMe();
        };

        btnClose.clickEvent += () =>
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
