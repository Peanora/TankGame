using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    public CustomGUIInput inputInfo;
    public CustomGUIButton btnSure;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        btnSure.clickEvent += () =>
        {
            Time.timeScale = 1;

            GameDataMgr.Instance.AddRankInfo(inputInfo.content.text,
                GamePanel.Instance.nowScore,
                GamePanel.Instance.nowTime);

            SceneManager.LoadScene("BeginScene");
        };

        HideMe();
    }


}
