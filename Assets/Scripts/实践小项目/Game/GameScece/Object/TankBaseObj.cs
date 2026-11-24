using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    public int atk;
    public int def;
    public int maxHP;
    public int hp;

    //炮台
    public Transform tankHead;

    public float moveSpeed = 10;
    public float roundSpeed = 100;
    public float headRoundSpeed = 100;

    //死亡特效关联对应预设体 死亡时动态创建并设置位置
    public GameObject deadEff;

/// <summary>
/// 开火抽象方法 子类重写开火行为即可
/// </summary>
    public abstract void Fire();

/// <summary>
/// 被别人攻击 造成自身受伤
/// </summary>
/// <param name="other"></param>
    public virtual void Wound(TankBaseObj other)
    {
        int dmg = other.atk - this.def;
        if(dmg <= 0)return;
        this.hp -= dmg;
        if(this.hp <= 0)
        {
            hp = 0;
            Dead();
        }

    }

/// <summary>
/// 死亡行为
/// </summary>
    public virtual void Dead()
    {
        //对象死亡 在场景上移除该对象
        Destroy(this.gameObject);
        //死亡的时候 可能所有坦克对象都应该播放一个死亡特效
        if (deadEff != null)
        {
            GameObject effObj = Instantiate(deadEff,this.transform.position,this.transform.rotation);
            //由于该特效对象身上直接关联了音效 因此在此处同时控制音效
            AudioSource audioSource = effObj.GetComponent<AudioSource>();
            //根据音乐数据设置音效大小和是否播放
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            //音效是否播放
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            //保险 避免没勾选Play On Awake
            audioSource.Play();
        }
    }
}


