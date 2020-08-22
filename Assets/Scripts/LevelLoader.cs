using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider slider;
    public Animator transition;

   public void LoadLevel(int sceneIndex)
   {
       StartCoroutine(LoadScene(sceneIndex));
   }

   IEnumerator LoadScene(int sceneIndex)
   {
       transition.SetTrigger("Start");
       yield return new WaitForSeconds(1);
       AsyncOperation operation =  SceneManager.LoadSceneAsync(sceneIndex);
       loadingScreen.SetActive(true);

       while(!operation.isDone)
       {
           float progress = Mathf.Clamp01(operation.progress / 0.9f);
           slider.value = progress;

           yield return null;
       }
   }
}
