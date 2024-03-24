using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets
{
    public class PopUpToolTip : MonoBehaviour
    {
        public GameObject PopUpZone;
        public GameObject PopUpPrefab;

        public static PopUpToolTip Instance { get { return _instance; } }
        private static PopUpToolTip _instance;

        // singleton pattern
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        public void add_pop_up(string text)
        {
            Instantiate(PopUpPrefab,PopUpZone.transform);
            PopUpPrefab.GetComponent<Text>().text = text;
        }
    }
}
