using UnityEngine;

/// <summary>
/// 对其方式枚举
/// </summary>
public enum E_Alignment_Type
{
    Up,
    Down,
    Left,
    Right,
    Center,
    Left_Up,
    Left_Down,
    Right_Up,
    Right_Down,
}
[System.Serializable]
public class ControlGuiPos
{
    private Rect rPos=new Rect(0,0,100,100);

    //屏幕九宫格对齐方式
    public E_Alignment_Type screen_Aligment_Type=E_Alignment_Type.Center;
    //控件中心对齐方式
    public E_Alignment_Type control_Aligment_Type= E_Alignment_Type.Center;
    //偏移位置
    public Vector2 pos;
    //宽高
    public float width = 100;
    public float height = 50;

    private Vector2 centerPos;

    //中心的偏移位置的计算函数
    private void CalcCenterPos()
    {
        switch (control_Aligment_Type)
        {
            case E_Alignment_Type.Up:
                centerPos.x = -width / 2;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Down:
                centerPos.x = -width / 2;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.Left:
                centerPos.x = 0;
                centerPos.y = -height/2;
                break;
            case E_Alignment_Type.Right:
                centerPos.x = -width;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Center:
                centerPos.x = -width/2;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Left_Up:
                centerPos.x = 0;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Left_Down:
                centerPos.x = 0;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.Right_Up:
                centerPos.x = -width;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Right_Down:
                centerPos.x = -width;
                centerPos.y = -height;
                break;
        }
    }

    private void CalcPos()
    {
        switch (screen_Aligment_Type)
        {
            case E_Alignment_Type.Up:
                rPos.x =Screen.width/2+centerPos.x+pos.x;
                rPos.y = centerPos.y+pos.y;
                break;
            case E_Alignment_Type.Down:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = Screen.height+centerPos.y - pos.y;
                break;
            case E_Alignment_Type.Left:
                rPos.x = centerPos.x + pos.x;
                rPos.y = Screen.height/2+centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Right:
                rPos.x = Screen.width + centerPos.x - pos.x;
                rPos.y = Screen.height/2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Center:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = Screen.height / 2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Left_Up:
                rPos.x = centerPos.x + pos.x;
                rPos.y = centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Left_Down:
                rPos.x = centerPos.x + pos.x;
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
            case E_Alignment_Type.Right_Up:
                rPos.x = Screen.width+ centerPos.x - pos.x;
                rPos.y = centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Right_Down:
                rPos.x = Screen.width + centerPos.x - pos.x;
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
        }
    }
    public Rect Pos
    {
        get 
        {
            //计算(中心的偏移位置)
            CalcCenterPos();
            //计算(位置)
            CalcPos();
            //赋值宽高
            rPos.width = width;
            rPos.height = height;
            return rPos;
        }
    }
}
