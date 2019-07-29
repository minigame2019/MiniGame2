using System;

namespace FightSystem{
    class Fighter{
        public string name;
        public int hp;
        public int atk;
        public int def;
        public int luck;

        public Fighter(string pname, int php, int patk, int pdef, int pluck = 0){
            name = pname;
            hp = php;
            atk = patk;
            def = pdef;
            luck = pluck;
        }

        public Fighter(Player player)
        {
            name = player.name;
            hp = player.PlayerAttribute.Hp;
            atk = player.PlayerAttribute.Attack;
            def = player.PlayerAttribute.Defend;
            luck = player.PlayerAttribute.Luck;
        }
    }
}