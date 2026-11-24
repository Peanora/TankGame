using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //摄像机看见的目标
    public Transform targetPlayer;
    public float H = 10;
    
    private Vector3 pos;

    void LateUpdate()
    {
        if(targetPlayer==null)return;

        pos.x=targetPlayer.position.x;
        pos.z=targetPlayer.position.z;
        pos.y=H;
        this.transform.position=pos;
    }
}
