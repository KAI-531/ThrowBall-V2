using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class SaveDataManager : MonoBehaviour
{
    private SaveData data = new SaveData();

    string filepath;
    string filename = "SaveData.json";

    LoadDataManager loadmg;

    void Awake()
    {
        // パス名取得
        // filepath = Application.dataPath + "/" + filename;
        filepath = Path.Combine(Application.dataPath, filename);
        Debug.Log("SavePath: " + filepath);

        // ファイルがないとき、ファイル作成
        if (File.Exists(filepath) == false)
        {
            Debug.Log("SaveData Not exits");
            Save(data);
        }

        // ファイルを読み込んでdataに格納
        data = Load(filepath);

        loadmg = GetComponent<LoadDataManager>();

        loadmg.SetVarManager(data);
    }

    void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data);                 // jsonとして変換
        StreamWriter wr = new StreamWriter(filepath, false);    // ファイル書き込み指定
        wr.WriteLine(json);                                     // json変換した情報を書き込み
        wr.Close();                                             // ファイル閉じる
    }

    // jsonファイル読み込み
    SaveData Load(string path)
    {
        StreamReader rd = new StreamReader(path);               // ファイル読み込み指定
        string json = rd.ReadToEnd();                           // ファイル内容全て読み込む
        rd.Close();                                             // ファイル閉じる

        return JsonUtility.FromJson<SaveData>(json);            // jsonファイルを型に戻して返す
    }

    //-------------------------------------------------------------------
    // ゲーム終了時に保存
    void OnDestroy()
    {
        data = loadmg.SaveVarManager(data);
        Save(data);
    }
}
