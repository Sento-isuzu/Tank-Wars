using UnityEngine;

public class Break : MonoBehaviour
{
    public int Time=2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,Time);
    }

}
