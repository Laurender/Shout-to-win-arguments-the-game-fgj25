using UnityEngine;
using System.IO;
using System.Data;
using NUnit.Framework;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

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

    void Start()
    {
        characterBubbles = new Dictionary<string, Bubbles>
        {
            { "test", GetBubbles("bubbles.json") },
            { "rasisti", GetBubbles("rasisti-bubbles.json") },
            { "pissis", GetBubbles("pissis-bubbles.json") },
            { "doomer", GetBubbles("doomer-bubbles.json") },
            { "boomer", GetBubbles("boomer-bubbles.json") },
            { "kristitty", GetBubbles("kristitty-bubbles.json") },
            { "jonnet", GetBubbles("jonnet-bubbles.json") },
            { "vihervassarit", GetBubbles("vihervassarit-bubbles.json") },
        };

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

        Debug.Log("TESTING");
        Debug.Log(getNextBubble("test", 1).phrase);
        Debug.Log(getNextBubble("test", 1).phrase);

        Debug.Log(getNextBubble("test", 2).phrase);
        Debug.Log(getNextBubble("test", 2).phrase);
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
}
