using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private float jumpforce;
    private bool ignoreNextCollision;
    [SerializeField] GameObject splashPrefab;
    private GameManager gm;
    [SerializeField] private AudioSource ballAudio;
    [SerializeField] private AudioClip bounce;
    [SerializeField] private AudioClip winLevel;



    private void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        ballAudio = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (ignoreNextCollision)
            return;
        myRigidbody.velocity = Vector3.zero;
        myRigidbody.AddForce(Vector3.up * jumpforce,ForceMode.Impulse);
        
        ignoreNextCollision = true;
        Invoke("AllowCollision", 0.2f);

        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3 (0,-0.3f,0), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);

        string metarialName = other.gameObject.GetComponent<MeshRenderer>().material.name;

        if (metarialName == "SafeZone (Instance)")
        {
            ballAudio.PlayOneShot(bounce);
            
        }
        else if (metarialName == "DangerZone (Instance)")
        {
            gm.RestartGame();
        }
        else if (metarialName == "EndZone (Instance)")
        {
            StartCoroutine(Delay());
        }


    }

    IEnumerator Delay()
    {
        ballAudio.PlayOneShot(winLevel);
        yield return new WaitForSeconds(1);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
        
        
    }
    private void AllowCollision()
    {
        ignoreNextCollision = false;
    }

}
