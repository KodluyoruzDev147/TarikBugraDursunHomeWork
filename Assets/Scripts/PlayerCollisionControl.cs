using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollisionControl : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject instantiatedObject;
    [SerializeField] private TextMeshProUGUI tmpChildren;
    
    private Vector3 newPosition;
    
    private int InstantiateCount;
    private int destroyCount;
    private int children = 1;

    public bool isFinished;
    public bool isFail;
    #endregion

    #region Singleton
    public static PlayerCollisionControl instance;

    private void InitSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    private void Awake()
    {
        InitSingleton();
    }

    void Start()
    {
        InstantiateCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        tmpChildren.text = children.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Portal>().type == Portaltype.add5)
        {
            if (children<8)
            {
                InstantiateCount = 5;
                InstantiateClones();
            }
            else 
            {
                children += 5;
            }
        }
        if (other.gameObject.GetComponent<Portal>().type == Portaltype.remove2)
        {
            destroyCount = 2;
            if (children>2)
            {
                DestroyClones();
            }
            else 
            {
                isFail = true;
                isFinished = true;
            }
        }
        if (other.gameObject.GetComponent<Portal>().type == Portaltype.add1)
        {
            InstantiateCount = 1;
            InstantiateClones();
        }
        if (other.gameObject.GetComponent<Portal>().type==Portaltype.finish)
        {
            StartCoroutine(Finish());
        }
    }

    private void InstantiateClones()
    {
        newPosition = transform.position;
        for (int i = 0; i < InstantiateCount; i++)
        {
            newPosition = newPosition + Vector3.back;
            Instantiate(instantiatedObject, newPosition, Quaternion.identity, this.transform);
            children++;

        }
    }

    private void DestroyClones()
    {
        for (int i = 0; i < destroyCount; i++)
        {
            Destroy(transform.GetChild(children + 1).gameObject);
            children--;
        }
    }

    private IEnumerator Finish() 
    {
        Debug.Log("Finish");
        yield return new WaitForSeconds(.5f);
        isFinished = true;
    }
}
