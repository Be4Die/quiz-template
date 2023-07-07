using QuizTemplate.UI.Common;
using UnityEngine.UIElements;
using UnityEngine;

namespace QuizTemplate.UI
{
    public class MainMenuController : MonoController
    {
        private readonly string m_titleLabelLiteral = "Title";
        private readonly string m_playButtonLiteral = "Play";
        private readonly string m_musicButtonLiteral = "Music";

        [SerializeField] private Sprite m_soundOn;
        [SerializeField] private Sprite m_soundOff;
        private string m_title;
        private Button m_musicButton;

        protected override void RegistrDynamicUI()
        {
            base.RegistrDynamicUI();

            m_root.Q<Label>(m_titleLabelLiteral).text = m_title;
            m_musicButton = m_root.Q<Button>(m_musicButtonLiteral);
        }

        protected override void BindElements()
        {
            m_musicButton.clicked += ToggleMusic;
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
