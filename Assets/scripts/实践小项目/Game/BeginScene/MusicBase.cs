using UnityEngine;

public class MusicBase : MonoBehaviour
{
    private static MusicBase instance;
    public static MusicBase Instance => instance;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        audioSource = this.GetComponent<AudioSource>();
        //初始化，把开关，音量大小根据数据来进行设置
        ChangeOpen(GameDataMgr.Instance.musicData.isOpenMusic);
        ChangeValue(GameDataMgr.Instance.musicData.bkMusic);
        
    }
    public void ChangeValue(float value)
    {
        audioSource.volume = value;
    }
    public void ChangeOpen(bool isOpen)
    {
        //如果开启 就是静音,mute是静音的意思，也就是说mute为true时，就是静音
        //反之
        audioSource.mute = !isOpen;
    }
}
