using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string SavePath =
        Path.Combine(Application.persistentDataPath, "save.json");

    //Save
    public static void Save(SaveData data)
    {
        var json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);
        Debug.Log($"[SaveSystem] Saved to: {SavePath}\n{json}");
    }

    //Load
    public static bool TryLoad(out SaveData data)
    {
        if (File.Exists(SavePath))
        {
            var json = File.ReadAllText(SavePath);
            data = JsonUtility.FromJson<SaveData>(json);
            return true;
        }
        data = null;
        return false;
    }

    //DeleteSave
    public static void Delete()
    {
        if (File.Exists(SavePath))
        {
            File.Delete(SavePath);
            Debug.Log("[SaveSystem] Save deleted");
        }
    }

    public static string GetPath() => SavePath;
}
