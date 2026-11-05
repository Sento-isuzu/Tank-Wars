using UnityEngine;

public class MonsterMove : BaseTank
{
    private Transform tagPos;
    public Transform[] randomPos;

    //让炮头看向玩家
    public Transform lookAtTag;

    //开火距离
    public float fireDis=10;
    //开火间隔时间
    public float fireOffSetTime=1;
    private float nowTime = 0;

    //开火点
    public Transform[] shootPos;
    //子弹预设体
    public GameObject bulletObj;

    //底图坐标
    private Rect maxHpRect;
    //血条坐标
    private Rect hpRect;

    //图片
    public Texture maxHpTex;
    public Texture hpTex;
    //血条显示时间
    private float showTime=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(tagPos);
        //朝自己的面朝向移动
        this.transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);

        //判断两点之间的距离
        if (Vector3.Distance(this.transform.position,tagPos.position)<=0.05f)
        {
            //小于0.05f时重新生成一个点，继续移动
            RandomPos();
        }

        //不断看向玩家
        if (lookAtTag!=null)
        {
            TankHead.LookAt(lookAtTag);
            //判断开火
            if (Vector3.Distance(lookAtTag.position,this.transform.position)<=fireDis)
            {
                nowTime += Time.deltaTime;
                if (nowTime >= fireOffSetTime)
                {
                    Fire();
                    nowTime = 0;
                }            
            }
        }
    }
    private void OnGUI()
    {
        if (showTime>0)
        {
            //减时间直到为零
            showTime-= Time.deltaTime;

            //画图 画血条
            //世界坐标转屏幕坐标
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //屏幕位置转为GUI位置，这里是因为屏幕左下方是原点，而GUI是在左上角为原点
            screenPos.y = Screen.height - screenPos.y;

            //绘制
            maxHpRect.x = screenPos.x-50;
            maxHpRect.y = screenPos.y-50;       
            maxHpRect.width = 100;
            maxHpRect.height = 15;
            //画图
            GUI.DrawTexture(maxHpRect, maxHpTex);

            //绘制
            hpRect.x = screenPos.x - 50;
            hpRect.y = screenPos.y - 50;
            hpRect.width = (float)NowHp / MaxHp * 100f;
            hpRect.height = 15;
            //画图
            GUI.DrawTexture(hpRect, hpTex);
        }

    }
    //移动方法
    public void RandomPos()
    {
        if (randomPos.Length == 0)
            return;
        tagPos = randomPos[Random.Range(0,randomPos.Length)];
    }
    public override void Fire()
    {
        //相同套路
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            bulletObj bullet = obj.GetComponent<bulletObj>();
            bullet.SetFather(this);
        }           
    }
    public override void Dead()
    {
        base.Dead();
        //怪物死亡的时候加分
        GamePanel.Instance.AddScore(10);
    }
    public override void Wound(BaseTank other)
    {
        base.Wound(other);
        //设置显示时间
        showTime = 5;
    }
 
}
