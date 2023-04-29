using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController Instance;

    [SerializeReference]
    [SerializeField] private List<BaseController> initialControllersList;
    
    public List<BaseController> ControllersList => initialControllersList;

    private void Awake()
    {
        SingletonCreateIfNotExist();
        
    }

    protected void SingletonCreateIfNotExist()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    
    protected void CreateInitialControllers()
    {
        foreach (var initCtr in initialControllersList)
        {
            Instantiate(initCtr, transform);
        }
    }
}
