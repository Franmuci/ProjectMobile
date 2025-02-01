using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SaveManager : MonoBehaviour
{

    string saveFile;

    public SavePoints gameData;

    private List<LeaderBoard> leaderboard;

    public static SaveManager Instance;


    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Update the path once the persistent path exists.
        saveFile = Application.persistentDataPath + "/leaderboard.json";

        leaderboard = gameData.leaderBoard;
    }

    public void ReadFile()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            print(saveFile);
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);
            print("Read Data: "+fileContents);
            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            var leaderboard = JsonUtility.FromJson<List<LeaderBoard>>(fileContents);
            print(leaderboard);
            
        }
    }

    public void WriteFile()
    {
        // Serialize the object into JSON and save string.
        string jsonString = "";

        foreach (var data in gameData.leaderBoard)
        {
            jsonString += JsonUtility.ToJson(data);
        }
        

        print("Write Data: "+jsonString);
        print("Write Data: "+gameData.leaderBoard.Count);
        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }
    
    public void WriteFileOverwrite()
    {
        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(gameData);
        print("Write Data: "+jsonString);
        print("Write Data: "+gameData.leaderBoard.Count);
        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }
    
    public void ReadFileOverwrite()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            print(saveFile);
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);
            print("Read Data: "+fileContents);
            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            JsonUtility.FromJsonOverwrite(fileContents, gameData);
            print(leaderboard);
            
        }
    }
}
