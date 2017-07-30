using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable]
public class ToggleEvent : UnityEvent<bool>{}

public class Player : NetworkBehaviour 
{
    [SerializeField] ToggleEvent onToggleShared;
    [SerializeField] ToggleEvent onToggleLocal;
    [SerializeField] ToggleEvent onToggleRemote;
    [SerializeField] float respawnTime = 5f;

    GameObject mainCamera;
    void Start()
    {
        GetComponentInChildren<Camera>().enabled = false;
        //mainCamera = Camera.main.gameObject;
        //mainCamera.SetActive(false);
        EnablePlayer ();
    }
    void DisablePlayer()
    {
        //if (isLocalPlayer)
        //mainCamera.SetActive(true);
        onToggleShared.Invoke(false);

        if (isLocalPlayer)
            onToggleLocal.Invoke(false);
        else
            onToggleRemote.Invoke(false);
    }

    void EnablePlayer()
    {
        if (isLocalPlayer)
        GetComponentInChildren<Camera>().enabled = true;
        //mainCamera.SetActive(false);
        onToggleShared.Invoke(true);

        if (isLocalPlayer)
            onToggleLocal.Invoke(true);
        else
            onToggleRemote.Invoke(true);

    }

    public void Die()
    {
        //DisablePlayer();
        if (!isServer)
            if (isLocalPlayer)
                SceneManager.LoadScene(1);
        Invoke("Respawn", respawnTime);
    }

    void Respawn()
    {
        if (isLocalPlayer)
        {            
            Transform spawn = NetworkManager.singleton.GetStartPosition();
            transform.position = spawn.position;
            transform.rotation = spawn.rotation;
        }

        EnablePlayer();
    }
}