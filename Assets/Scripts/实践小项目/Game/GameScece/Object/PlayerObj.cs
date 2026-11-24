using UnityEngine;

public class PlayerObj : TankBaseObj
{
    //当前装备的武器
    public WeaponObj nowWeapon;

    //武器父对象位置
    public Transform weaponPos;

    public Camera mainCamera;


    // Update is called once per frame
    void Update()
    {
        //ws键控制前进后退
        this.transform.Translate(Input.GetAxis("Vertical")*Vector3.forward*moveSpeed*Time.deltaTime);

        //ad键控制旋转
        this.transform.Rotate(Input.GetAxis("Horizontal")*Vector3.up*roundSpeed*Time.deltaTime);

        //鼠标左右移动控制炮台旋转
        // tankHead.transform.Rotate(Input.GetAxis("Mouse X")*Vector3.up*headRoundSpeed*Time.deltaTime);
        TankHeadRotate();

        //开火
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }        
    }

    //重写父类中的行为


    public override void Fire()
    {
        // throw new System.NotImplementedException();
        if(nowWeapon!=null)nowWeapon.Fire();
    }

    public override void Dead()
    {
        //执行父类死亡，会把子类的摄像机移除，因此不执行
        // base.Dead();

        Time.timeScale = 0;
        LosePanel.Instance.ShowMe();
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        //更新主面板血条
        GamePanel.Instance.UpdateHP(this.maxHP,this.hp);
    }

    public void TankHeadRotate()
    {
        if(mainCamera==null||tankHead==null)return;
        Ray ray=mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane=new Plane(Vector3.up,tankHead.position);
        if (!plane.Raycast(ray,out float distance)) return;
        Vector3 aimPoint = ray.GetPoint(distance);
        // Debug.DrawLine(tankHead.position, aimPoint, Color.green);
        Vector3 direction = aimPoint - tankHead.position;
        if(direction.sqrMagnitude<0.01f)return;
        tankHead.rotation=Quaternion.LookRotation(direction,Vector3.up);

    }

    public void ChangeWeapon(GameObject weapon)
    {
        if (nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon=null;
        }
        //创建武器 设置父对象 并保证缩放无问题
        GameObject weaponObj = Instantiate(weapon,weaponPos,false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        nowWeapon.SetFather(this);
    }


}
