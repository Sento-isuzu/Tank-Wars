using UnityEngine;
using UnityEngine.SceneManagement;

public class Test1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //记住SceneManager.LoadScene()就行，场景切换
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Test1");
        }
        //退出游戏,记住Application.Quit()就行
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
