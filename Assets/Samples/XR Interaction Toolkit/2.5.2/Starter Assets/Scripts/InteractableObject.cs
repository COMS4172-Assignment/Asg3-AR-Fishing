using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OBJECT { pond=0,boat=1,fish=2,env1=3,env2=4,env3=5,ref_obj=6 };
public class InteractableObject : MonoBehaviour
{
    public OBJECT obj_type;
    public int value;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDestroy()
    {
        ObjectManager.Instance.objCount[(int)obj_type] -= 1;
        ObjectManager.Instance.update_state();
    }
}
