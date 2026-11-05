using UnityEngine;
using UnityEngine.Events;

public class ButtonGUI : GuiControl
{
    public event UnityAction Onclick;
    protected override void StyleOffDraw()
    {
        if (GUI.Button(guiPos.Pos,content))
        {
            Onclick?.Invoke();
        }
    }

    protected override void StyleOnDraw()
    {
        if (GUI.Button(guiPos.Pos, content,Style))
        {
            Onclick?.Invoke();
        }
    }
}
