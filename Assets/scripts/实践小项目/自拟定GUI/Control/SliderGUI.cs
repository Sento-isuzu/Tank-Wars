using UnityEngine;
using UnityEngine.Events;

public enum Slider_Type
{
    Horizontal,
    Vertical
}
public class SliderGUI : GuiControl
{
    public float minValue=0;
    public float maxValue=1;
    public float nowValue = 0;

    public GUIStyle tumbStyle;

    public Slider_Type sliderType = Slider_Type.Horizontal;

    public event UnityAction<float> OnValueChanged;

    private float LastValue=0;

    protected override void StyleOffDraw()
    {
        switch (sliderType)
        {
            case Slider_Type.Horizontal:
                nowValue=GUI.HorizontalSlider(guiPos.Pos, nowValue, minValue, maxValue);
                break;
            case Slider_Type.Vertical:
                nowValue = GUI.VerticalSlider(guiPos.Pos, nowValue, minValue, maxValue);
                break;
        }
        if (LastValue != nowValue)
        {
            OnValueChanged?.Invoke(nowValue);
            LastValue = nowValue;
        }
        
    }

    protected override void StyleOnDraw()
    {
        switch (sliderType)
        {
            case Slider_Type.Horizontal:
                nowValue = GUI.HorizontalSlider(guiPos.Pos, nowValue, minValue, maxValue,Style,tumbStyle);
                break;
            case Slider_Type.Vertical:
                nowValue = GUI.VerticalSlider(guiPos.Pos, nowValue, minValue, maxValue,Style, tumbStyle);
                break;
        }
        if (LastValue != nowValue)
        {
            OnValueChanged?.Invoke(nowValue);
            LastValue = nowValue;
        }
    }
}
