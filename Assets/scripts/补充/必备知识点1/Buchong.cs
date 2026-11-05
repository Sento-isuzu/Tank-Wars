using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
class Father
{

}
class Son:Father
{

}
public class Buchong : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        //判断一个类型的对象是否可以让另一个类型为自己分配空间
        Type fatherType=typeof(Father);
        Type sonType=typeof(Son);

        if (fatherType.IsAssignableFrom(sonType))
        {
            print("可以装");
            Father f=Activator.CreateInstance(sonType) as Father;
            print(f);
        }
        else
        {
            print("不能装");
        }

        //通过反射获取泛型类型
        List<int> list = new List<int>();
        Type listType=list.GetType();

        Type[] types=listType.GetGenericArguments();
        print(types[0]);

        Dictionary<string, float> dic = new Dictionary<string, float>();
        Type dicType=dic.GetType();
        types=dicType.GetGenericArguments();
        print(types[0]);
        print(types[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
