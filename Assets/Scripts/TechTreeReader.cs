using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TechTreeReader : MonoBehaviour
{
    private static TechTreeReader _instance;
    public static TechTreeReader Instance
    {
        get
        {
            return _instance;
        }
        set { }
    }
    private TechDef[] _techTree;
    private Dictionary<int, TechDef> _techs;
    private TechDef _techInspected;
    public int availablePoints = 0;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            SetUpTechTree();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void SetUpTechTree()
    {
        _techs = new Dictionary<int, TechDef>();
        LoadTechTree();
    }

    void Update() { }

    public void LoadTechTree()
    {
        string path = "Assets/TechTree/Data/TechTree.json";
        string dataAsJson;
        if (File.Exists(path))
        {
            dataAsJson = File.ReadAllText(path);
            TechTreeDef loadedData = JsonUtility.FromJson<TechTreeDef>(dataAsJson);
            _techTree = new TechDef[loadedData.techTree.Length];
            _techTree = loadedData.techTree;
            for (int i = 0; i < _techTree.Length; ++i)
            {
                _techs.Add(_techTree[i].id, _techTree[i]);
            }
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }

    public bool IsTechUnlocked(int id_tech)
    {
        if (_techs.TryGetValue(id_tech, out _techInspected))
        {
            return _techInspected.unlocked;
        }
        else
        {
            return false;
        }
    }

    public bool CanTechBeUnlocked(int id_tech)
    {
        bool canUnlock = true;
        if (_techs.TryGetValue(id_tech, out _techInspected))
        {
            if (_techInspected.cost <= availablePoints)
            {
                int[] dependencies = _techInspected.dependencies;
                for (int i = 0; i < dependencies.Length; ++i)
                {
                    if (_techs.TryGetValue(dependencies[i], out _techInspected))
                    {
                        if (!_techInspected.unlocked)
                        {
                            canUnlock = false;
                            break;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

        }
        else
        {
            return false;
        }
        return canUnlock;
    }

    public bool UnlockTech(int id_tech)
    {
        if (_techs.TryGetValue(id_tech, out _techInspected))
        {
            if (_techInspected.cost <= availablePoints)
            {
                availablePoints -= _techInspected.cost;
                _techInspected.unlocked = true;
                _techs.Remove(id_tech);
                _techs.Add(id_tech, _techInspected);

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
