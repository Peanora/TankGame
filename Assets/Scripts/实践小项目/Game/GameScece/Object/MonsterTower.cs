using UnityEngine;

public class MonsterTower : TankBaseObj
{
    //间隔开火
    public float fireOffsetTime = 1;
    private float nowTime = 0;

    public Transform[] shootPos;

    public GameObject bulletObj;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        if(nowTime >= fireOffsetTime)
        {
            Fire();
            nowTime = 0;
        }
    }

    public override void Fire()
    {
        // throw new System.NotImplementedException();
        for(int i = 0; i < shootPos.Length; ++i)
        {
            GameObject obj = Instantiate(bulletObj,shootPos[i].position,shootPos[i].rotation);
            //设置子弹拥有者，方便之后进行属性计算
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.setFather(this);

        }
    }

    public override void Wound(TankBaseObj other)
    {
        
    }
}
