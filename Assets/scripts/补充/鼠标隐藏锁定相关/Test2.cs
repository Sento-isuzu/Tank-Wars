using UnityEngine;

public class Test2 : MonoBehaviour
{
    Texture2D tex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //隐藏鼠标
        Cursor.visible = false;


        //鼠标锁定
        //None 就是 不锁定

        //Locked 锁定 鼠标会被限制在 屏幕中心点
        //不仅会被锁定 还会被隐藏，只有按esc才能退出锁定

        //Confined 限制在窗口范围内
        Cursor.lockState = CursorLockMode.None;

        //设置鼠标光标图片
        //参数一:光标图片
        //参数二:偏移位置 相对图片左上角
        //参数三:平台支持的光标模式(硬件或软件)
        Cursor.SetCursor(tex,Vector2.zero,CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
