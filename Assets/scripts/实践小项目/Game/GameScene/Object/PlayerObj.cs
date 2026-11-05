using UnityEngine;

public class PlayerObj : BaseTank
{
    //当前武器
    public WeaponObj nowWeapon;
    //武器父对象位置
    public Transform WeaponPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //移动逻辑
        this.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime);
        //旋转逻辑
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * roundSpeed * Time.deltaTime);
        //炮台旋转
        TankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headRoundSpeed * Time.deltaTime);
        //开火，按下左键
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    public override void Fire()
    {
        if(nowWeapon!=null) 
            nowWeapon.Fire();
    }
    public override void Dead()
    {
        Time.timeScale = 0;
        //这里如果死掉会导致摄像机没了
        //base.Dead();
        LosePanel.Instance.ShowMe();
    }
    public override void Wound(BaseTank other)
    {
        base.Wound(other);
        //更新主面板 血条
        GamePanel.Instance.UpdateHp(this.MaxHp,this.NowHp);

    }
    public void ChangWeapon(GameObject Weapon)
    {
        //如果自己身上有武器，先去除
        if (nowWeapon!=null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }
        //实例化武器
        GameObject weaponObj=Instantiate(Weapon,WeaponPos,false);
        //得到挂载的武器脚本
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        //设置武器拥有者
        nowWeapon.SetFather(this);
    }
}
