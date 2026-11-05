using UnityEngine;
using UnityEngine.Events;

public class TextFieldGUI : GuiControl
{
    public event UnityAction<string> TextChanged;
    private string LastString="";
    protected override void StyleOffDraw()
    {
        content.text=GUI.TextField(guiPos.Pos,content.text);
        if (LastString!=content.text)
        {
            TextChanged?.Invoke(content.text);
            LastString = content.text;
        }
    }

    protected override void StyleOnDraw()
    {
        content.text = GUI.TextField(guiPos.Pos, content.text,Style);
        if (LastString != content.text)
        {
            TextChanged?.Invoke(content.text);
            LastString = content.text;
        }
    }
}
