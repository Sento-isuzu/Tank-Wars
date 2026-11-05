using UnityEngine;

public enum E_Style_OnOff
{
    On,
    Off,
}
public abstract class GuiControl : MonoBehaviour
{   
    //位置信息
    public ControlGuiPos guiPos;
    //显示内容
    public GUIContent content;
    //自拟定样式
    public GUIStyle Style;
    //样式开关
    public E_Style_OnOff styleOnOrOff = E_Style_OnOff.Off;

    //提供给外部执行的方法
    public void DrawGUI()
    {
        switch (styleOnOrOff)
        {
            case E_Style_OnOff.On:
                StyleOnDraw();
                break;
            case E_Style_OnOff.Off:
                StyleOffDraw(); 
                break;
        }
    }

    protected abstract void StyleOnDraw();
    protected abstract void StyleOffDraw();
}
