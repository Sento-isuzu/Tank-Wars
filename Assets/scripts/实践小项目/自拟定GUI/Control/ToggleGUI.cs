using UnityEngine;
using UnityEngine.Events;

public class ToggleGUI : GuiControl
{
    public bool isSel;
    public event UnityAction<bool> changeValue;
    private bool lastSel;
    protected override void StyleOffDraw()
    {
        isSel = GUI.Toggle(guiPos.Pos,isSel,content);
        if (lastSel!=isSel)
        {
            changeValue?.Invoke(isSel);
            lastSel = isSel;
        }
    }

    protected override void StyleOnDraw()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, content,Style);
        if (lastSel != isSel)
        {
            changeValue?.Invoke(isSel);
            lastSel = isSel;
        }
    }
}
