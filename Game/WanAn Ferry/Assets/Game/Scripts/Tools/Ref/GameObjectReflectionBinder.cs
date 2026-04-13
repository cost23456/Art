using System.Reflection;
using UnityEngine;

/// <summary>
/// 反射绑定 Unity 物体/组件的工具类（支持直接绑定自定义组件）
/// </summary>
public static class GameObjectReflectionBinder
{
    public static void BindGameObjects(MonoBehaviour mono)
    {
        if (mono == null)
        {
            Debug.LogError("目标MonoBehaviour不能为空");
            return;
        }

        // 获取所有字段
        FieldInfo[] fields = mono.GetType().GetFields(
            BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            UseReflection attr = field.GetCustomAttribute<UseReflection>();
            if (attr == null) continue;

            string path = attr.ObjectName;
            Object targetObj = null;

            // -----------------------
            // 核心逻辑：自动判断类型
            // -----------------------
            if (field.FieldType == typeof(GameObject))
            {
                // 绑定 GameObject
                targetObj = mono.transform.Find(path)?.gameObject;
            }
            else
            {
                // 绑定 任意组件（包括你的自定义脚本）
                targetObj = mono.transform.Find(path)?.GetComponent(field.FieldType);
            }

            if (targetObj != null)
            {
                field.SetValue(mono, targetObj);
                Debug.Log($" 绑定成功：{mono.name} → {field.Name}");
            }
            else
            {
                Debug.LogError($" 绑定失败：{path} 找不到或缺少组件 {field.FieldType.Name}");
            }
        }
    }
}