using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    //用于实例化的子弹对象
    public GameObject bullet;
    //外部决定到底有几个发射位置
    public Transform[] shootPos;
    //得到自己的父对象是谁，方便伤害计算
    public BaseTank fatherTank;

    public void SetFather(BaseTank father)
    {
        fatherTank = father;
    }
    public void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            //创建子弹预设体
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            //得到脚本
            bulletObj bullet1 = obj.GetComponent<bulletObj>();
            //把自己的basetank对象传给子弹
            bullet1.SetFather(fatherTank);
        }
    }
}
