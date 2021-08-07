using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;
    private static Managers Instance { get { Init(); return s_instance; } }
    private InputManagers _input_managers = new InputManagers();
    public static InputManagers Input { get { return Instance._input_managers; } }
    private ResourceManagers ResourceManagers = new ResourceManagers();
    public static ResourceManagers Resource { get { return Instance.ResourceManagers; } }
    private UIManagers UIManagers = new UIManagers();
    public static UIManagers UI { get { return Instance.UIManagers; } }
    // Start is called before the first frame update
    private static void Init()
    {
        if (s_instance == null)
        {
            GameObject Go = GameObject.Find("@Managers");
            if (Go == null)
            {
                Go = new GameObject("@Managers");
                Go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(Go);
            s_instance = Go.GetComponent<Managers>();
        }
    }
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _input_managers.OnUpdate();
    }
}
