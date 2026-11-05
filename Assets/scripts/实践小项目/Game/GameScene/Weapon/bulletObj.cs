using UnityEngine;

public class bulletObj : MonoBehaviour
{
    //子弹速度
    public float moveSpeed=50;
    //父对象
    public BaseTank fatherObj;
    //子弹的特效
    public GameObject effObj;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //比较tag
        if (other.CompareTag("Cube")
            ||fatherObj!=null && fatherObj.CompareTag("Player")&&other.CompareTag("Monster")
            || fatherObj != null && fatherObj.CompareTag("Monster") && other.CompareTag("Player"))
        {

            //判断是否受伤
            BaseTank obj=other.GetComponent<BaseTank>();
            if (obj!=null)
            {
                obj.Wound(fatherObj);
            }
            if (effObj!=null)
            {
                //创建爆炸特效
                GameObject eff = Instantiate(effObj,this.transform.position,this.transform.rotation);
                //得到音效脚本
                AudioSource audioSource = eff.GetComponent<AudioSource>();
                //音效大小
                audioSource.volume = GameDataMgr.Instance.musicData.bkSound;
                //音效开关
                audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;

                Destroy(eff,1);
            }
            
            Destroy(this.gameObject);
        }        
    }
    public void SetFather(BaseTank father)
    {
        fatherObj = father;
    }
}
