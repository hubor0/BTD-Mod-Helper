﻿using System;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extension methods for keycodes
/// </summary>
internal static class KeyCodeExt
{
    internal static string GetPath(this KeyCode keyCode)
    {
        var key = keyCode.ToString();
        if (key.Length == 1)
        {
            key = key.ToLower();
        }

        return $"<Keyboard>/{key}";
    }

    internal static KeyCode GetKeyCode(this string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return KeyCode.None;

        var key = path.Split('/')[^1];
        if (int.TryParse(key, out _))
        {
            key = "Alpha" + key;
        }
        return Enum.TryParse(key, true, out KeyCode keyCode) ? keyCode : default;
    }
}