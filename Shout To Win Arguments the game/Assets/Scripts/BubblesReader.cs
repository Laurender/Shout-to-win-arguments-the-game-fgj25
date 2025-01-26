using UnityEngine;
using System.IO;
using System.Data;
using NUnit.Framework;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine.Networking;

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

    public Bubbles testBubbles;

    public Dictionary<string, Bubbles> characterBubbles;

    public Dictionary<string, int> usedBubbles;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        characterBubbles = new Dictionary<string, Bubbles>();

        StartCoroutine(LoadJsonFromStreamingAssets("test", "bubbles.json"));
        StartCoroutine(LoadJsonFromStreamingAssets("rasisti", "rasisti-bubbles.json"));
        StartCoroutine(LoadJsonFromStreamingAssets("pissis", "pissis-bubbles.json"));
        StartCoroutine(LoadJsonFromStreamingAssets("doomer", "doomer-bubbles.json"));
        StartCoroutine(LoadJsonFromStreamingAssets("boomer", "boomer-bubbles.json"));
        StartCoroutine(LoadJsonFromStreamingAssets("kristitty", "kristitty-bubbles.json"));
        StartCoroutine(LoadJsonFromStreamingAssets("jonnet", "jonnet-bubbles.json"));
        StartCoroutine(LoadJsonFromStreamingAssets("vihervassarit", "vihervassarit-bubbles.json"));

        usedBubbles = new Dictionary<string, int>
        {
            { "test1", 0 },
            { "test2", 0 },
            { "test3", 0 },
            { "rasisti1", 0 },
            { "rasisti2", 0 },
            { "rasisti3", 0 },
            { "pissis1", 0  },
            { "pissis2", 0  },
            { "pissis3", 0  },
            { "doomer1", 0  },
            { "doomer2", 0  },
            { "doomer3", 0  },
            { "boomer1", 0  },
            { "boomer2", 0  },
            { "boomer3", 0  },
            { "kristitty1", 0  },
            { "kristitty2", 0  },
            { "kristitty3", 0  },
            { "jonnet1", 0  },
            { "jonnet2", 0  },
            { "jonnet3", 0  },
            { "vihervassarit1", 0  },
            { "vihervassarit2", 0  },
            { "vihervassarit3", 0  },
        };
    }

    public Bubble getNextBubble(string character, int level)
    {
        Bubble bubble;
        switch (level)
        {
            case 1:
                bubble = characterBubbles[character].level1[usedBubbles[character + level]];
                break;
            case 2:
                bubble = characterBubbles[character].level2[usedBubbles[character + level]];
                break;
            case 3:
                bubble = characterBubbles[character].level3[usedBubbles[character + level]];
                break;
            default:
                return null;
        }

        usedBubbles[character + level] ++;
        return bubble;        
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

    IEnumerator LoadJsonFromStreamingAssets(string name, string filename)
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, filename);

        UnityWebRequest request = UnityWebRequest.Get(path);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string json = request.downloadHandler.text;
            Debug.Log(json);

            Bubbles parsedBubbles = JsonUtility.FromJson<Bubbles>(json);

            characterBubbles.Add(name, parsedBubbles);
        }
    }
}
