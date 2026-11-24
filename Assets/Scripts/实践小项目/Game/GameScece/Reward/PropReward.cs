using System;
using UnityEngine;
using UnityEngine.Rendering;

public enum E_PropType
{
    Atk,
    Def,
    MaxHP,
    HP
}
public class PropReward : MonoBehaviour
{
    public E_PropType type = E_PropType.Atk;

    public int changeValue = 2;

    public GameObject getEff;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerObj player = other.GetComponent<PlayerObj>();
            switch (type)
            {
                case E_PropType.Atk:
                    player.atk += changeValue;
                    break;
                case E_PropType.Def:
                    player.def += changeValue;
                    break;
                case E_PropType.MaxHP:
                    player.maxHP += changeValue;
                    //更新血条
                    GamePanel.Instance.UpdateHP(player.maxHP,player.hp);
                    break;
                case E_PropType.HP:
                    player.hp=Mathf.Min(player.hp+changeValue,player.maxHP);
                    //更新血条
                    GamePanel.Instance.UpdateHP(player.maxHP,player.hp);
                    break;
            }

            //播放奖励特效
            GameObject eff = Instantiate(getEff,this.transform.position,this.transform.rotation);
            AudioSource audioS = eff.GetComponent<AudioSource>();
            audioS.volume = GameDataMgr.Instance.musicData.soundValue;
            audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;

            Destroy(this.gameObject);
        }
    }
}
