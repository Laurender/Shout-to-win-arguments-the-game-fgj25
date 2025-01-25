using UnityEngine;
using System.IO;

[System.Serializable]
public class Bubbles
{
    public Bubble[] level1;
    public Bubble[] level2;
    public Bubble[] level3;
}

[System.Serializable]
public class Bubble
{
    public string phrase;
    public string correct;
    public Answers answers;
}

[System.Serializable]
public class Answers
{
    public string like;
    public string dislike;
    public string hate;
}

public class BubblesReader : MonoBehaviour
{
    public Bubbles bubbles;

    void Start()
    {
        Bubbles bubbles = GetBubbles("bubbles.json");

        Debug.Log(bubbles);
    }

    public Bubbles GetBubbles(string filename)
    {
        string path = Application.dataPath + "/" + filename;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            bubbles = JsonUtility.FromJson<Bubbles>(json);

            Debug.Log(bubbles);

            return bubbles;
        }
        else
        {
            Debug.LogError("Cannot find file!");

            return null;
        }
    }
}
