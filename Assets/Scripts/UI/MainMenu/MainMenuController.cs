using QuizTemplate.UI.Common;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuizTemplate.UI
{
    public class MainMenuController : MonoController
    {
        private readonly string m_titleLabelLiteral = "Title";
        private readonly string m_playButtonLiteral = "Play";
        private readonly string m_musicButtonLiteral = "Music";

        [SerializeField] private Sprite m_soundOn;
        [SerializeField] private Sprite m_soundOff;
        private Button m_musicButton;
        private Button m_playButton;

        protected override void RegistrDynamicUI()
        {
            base.RegistrDynamicUI();

            m_root.Q<Label>(m_titleLabelLiteral).text = SettingsProvider.GetGameName();
            m_musicButton = m_root.Q<Button>(m_musicButtonLiteral);
            m_playButton = m_root.Q<Button>(m_playButtonLiteral);
        }

        protected override void BindElements()
        {
            m_musicButton.clicked += ToggleMusic;
            m_playButton.clicked += () => SceneManager.LoadScene("Quiz");
        }

        private void ToggleMusic()
        {
            if (SoundSystem.Instance.IsMusicPlaying)
            {
                m_musicButton.style.backgroundImage = new StyleBackground(m_soundOff);
                SoundSystem.Instance.MusicOff();
            }
            else
            {
                m_musicButton.style.backgroundImage = new StyleBackground(m_soundOn);
                SoundSystem.Instance.MusicOn();
            }
        }
    }
}
