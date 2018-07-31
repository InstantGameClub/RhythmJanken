using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNotesView : MonoBehaviour
{
    public List<GameObject> NoteList;
    public List<GameObject> EnemyNotes = new List<GameObject>();
    public int NotesSpan = 280;

    public void createNotes(int noteNum)
    {
        GameObject Note = Instantiate(NoteList[noteNum], new Vector3(0, 0, 0), Quaternion.identity, this.gameObject.transform);
        RectTransform instant = Note.GetComponent<RectTransform>();
        instant.localPosition = new Vector3(0, NotesSpan * EnemyNotes.Count, 0);
        instant.localEulerAngles = new Vector3(180, 0, 0);
        EnemyNotes.Add(Note);
    }

    public void destroyFirstNotes()
    {
        Destroy(EnemyNotes[0]);
        EnemyNotes[0] = null;
        EnemyNotes.RemoveAt(0);
    }

    public void destroyAllNotes()
    {
        for (int key = 0; key < EnemyNotes.Count; key++)
        {
            Debug.Log(key);
            Destroy(EnemyNotes[key]);
            EnemyNotes[key] = null;
        }
        EnemyNotes.Clear();
        EnemyNotes = new List<GameObject>();
    }


    public void sortPositionNotes()
    {
        foreach (GameObject Note in EnemyNotes)
        {
            RectTransform instant = Note.GetComponent<RectTransform>();
            instant.localPosition = new Vector3(0, instant.localPosition.y - NotesSpan, 0);
        }

    }

}
