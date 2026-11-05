using UnityEngine;

public class TextureGUI : GuiControl
{
    public ScaleMode scaleMode;
    public bool alpha=true;
    protected override void StyleOffDraw()
    {
        GUI.DrawTexture(guiPos.Pos,content.image,scaleMode,alpha);
    }

    protected override void StyleOnDraw()
    {
        GUI.DrawTexture(guiPos.Pos, content.image, scaleMode, alpha);
    }
}
