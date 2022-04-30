using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : Singleton<GameManager>
{
    public CharacterStats playerStats;

    public bool Ken_Human = true;

    public bool StopPanel = false;

    public bool notDead = false;

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

    public IEnumerator KnockBack(float knockDur , float knockbackPwrX,float knockbackY , Rigidbody2D rb)
    {
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector3(knockbackPwrX * 1, knockbackY, rb.transform.position.z));
            //yield return new WaitForSeconds(0.01f);
            //rb.AddForce(new Vector3(knockbackDir.x * knockbackPwrX * -1, 0, rb.transform.position.z));
        }
        yield return 0;
    }

    public IEnumerator KnockBack02(CharacterStats Attacker, CharacterStats Defender)
    {
        float timer = 0f;
        while(timer < 0.05f)
        {
            if((Defender.transform.position.x - Attacker.transform.position.x) > 0)
            {
                Defender.transform.position += Vector3.Normalize(new Vector2(0.7f,0f) * Time.deltaTime);
            }
            else
            {
                Defender.transform.position -= Vector3.Normalize(new Vector2(-0.7f, 0f) * Time.deltaTime);
            }
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        yield return null;
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

    public void AgainNotifyObservers()
    {
        foreach (var observer in endGameObservers)
        {
            observer.AgainNotify();
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
