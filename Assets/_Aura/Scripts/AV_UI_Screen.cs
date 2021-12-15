using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Auravision.UI
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CanvasGroup))]
    public class AV_UI_Screen : MonoBehaviour
    {
        #region Variables
        [Header("Events")]
        public UnityEvent onStartScreen = new UnityEvent();
        public UnityEvent onScreenClose = new UnityEvent();

        [Header("Selectable Element On Screen Start")]
        public Selectable m_StartSelectable;

        private Animator animator;
        // Start is called before the first frame update 
        #endregion

        #region Unity Callbacks
        void Start()
        {
            animator = GetComponent<Animator>();


            //guide user to start selectable by highlighting
            if (m_StartSelectable != null)
            {
                EventSystem.current.SetSelectedGameObject(m_StartSelectable.gameObject);
            }
        }
        #endregion

        #region Utility
        public void StartScreen()
        {
            if(onStartScreen != null)
            {
                onStartScreen.Invoke();
            }

            ToggleAnimator("show");
        }

        public void CloseScreen()
        {
            if(onScreenClose != null)
            {
                onScreenClose.Invoke();
            }

            ToggleAnimator("hide");
        }

        private void ToggleAnimator(string aTrigger)
        {
            if(animator != null)
            {
                animator.SetTrigger(aTrigger);
            }
        }
        #endregion

    }
}
