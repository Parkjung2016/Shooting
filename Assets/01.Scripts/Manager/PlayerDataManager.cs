using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;

    [HideInInspector]
    public PlayerData PlayerData = new PlayerData();

    private string savePath;

    [SerializeField]
    private Texture2D _cursorTexture2D;
    public int MapIndex;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "PlayerData.json");
        PlayerDataManager[] playerDataManagers = FindObjectsOfType<PlayerDataManager>();
        if(playerDataManagers.Length > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Cursor.SetCursor(_cursorTexture2D, Vector2.zero,CursorMode.Auto);
    }
    public void  SaveData()
    {
        string Json = JsonUtility.ToJson(PlayerData,true);
        File.WriteAllText(savePath, Json);
    }
    public bool LoadData()
    {
        if(File.Exists(savePath))
        {
        PlayerData  = JsonUtility.FromJson<PlayerData>( File.ReadAllText(savePath));
        }
        return File.Exists(savePath);

    }
    private void OnApplicationQuit()
    {
        if(SceneManager.GetActiveScene().name!="Title" && PlayerData. PlayerName != "")
        SaveData();
    }
}
