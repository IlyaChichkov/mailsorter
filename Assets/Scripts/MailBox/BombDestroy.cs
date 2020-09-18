using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    public SpawnManage spawn;

    public void DestroyBomb(){
        spawn.canCreateBomb = true;

        Destroy(this.gameObject);
    }
}
