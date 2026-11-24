using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;
    public static BKMusic Instance => instance;

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        //得到自己依附的游戏对象上挂载的音频源脚本
        audioSource = GetComponent<AudioSource>();
    }


/// <summary>
/// 改变背景音乐大小
/// </summary>
/// <param name="value"></param>
    public void ChangeValue(float value)
    {
        audioSource.volume=value;
    }
/// <summary>
/// 开关背景音乐
/// </summary>
/// <param name="isOpen"></param>
    public void ChangeOpen(bool isOpen)
    {
        //开启不静音，否则经营
        audioSource.mute = !isOpen;
    }
}
