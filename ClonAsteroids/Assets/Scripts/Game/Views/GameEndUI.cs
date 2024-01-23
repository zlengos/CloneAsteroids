using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Views
{
    public class GameEndUI : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private Text scoreText;
        
        #endregion

        public void ShowEndGame(int score)
        {
            scoreText.text = $"Score: {score}";
            this.gameObject.SetActive(true);
        }
        
        public void RestartGame() 
            => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}