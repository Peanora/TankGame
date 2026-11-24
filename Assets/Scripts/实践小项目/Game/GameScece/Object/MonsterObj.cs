using UnityEngine;

public class MonsterObj : TankBaseObj
{
    //坦克在两点间来回移动
    private Transform targetPos;

    public Transform[] randomPos;

    //坦克一直盯着自己的目标
    public Transform lookAtTarget;

    //目标到达一定范围后 间隔一段时间攻击
    public float fireDis = 5;
    public float fireOffsetTime = 1;
    private float nowTime = 0;

    public Transform[] shootPos;
    public GameObject bulletObj;

    public Texture maxHpBK;
    public Texture hpBK;

    //显示血条计时用时间
    private float showTime;

    //结构体可以不new
    private Rect maxHpRect;
    private Rect hpRect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(targetPos);
        this.transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);

        if(Vector3.Distance(this.transform.position, targetPos.position) < 0.05f)
        {
            RandomPos();
        }

        if (lookAtTarget != null)
        {
            tankHead.LookAt(lookAtTarget);

            if(Vector3.Distance(this.transform.position,lookAtTarget.position) <= fireDis)
            {
                nowTime += Time.deltaTime;
                if(nowTime >= fireOffsetTime)
                {
                    Fire();
                    nowTime = 0;
                }                
            }
        }


    }

    private void RandomPos()
    {
        if (randomPos.Length == 0)return;
        targetPos = randomPos[Random.Range(0,randomPos.Length)];
    }

    public override void Fire()
    {
        // throw new System.NotImplementedException();
        for(int i = 0; i < shootPos.Length; ++i)
        {
            GameObject obj = Instantiate(bulletObj,shootPos[i].position,shootPos[i].rotation);
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.setFather(this);
        }
    }

    public override void Dead()
    {
        base.Dead();

        GamePanel.Instance.AddScore(10);
    }

    private void OnGUI()
    {
        if(showTime > 0)
        {
            showTime -= Time.deltaTime;
            //画血条
            //把怪物位置转化成屏幕位置
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //屏幕位置转成GUI位置
            screenPos.y = Screen.height - screenPos.y;
            //绘制
            //底图
            maxHpRect.x = screenPos.x - 50;
            maxHpRect.y = screenPos.y - 50;
            maxHpRect.width = 100;
            maxHpRect.height = 15;
            GUI.DrawTexture(maxHpRect,maxHpBK);
        
            hpRect.x = screenPos.x - 50;
            hpRect.y = screenPos.y - 50;
            hpRect.width = (float)hp/maxHP*100f;
            hpRect.height = 15;
            GUI.DrawTexture(hpRect,hpBK);
        }
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);

        showTime = 3;
    }
}
