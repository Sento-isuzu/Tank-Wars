using UnityEngine;

[ExecuteAlways]
public class GuiControlRoot : MonoBehaviour
{
    private GuiControl[] guiControls;
    void Start()
    {
        guiControls = this.gameObject.GetComponentsInChildren<GuiControl>();
    }
    private void OnGUI()
    {
        //if (!Application.isPlaying)
        //{
            guiControls = this.gameObject.GetComponentsInChildren<GuiControl>();
        //}
        
        for (int i = 0; i < guiControls.Length; i++) 
        {
            guiControls[i].DrawGUI();
        }
    }
}
