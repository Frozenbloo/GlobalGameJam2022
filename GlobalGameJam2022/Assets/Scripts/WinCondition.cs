using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [Header("Scene Index")]
    public int Respawn;

    [Header("Death FX")]
    AudioSource audioData;
    public ParticleSystem fx1;
    public ParticleSystem fx2;

    public Animator transition;


    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            fx1.Play();
            fx2.Play();
            yield return new WaitForSeconds(2f);
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
