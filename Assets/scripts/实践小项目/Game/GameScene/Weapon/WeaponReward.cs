using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    public GameObject[] WeaponArr;
    //奖励特效
    public GameObject RewardEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //随机数，用来随机武器
            int index = Random.Range(0, WeaponArr.Length);
            //得到玩家身上的脚本
            PlayerObj player = other.GetComponent<PlayerObj>();
            player.ChangWeapon(WeaponArr[index]);
            //奖励特效
            GameObject eff=Instantiate(RewardEff,this.transform.position,this.transform.rotation);
            //获得音效
            AudioSource audioSource=eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.bkSound;
            audioSource.mute=!GameDataMgr.Instance.musicData.isOpenSound;
            
            //奖励消失
            Destroy(this.gameObject);
        }
    }
}
