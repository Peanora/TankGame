using UnityEngine;

/// <summary>
/// 音乐数据类
/// </summary>
public class MusicData
{
    //背景音乐是否开启
    public bool isOpenBK;
    //音效是否开启
    public bool isOpenSound;
    //背景音乐音量
    public float bkValue;
    //音效音量
    public float soundValue;


    //加一个是否是第一次加载数据的标识
    public bool notFirst;
}
