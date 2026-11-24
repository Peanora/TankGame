using UnityEngine;
using UnityEngine.AI;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 50;

    public TankBaseObj fatherObj;

    //特效对象
    public GameObject effObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube")||other.CompareTag("Player")&&fatherObj.CompareTag("Monster")||other.CompareTag("Monster")&&fatherObj.CompareTag("Player"))
        {
            TankBaseObj obj = other.GetComponent<TankBaseObj>();
            if(obj != null)obj.Wound(fatherObj);

            //子弹销毁时 创建爆炸特效
            if (effObj != null)
            {
                GameObject eff = Instantiate(effObj,this.transform.position,this.transform.rotation);
                //改音效的音量和开启状态
                AudioSource audioS = eff.GetComponent<AudioSource>();
                audioS.volume = GameDataMgr.Instance.musicData.soundValue;
                audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;

                // Destroy(eff,3f);
            }


            Destroy(this.gameObject);   
        }
    }

    public void setFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }
}
