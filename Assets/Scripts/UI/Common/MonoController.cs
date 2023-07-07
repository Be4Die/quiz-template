using UnityEngine;
using UnityEngine.UIElements;

namespace QuizTemplate.UI.Common
{
    [RequireComponent(typeof(UIDocument))]
    public abstract class MonoController<T> : MonoBehaviour where T : Model
    {
        protected UIDocument m_document;
        protected VisualElement m_root;

        protected T m_model;
        private void Awake()
        {
            m_model = RegisterModel();
            m_document = GetComponent<UIDocument>();
            m_root = m_document.rootVisualElement;

            RegistrDynamicUI();
            BindElements();
        }

        protected abstract T RegisterModel();
        protected virtual void RegistrDynamicUI() { }
        protected abstract void BindElements();
    }

    [RequireComponent(typeof(UIDocument))]
    public abstract class MonoController : MonoBehaviour
    {
        protected UIDocument m_document;
        protected VisualElement m_root;
        private void Awake()
        {
            Init();

            m_document = GetComponent<UIDocument>();
            m_root = m_document.rootVisualElement;

            RegistrDynamicUI();
            BindElements();
        }

        protected virtual void Init() { }

        protected virtual void RegistrDynamicUI() { }
        protected abstract void BindElements();
    }
}