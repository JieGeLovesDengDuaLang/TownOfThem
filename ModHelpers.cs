﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TownOfThem.Utilities;
using UnityEngine;

namespace TownOfThem.ModHelpers
{
    class ModHelpers
    {
        public static Sprite LoadSprite(string path, float pixelsPerUnit = 1f)
        {
            Sprite sprite = null;
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            var texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            using MemoryStream ms = new();
            stream.CopyTo(ms);
            ImageConversion.LoadImage(texture, ms.ToArray());
            sprite = Sprite.Create(texture, new(0, 0, texture.width, texture.height), new(0.5f, 0.5f), pixelsPerUnit);
            return sprite;
        }
        public static string cs(Color c, string s)
        {
            return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", Convert.ToByte(c.r), Convert.ToByte(c.g), Convert.ToByte(c.b), Convert.ToByte(c.a), s);
        }
    }
}