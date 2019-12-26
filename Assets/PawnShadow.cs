using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnShadow : MonoBehaviour
{
    [SerializeField] List<GameObject> shadowParts;
    List<GameObject> tetrisParts;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void EnableShadow()
    {
        foreach(var parts in shadowParts)
        {
            parts.SetActive(true);
        }
        SetShadowPosition();
    }
    public void DisableShadow()
    {
        foreach (var parts in shadowParts)
        {
            parts.SetActive(false);
        }
    }
    public void SetShadowPosition()
    {
        tetrisParts = GetComponent<Tetrion>().Parts;
        int i = 0;
        int deep = 100;
        int tempDeep = 0;
        foreach(var part in tetrisParts)
        {
            tempDeep = CheckDeep(part.GetComponent<Part>());
            deep = deep < tempDeep ? deep : tempDeep;
        }
        foreach(var part in shadowParts)
        {
            part.transform.localPosition = tetrisParts[i].transform.localPosition;
            part.transform.Translate(0, -1*deep, 0);
            i++;
        }
    }
    private int CheckDeep(Part part)
    {
        Socket socket = part.CurrentSocket.Under;
        int deep = 0;
        bool canFall = true;
        while(canFall)
        {
            canFall = part.GetComponent<PartMover>().CanItMove(socket);
            if (canFall)
            {
                socket = socket.Under;
                deep++;
            }
        }
        return deep;
    }

}
