using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Player;
    public float H = 10;
    private Vector3 pos;
    private void LateUpdate()
    {
        //改变摄像机x,z轴
        pos.x = Player.position.x;
        pos.z = Player.position.z;
        //外边可以调整高度
        pos.y = H;
        //跟随移动
        this.transform.position = pos;
    }
}
