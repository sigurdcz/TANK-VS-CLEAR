using UnityEngine;

public class SaveService
{
    public void SaveVector2(string key, Vector2 vector)
    {
        PlayerPrefs.SetFloat(key + "_x", vector.x);
        PlayerPrefs.SetFloat(key + "_y", vector.y);
        PlayerPrefs.Save();
    }

    public Vector2 LoadVector2(string key, Vector2 defaultValue)
    {
        float x = PlayerPrefs.GetFloat(key + "_x", defaultValue.x);
        float y = PlayerPrefs.GetFloat(key + "_y", defaultValue.y);
        return new Vector2(x, y);
    }
}
