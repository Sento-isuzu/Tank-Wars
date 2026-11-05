using UnityEngine;

public enum E_Pro
{
    //不同的四种属性
    Atk,
    Def,
    MaxHP,
    HP
}
public class ProReward : MonoBehaviour
{
    //属性
    public E_Pro Sx;
    //可改增加
    public int changeValue=5;
    public GameObject RewardEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //得到脚本
            PlayerObj player=other.GetComponent<PlayerObj>();
            switch (Sx)
            {
                case E_Pro.Atk:
                    player.atk += changeValue;
                    break;
                case E_Pro.Def:
                    player.def += changeValue;
                    break;
                case E_Pro.MaxHP:
                    player.MaxHp += 10;
                    player.NowHp += 10;
                    //更新血条
                    GamePanel.Instance.UpdateHp(player.MaxHp,player.NowHp);
                    break;
                case E_Pro.HP:
                    player.NowHp += 20;
                    //不能超过上线
                    if (player.NowHp>player.MaxHp)
                        player.NowHp = player.MaxHp;
                    GamePanel.Instance.UpdateHp(player.MaxHp, player.NowHp);
                    break;
            }
            //奖励特效
            GameObject eff = Instantiate(RewardEff, this.transform.position, this.transform.rotation);
            //获得音效
            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.bkSound;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            //奖励消失
            Destroy(this.gameObject);
        }
    }
}
