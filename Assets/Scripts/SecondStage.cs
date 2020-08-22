using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SecondStage : MonoBehaviour
{
    public Animator transition;
    Enemyhealth health;

    private void Start() 
    {
        health = GetComponent<Enemyhealth>();    
    }

   private void Update()
    {
       if(health.IsDead())
       {
           Invoke("NextStage", 0.5f);
       }
   }

   public void NextStage()
   {
       LoadNextScene();
   }

    private void LoadNextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

     IEnumerator LoadScene(int sceneIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneIndex);
    }

}
