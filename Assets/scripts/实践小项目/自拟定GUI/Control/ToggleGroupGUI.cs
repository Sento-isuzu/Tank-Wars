using UnityEngine;

public class ToggleGroupGUI : MonoBehaviour
{
    //得到传入的toggle，做统一的管理
    public ToggleGUI[] toggles;

    private ToggleGUI frontToggle;
    private void Start()
    {
        if (toggles.Length == 0) return;
        for (int i = 0; i < toggles.Length; i++) 
        {
            ToggleGUI toggle = toggles[i];
            toggle.changeValue += (value) =>
            {
                //判断是否为true而让其它置空
                if (value) 
                {
                    frontToggle=toggle;
                    for (int j = 0; j < toggles.Length; j++) 
                    {
                        //闭包
                        if (toggles[j] != toggle)
                        {
                            toggles[j].isSel = false;
                        }
                    }
                }
                else if (frontToggle==toggle)
                {
                    toggle.isSel = true;
                }
            };
        }
    }
}
