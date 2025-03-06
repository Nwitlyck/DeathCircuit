using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//when something get into the alta, make the runes glow
namespace Cainos.PixelArtTopDown_Basic
{

    public class PropsAltar : MonoBehaviour
    {
        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        private Color curColor;
        private Color targetColor;

        private void Awake()
        {
            targetColor = runes[0].color;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            targetColor.a = 1.0f;
            if (PlayerPrefs.GetInt("Consumibles")  >= 5)
            {
                StartCoroutine(LoadNextSceneAsync());
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            targetColor.a = 0.0f;
        }

        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }

        void UnlockNewLevel(int currentSceneIndex)
        {

            PlayerPrefs.SetInt("Consumibles", 0);

            if (currentSceneIndex != 3 && SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
            {
                PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
                PlayerPrefs.SetInt("UnlockedLevel", SceneManager.GetActiveScene().buildIndex + 1);
            }
            PlayerPrefs.Save();
            Debug.Log("PropsAltar_UnlockNewLevel_Consumibles: " + PlayerPrefs.GetInt("Consumibles"));
            Debug.Log("PropsAltar_UnlockNewLevel_ReachedIndex: " + PlayerPrefs.GetInt("ReachedIndex"));
            Debug.Log("PropsAltar_UnlockNewLevel_UnlockedLevel: " + PlayerPrefs.GetInt("UnlockedLevel"));
        }

        IEnumerator LoadNextSceneAsync()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex == 3) ? 4 : currentSceneIndex + 1;

            AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneIndex);
            operation.allowSceneActivation = false;

            while (operation.progress < 0.9f)
            {

                yield return null;
            }

            yield return new WaitForSeconds(3);

            UnlockNewLevel(currentSceneIndex);

            operation.allowSceneActivation = true;
        }
    }
}
