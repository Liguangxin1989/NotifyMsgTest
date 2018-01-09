using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class NotifyMessageMgr : MonoBehaviour {
    public GameObject MessageGo;
    public Vector3 pos;
    //public GameObject go;

    List<GameObject> notifyList = new List<GameObject>();

    // Use this for initialization
    void Start () {


        DOTween.Init(true, true, LogBehaviour.Verbose);
        //this.Invoke("func1", 4);

    }

    float tmpTime = 0;

    private void Update()
    {
        tmpTime += Time.deltaTime;
        if (tmpTime >1.5f)
        {
            tmpTime -= 1.5f;
            func1();
        }
    }
    void func1()
    {
        var go = GameObject.Instantiate<GameObject>(MessageGo);
        go.transform.parent = transform;
        var message = go.GetComponent<Message>();
        message.transform.position = new Vector3(pos.x, pos.y - 180, pos.z);
        message.transform.localScale = Vector3.zero;

        Sequence seq = DOTween.Sequence();
        seq.Append(go.transform.DOMoveY(pos.y-40, 0.5f).SetEase(Ease.OutQuad));
        seq.Insert(0, (go.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutQuad)));
        seq.AppendInterval(1f);
        seq.Append(go.transform.DOMoveY(400, 0.5f).SetRelative().SetEase(Ease.InQuad));
        seq.AppendCallback(() => { go.SetActive(false); notifyList.Remove(go); });
        notifyList.Add(go);
        MoveNotifyList();
    }

    void MoveNotifyList()
    {
        foreach (var go in notifyList)
        {
            if (go)
                go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y+100, go.transform.position.z);
        }
    }



}
