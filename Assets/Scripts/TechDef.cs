using System.Collections.Generic;
using UnityEngine;


    public class TechDef
    {
        public int id;
        public string name;
        public string description;
        public int[] dependencies;
        public bool unlocked;
        public int cost;
        public int ticksRequired = 55;
    }
public class TechTreeDef
{
    public TechDef[] techTree;
}