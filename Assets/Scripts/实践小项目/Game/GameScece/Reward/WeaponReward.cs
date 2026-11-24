using Unity.VisualScripting;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    public GameObject[] weaponObj;

    //获取特效
    public GameObject getEff;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //让玩家切换武器
            int index = Random.Range(0,weaponObj.Length);
            
            //得到撞到的玩家身上挂载的脚本，命其切换武器
            PlayerObj player = other.GetComponent<PlayerObj>();
            player.ChangeWeapon(weaponObj[index]);

            //播放奖励特效
            GameObject eff = Instantiate(getEff,this.transform.position,this.transform.rotation);
            AudioSource audioS = eff.GetComponent<AudioSource>();
            audioS.volume = GameDataMgr.Instance.musicData.soundValue;
            audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            
            Destroy(this.gameObject);
        }
    }
}
