using UnityEngine;

public class JsonReaderSongNodes : MonoBehaviour
{
    public TextAsset JsonforSongData;

   
    [System.Serializable]
    public class notes
    {
        public int typeOfSection;
        public bool mustHitSection;
        public int lengthInSteps;
        public Vector3[] sectionNotes;
    }

    [System.Serializable]
    public class sectionLengths
    {
        /*public string song;
        public int bpm;
        public bool changeBPM;
        public notes[] notes;*/
    }
    
    [System.Serializable]
    public class SongData
    {
        public string player2;
        public string player1;
        public float speed;
        public bool needsVoices;
        public sectionLengths[] sectionLengths;
        public string song;
        public int bpm;
        public bool changeBPM;
        public notes[] notes;
    }
    public SongData mySongData = new SongData();

    void Start()
    {
        mySongData = JsonUtility.FromJson<SongData>(JsonforSongData.text);
    }
}
