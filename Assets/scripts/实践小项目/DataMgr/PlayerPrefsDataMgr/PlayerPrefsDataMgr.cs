
using System;
using System.Collections;
using System.Reflection;
using UnityEngine;



/// <summary>
/// 统一管理数据的存储与读取
/// </summary>
public class PlayerPrefsDataMgr
{
    private static PlayerPrefsDataMgr instance=new PlayerPrefsDataMgr();

    public static PlayerPrefsDataMgr Instance
    {
        get { return instance; }
    }
    private PlayerPrefsDataMgr() 
    {
    
    }

    public void SaveData(object data,string keyName)
    {
        Type dataType =data.GetType();
        FieldInfo[] infos= dataType.GetFields();
        FieldInfo info;
        string saveKeyName = "";
        for (int i = 0; i < infos.Length; i++) 
        {
            info= infos[i];
            saveKeyName =keyName+"_"+dataType.Name+"_"+
                info.FieldType.Name+"_"+info.Name;

            SaveValue(info.GetValue(data), saveKeyName);
        }
        
    }
    //存储的方法
    private void SaveValue(object value,string keyName)
    {
        //判断传入的类型
        Type fieldType=value.GetType(); 
        if (fieldType==typeof(int))
        {
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if (fieldType == typeof(float))
        {
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if (fieldType == typeof(string))
        {
            PlayerPrefs.SetString(keyName, value.ToString());
        }
        else if (fieldType==typeof(bool))
        { 
            PlayerPrefs.SetInt(keyName, (bool)value?1:0);
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            IList list=value as IList;
            PlayerPrefs.SetInt(keyName,list.Count);
            int index=0;
            foreach (object item in list)
            {
                SaveValue(item,keyName+index);
                index++;
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            IDictionary dic=value as IDictionary;
            PlayerPrefs.SetInt(keyName,dic.Count);

            int index=0;
            foreach (object item in dic.Keys)
            {
                SaveValue(item,keyName+"_key_"+index);
                SaveValue(dic[item], keyName + "_value_" + index);
                index++;
            }
        }
        else 
        {
            SaveData(value,keyName);
        }
    }
    //这样写可以不用在外边在new一个对象传进来
    //省略一行代码
    public object LoadData(Type type, string keyName) 
    {
        object data=Activator.CreateInstance(type);
        FieldInfo[] infos = type.GetFields();

        string loadKeyName = "";
        FieldInfo info;
        for (int i = 0; i<infos.Length; i++) 
        {
            info = infos[i];
            loadKeyName = keyName + "_" + type.Name + "_" +
                info.FieldType.Name + "_" + info.Name;

            info.SetValue(data, LoadValue(info.FieldType, loadKeyName));
        }
        return data;
    }
    //读取的方法
    private object LoadValue(Type fieldType,string keyName)
    {
        if (fieldType == typeof(int))
        {
            return PlayerPrefs.GetInt(keyName,0);
        }
        else if (fieldType == typeof(float))
        {
            return PlayerPrefs.GetFloat(keyName,0);
        }
        else if (fieldType == typeof(string))
        {
            return PlayerPrefs.GetString(keyName,"未命名");
        }
        else if (fieldType == typeof(bool))
        {
            return PlayerPrefs.GetInt(keyName) == 1 ? true : false;
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            int count=PlayerPrefs.GetInt(keyName,0);
            IList list = Activator.CreateInstance(fieldType) as IList;
            for (int i=0; i<count; i++)
            {
                list.Add(LoadValue(fieldType.GetGenericArguments()[0],keyName+i));
            }
            return list;

        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            int count= PlayerPrefs.GetInt(keyName, 0);
            IDictionary dic=Activator.CreateInstance(fieldType) as IDictionary;
            //这里我说一下，方便下次理解
            //这里额度kvType是得到你用字典或者list<>，里面存储的类型(<>里面的类型)
            Type[] kvType=fieldType.GetGenericArguments();
            for (int i = 0; i < count; i++)
            {
                dic.Add(LoadValue(kvType[0],keyName + "_key_" +i), 
                    LoadValue(kvType[1], keyName + "_value_" + i));
            }
            return dic;
        }
        else
        {
            return LoadData(fieldType,keyName);
        }
    }
}
