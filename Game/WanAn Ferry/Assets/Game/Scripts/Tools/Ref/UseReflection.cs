using System;
// 自定义特性：用于标记要绑定的物体名称
[AttributeUsage(AttributeTargets.Field)] // 仅用于字段
public class UseReflection : Attribute
{
    public string ObjectName { get; }
    // 特性构造函数：接收物体名称
    public UseReflection(string objectName)
    {
        ObjectName = objectName;
    }
}
