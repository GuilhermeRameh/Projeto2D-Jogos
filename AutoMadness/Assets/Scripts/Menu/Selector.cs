using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField]
    private LevelBools completedLevels;

    public List<GameObject> Blockers;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<completedLevels.Value.Count; i++)
        {
            if (completedLevels.Value[i])
            {
                Blockers[i].SetActive(false);
            }
        }
    }

}
