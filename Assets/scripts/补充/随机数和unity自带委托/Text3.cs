using UnityEngine;
using UnityEngine.Events;

public class Text3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //unity里的随机数直接调用,不用像c#中要new一个random，然后在.next()
        //int类型的规则跟c#里面的一样，都是左包含，右不包含
        int i=Random.Range(0,100);
        //但是float类型的就不一样，是左右都包含
        float a= Random.Range(1.1f, 99.9f);

        //委托相关的
        //c#自带的委托
        //无参
        System.Action ac = () => 
        {
            
        };
        //传参的
        System.Action<int> ac1 = (a) =>
        {

        };
        //func 无参
        System.Func<int> ac2 = () =>
        {
            return 1; //要有返回值
        };
        //func 有参
        System.Func<int,int> ac3 = (a) =>
        {
            return 1; //要有返回值
        };

        //unity带的委托(跟c#的action很像)
        //无参
        UnityAction action = () =>
        {

        };
        //有参
        UnityAction<int> action1 = (a) =>
        {

        };

        //委托的方法c#自带的或者unity自带的可以选择性用，但随机数就用unity的就行
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
