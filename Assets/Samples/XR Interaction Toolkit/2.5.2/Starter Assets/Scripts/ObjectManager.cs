using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class ObjectManager : MonoBehaviour
{
/*    enum STAGE { s1_pond, s2_boat, s3_others};
    STAGE stage;*/

    [SerializeField]
    [Tooltip("Counnt the number of objects")]
    List<int>m_objCount = new List<int>();
    public ObjectSpawner objectSpawner;
    public List<int> objCount
    {
        get => m_objCount;
        set => m_objCount = value;
    }

    public List<Button> obj_buttons;


    public static ObjectManager Instance { get { return _instance; } }
    private static ObjectManager _instance;

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

    // Start is called before the first frame update
    void Start()
    {
        //stage = STAGE.s1_pond;
        update_state();
    }

    public void update_state()
    {
        if (m_objCount[0]<=0) // water not added
        {
            obj_buttons[0].interactable = true;
            obj_buttons[1].interactable = false;
            obj_buttons[2].interactable = false;
            obj_buttons[3].interactable = false;
            obj_buttons[4].interactable = false;
            obj_buttons[5].interactable = false;
            obj_buttons[6].interactable = false;
        }
        else if (m_objCount[1]<=0) // boat not added
        {
            obj_buttons[0].interactable = false;
            obj_buttons[1].interactable = true;
            obj_buttons[2].interactable = false;
            obj_buttons[3].interactable = false;
            obj_buttons[4].interactable = false;
            obj_buttons[5].interactable = false;
            obj_buttons[6].interactable = false;
        }
        else if (m_objCount[2] > 4) // can only add 5 fishes
        {
            obj_buttons[0].interactable = false;
            obj_buttons[1].interactable = false;
            obj_buttons[2].interactable = false;
            obj_buttons[3].interactable = true;
            obj_buttons[4].interactable = true;
            obj_buttons[5].interactable = true;
            obj_buttons[6].interactable = true;
        }
        else
        {
            obj_buttons[0].interactable = false;
            obj_buttons[1].interactable = false;
            obj_buttons[2].interactable = true;
            obj_buttons[3].interactable = true;
            obj_buttons[4].interactable = true;
            obj_buttons[5].interactable = true;
            obj_buttons[6].interactable = true;
        }    
    }

    public bool can_spawn(int index)
    {
        if(index==2 && m_objCount[2] == 3)//fish
        {
            PopUpToolTip.Instance.add_pop_up("Note: you can only add 4 fish! (just for demo)");
        }
        return obj_buttons[index].interactable == true;
    }
}
