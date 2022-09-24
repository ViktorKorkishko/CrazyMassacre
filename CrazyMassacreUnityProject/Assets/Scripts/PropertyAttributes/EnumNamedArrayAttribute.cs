using System;
using UnityEngine;

public class EnumNamedArrayAttribute : PropertyAttribute
{
    public string[] names;

    public EnumNamedArrayAttribute(Type enumType)
    {
        this.names = Enum.GetNames(enumType);
    }
}