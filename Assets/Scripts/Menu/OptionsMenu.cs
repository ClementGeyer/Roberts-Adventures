using UnityEngine;
using UnityEngine.Audio;

namespace Menu
{
    public class OptionsMenu : MonoBehaviour
    {
        public AudioMixer audioMixer;
        public GameObject menu;

        /// <summary>
        /// Sors du menu options
        /// </summary>
        public void BackArrow()
        {
            menu.SetActive(false);
        }

        /// <summary>
        /// Règle le volume de la musique et des bruitages
        /// </summary>
        /// <param name="volume"></param>
        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("Volume", volume);
        
        }
    }
}
