using UnityEngine;

public class LabelGUI : GuiControl
{
    protected override void StyleOffDraw()
    {
        GUI.Label(guiPos.Pos,content);
    }

    protected override void StyleOnDraw()
    {
        GUI.Label(guiPos.Pos, content,Style);
    }
}
