using UnityEngine;

public class MonsterTower : BaseTank
{
    //发射位置
    public Transform[] shootPos;
    //子弹关联
    public GameObject bulletObj;
    //间隔开火
    public float fireOffsetTime=1;
    //判断开火间隔
    private float nowTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        if (nowTime>fireOffsetTime)
        {
            Fire();
            nowTime = 0;
        }
    }
    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            //实例化几个子弹
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            //得到子弹脚本,设置子弹拥有者
            bulletObj bullet = obj.GetComponent<bulletObj>();
            bullet.SetFather(this);
        }
    }
    public override void Wound(BaseTank other)
    {
        //因为是炮台，所以这一块什么都不用写
    }
}
