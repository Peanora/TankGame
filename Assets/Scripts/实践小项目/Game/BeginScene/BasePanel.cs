using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T : class
{
    //私有的静态成员变量（申明）
    private static T instance;
    //公有的静态成员属性或者方法（获取）
    public static T Instance => instance;

    private void Awake()
    {
        //在Awake中初始化的原因是：面板脚本在脚本上只会挂载一次
        //那么我们可以在脚本的生命周期函数的Awake中直接记录场景上唯一的这个版本
        instance = this as T;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
    }
}
