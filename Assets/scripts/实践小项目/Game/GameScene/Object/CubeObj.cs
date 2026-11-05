using UnityEngine;

public class CubeObj : MonoBehaviour
{
    //随机奖励数组
    public GameObject[] rewardRandom;
    //特效
    public GameObject CubeEff;
    private void OnTriggerEnter(Collider other)
    {
        int index=Random.Range(0,100);
        if (index<65)
        {
            //子弹销毁已经写了，把箱子标签改为Cube即可
            //随机奖励
            index=Random.Range(0,rewardRandom.Length);
            //创建奖励
            Instantiate(rewardRandom[index],this.transform.position,this.transform.rotation);
        }
        //特效创建
        GameObject eff = Instantiate(CubeEff, this.transform.position, this.transform.rotation);
        //得到音效
        AudioSource source=eff.GetComponent<AudioSource>();
        source.volume = GameDataMgr.Instance.musicData.bkSound;
        source.mute = !GameDataMgr.Instance.musicData.isOpenSound;

        Destroy(this.gameObject);
    }

}
