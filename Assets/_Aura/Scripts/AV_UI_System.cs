using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace Auravision.UI
{
    public class AV_UI_System : MonoBehaviour
    {
        #region Variables
        [SerializeField] Component[] m_Screens;

        private AV_UI_Screen currentScreen;
        public AV_UI_Screen Screen { get=> currentScreen;}

        private AV_UI_Screen previousScreen;
        public AV_UI_Screen PreviousScreen { get=> previousScreen;}
        #endregion

        #region Events
        [Header("Events")]
        public UnityEvent onSwitchedScreens = new UnityEvent();

        [Header("Fader Properties")]
        [SerializeField] Image m_fader;
        [SerializeField] float m_fadeInDuration = 1f;
        [SerializeField] float m_fadeOutDuration = 1f;
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            m_Screens = GetComponentsInChildren<AV_UI_Screen>(true);

            if(m_fader != null)
            {
                m_fader.gameObject.SetActive(true);
            }
            FadeIn();
        } 
        #endregion

        #region Utility

        /// <summary>
        /// Accepts a parameter of type AV_UI_Screen
        /// and switches it to be the active screen
        /// </summary>
        /// <param name="screenToSwitchTo"></param>
        public void SwitchScreens(AV_UI_Screen screenToSwitchTo)
        {
            //null check incoming screen
            if(screenToSwitchTo != null)
            {
                //do we have a current screen
                if (currentScreen)
                {
                    //currentScreen.Close();
                    previousScreen  = currentScreen;
                }
                currentScreen = screenToSwitchTo;
                currentScreen.gameObject.SetActive(true);
                //currentScreen.StartScreen();

                //let other interested objects know of the screen switch
                if(onSwitchedScreens != null)
                {
                    onSwitchedScreens.Invoke();
                }
            }
        }

        public void GoToPreviousScreen()
        {
            //null check previous screen
            if(previousScreen != null)
            {
                SwitchScreens(previousScreen);
            }
        }

        public void LoadSceneByIndex(int index)
        {
            WaitToLoadScene(index);
        }

        IEnumerator WaitToLoadScene(int index)
        {
            yield return null;
        }
        #endregion

        public void FadeIn()
        {
            if(m_fader != null)
            {
                m_fader.CrossFadeAlpha(0f,m_fadeInDuration,false);
            }
        }
        public void FadeOut()
        {
            if (m_fader != null)
            {
                m_fader.CrossFadeAlpha(1f, m_fadeOutDuration, false);
            }
        }
    }
}
