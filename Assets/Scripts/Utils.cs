using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static string LoadResourceTextfile(string path)
    {

        string filePath = path.Replace(".json", "");

        TextAsset targetFile = Resources.Load<TextAsset>(filePath);

        return targetFile.text;
    }
}
