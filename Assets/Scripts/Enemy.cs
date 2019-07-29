using System;
using System.Collections.Generic;

namespace FightSystem{
    
    class EnemyCreator{

        public Enemy createByID(int id){
            switch(id){
                case 0:
                return new Enemy(0, "sheep", 30, 13, 0, true, true, false);
                case 1:
                return new Enemy(1, "wolf", 60, 20, 2, true, true, false);
                case 2:
                return new Enemy(2, "youngwolf", 40, 15, 1, true, true, false);
                case 3:
                return new Enemy(3, "skull", 35, 22, 1, false, false, true);
                case 4:
                return new Enemy(4, "bear", 70, 18, 6, true, true, false);
                case 5:
                return new Enemy(5, "ghost", 50, 21, 5, false, false, true);
                case 6:
                return new Enemy(6, "orc", 80, 25, 7, false, true, true);
                case 7:
                return new Enemy(7, "gnome", 30, 0, 1, false, true, true);
                default:
                return null;
            }
        }

        public Enemy createByName(string name){
            return createByID(nameToID(name));
        }

        private int nameToID(string name){
            if(name == "sheep") return 0;
            if(name == "wolf") return 1;
            if(name == "youngwolf") return 2;
            if(name == "skull") return 3;
            if(name == "bear") return 4;
            if(name == "ghost") return 5;
            if(name == "orc") return 6;
            if(name == "gnome") return 7;
            return -1;
        }
    }

    class Enemy{
        public int id;
        public string name;
        public int hp;
        public int atk;
        public int def;
        public bool is_living;
        public bool is_beast;
        public bool is_magical;

        public Enemy(int pid, string pname, 
            int php, int patk, int pdef, 
            bool pisliving, bool pisbeast, bool pismagical){
            id = pid;
            name = pname;
            hp = php;
            atk = patk;
            def = pdef;
            is_living = pisliving;
            is_beast = pisbeast;
            is_magical = pismagical;
        }
    }

}
