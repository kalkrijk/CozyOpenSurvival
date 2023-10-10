using System.Collections.Generic;
using UnityEngine;

namespace TinyGiantStudio.ModularToDoLists
{
    [System.Serializable]
    public class Task
    {
        public string myName = "New Task Name";
        public bool hideMyDetails = true;

        public bool addedDescription = false;
        public string myDescription = "Description";

        public bool addedReference = false;
        public List<UnityEngine.Object> references = new List<UnityEngine.Object>();

        public bool completed = false;
        public bool failed = false;
        public bool ignored = false;

        public TGSTime creationTime;
        public bool hasDueDate = false;
        public TGSTime dueDate;
        public TGSTime completionTime;
        public TGSTime failedTime;
        public TGSTime ignoredTime;

        public List<Topic.Tag> tags = new List<Topic.Tag>();

        //editor only
        public bool editing;
        [Tooltip("The index if filtered out tasks are ignored.")]
        public int visibilityIndex;
        public float heightTakenInEditor;
    }
}