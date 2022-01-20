using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : Singleton<GameManager>
{
    public CharacterStats playerStats;

    public bool Ken_Human = true;

    [SerializeField]private CinemachineVirtualCamera followCamera;
    List<IEndGameObserver> endGameObservers = new List<IEndGameObserver>();

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        
    }
    public void RigisterPlayer(CharacterStats player)
    {
        playerStats = player;

        followCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<CinemachineVirtualCamera>();
        
        if(followCamera != null)
        {
            followCamera.Follow = playerStats.transform;
        }
        

    }

    public IEnumerator KnockBack(float knockDur , float knockbackPwrX,float knockbackY, Vector3 knockbackDir , Rigidbody2D rb)
    {
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;

            rb.AddForce(new Vector3(knockbackPwrX * 1, knockbackDir.y * knockbackY, rb.transform.position.z));
            //yield return new WaitForSeconds(0.01f);
            //rb.AddForce(new Vector3(knockbackDir.x * knockbackPwrX * -1, 0, rb.transform.position.z));
        }
        yield return 0;
    }

    public void AddObserver(IEndGameObserver observer)
    {
        endGameObservers.Add(observer);
    }

    public void RemoveObserver(IEndGameObserver observer)
    {
        endGameObservers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in endGameObservers)
        {
            observer.EndNotify();
        }
    }

    public Transform GetEntrance()
    {
        foreach(var item in FindObjectsOfType<TransitionDestination>())
        {
            if (item.destinationTag == TransitionDestination.DestinationTag.FOREST)
                return item.transform;
        }
        return null;
    }
}
