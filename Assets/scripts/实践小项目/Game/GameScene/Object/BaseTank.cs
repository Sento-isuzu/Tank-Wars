using UnityEngine;

public abstract class BaseTank : MonoBehaviour
{
    //所有坦克包括玩家都有的东西
    public int atk;
    public int def;
    public int MaxHp;
    public int NowHp;
    //炮台
    public Transform TankHead;
    //旋转基类
    public float moveSpeed = 10;
    public float roundSpeed = 100;
    public float headRoundSpeed = 100;
    //死亡特效
    public GameObject deadEff;
    /// <summary>
    /// 开火抽象方法，子类重写
    /// </summary>
    public abstract void Fire();
    /// <summary>
    /// 被别人攻击，受伤
    /// </summary>
    /// <param name="other"></param>
    public virtual void Wound(BaseTank other)
    {
        int damage = other.atk - this.def;
        //如果攻击力小于自身防御力，即完全防御
        if (damage <= 0) return;
        this.NowHp-=damage;
        //判断如果血量<=0，那就死亡
        if (this.NowHp<=0)
        {
            this.NowHp = 0;
           this.Dead();
        }
    }
    /// <summary>
    /// 死亡行为
    /// </summary>
    public virtual void Dead()
    {
        //移除
        Destroy(this.gameObject);
        if (deadEff != null) 
        {
            //创建特效
            GameObject effObj = Instantiate(deadEff,this.transform.position,this.transform.rotation);
            //得到身上的音效脚本
            AudioSource audioSource = effObj.GetComponent<AudioSource>();
            //音效大小
            audioSource.volume = GameDataMgr.Instance.musicData.bkSound;
            //是否开启音效
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            //默认勾选play on wake
            audioSource.Play();
        }
    }
}
