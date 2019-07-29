using System;
using System.Collections;

namespace FightSystem{
    //win   获胜
    //lose  失败
    //  escape  逃跑成功
    //  die     逃跑失败    死亡
    //giveup    未能击穿装甲
    enum WinOrLose{Win, Lose, Escape, Die, Giveup};

    class Fight{

        private Fighter fighter;
        private Enemy enemy;
        public FightResult fr;

        private bool have_estimated = false;
        private bool have_fighted = false;

        public Fight(Fighter pfighter, Enemy penemy){
            fighter = pfighter;
            enemy = penemy;

            fr = new FightResult(fighter, enemy);
        }

        private float luck2K(int luck){
            switch(luck){
                case 0:
                return 1;
                case 1:
                return 1.5f;
                case 2:
                return 2.2f;
                default:
                return luck;
            }
        }
        
        private double randomWithLuck(double min, double max, int luck){
            float k = luck2K(Math.Abs(luck));
            double rand = new Random().NextDouble();
            if(luck >= 0){
                return min + (max - min) * Math.Pow(rand, 1/k);
            }   
            return min + (max - min) * (1 - Math.Pow(rand, 1/k));
        }

        public FightResult estimatedResult(){
            if(have_estimated){
                return fr;
            }
            have_estimated = true;
            have_fighted = false;

            //未破防
            if(fighter.atk <= enemy.def){
                fr.result = (int)WinOrLose.Lose;
                return fr;
            }

            fr.round = (int)Math.Ceiling((double)(enemy.hp / (fighter.atk - enemy.def)));

            //无伤
            if(fighter.def >= enemy.atk){
                fr.damage = 0;
                return fr;
            }

            fr.damage =  (enemy.atk - fighter.def) * fr.round;

            //HP不足
            if(fighter.hp <= fr.damage){
                fr.result = (int)WinOrLose.Lose;
                return fr;
            }
            fr.result = (int)WinOrLose.Win;
            
            return fr;
        }

        private void win(){
            fr.fighter.hp = fighter.hp - fr.damage;
        }

        private void lose(){
            if(randomWithLuck(0, 1, fighter.luck) > 0.5){
                fr.result = (int)WinOrLose.Escape;
                escape();
                return;
            }
            fr.result = (int)WinOrLose.Die;
            die();
        }

        private void escape(){
            fr.fighter.hp = -1;
        }

        private void die(){
            fr.fighter.hp = 0;
        }

        private void giveUp(){
            fr.fighter.hp = fighter.hp - fr.damage;
        }

        private void afterFight(){
            switch(fr.result){
                case (int)WinOrLose.Win:
                    win();
                    return;
                case (int)WinOrLose.Lose:
                    lose();
                    return;
                case (int)WinOrLose.Giveup:
                    giveUp();
                    return;
                default:
                    return;
            }

        }

        private void fighting(){
            //未破防
            if(fighter.atk <= enemy.def){
                fr.round = 10;

                if(fighter.def >= enemy.atk){
                    fr.damage = 0;
                    fr.result = (int)WinOrLose.Giveup;
                    return;
                }

                int estimated_damage = (enemy.atk - enemy.def) * fr.round;

                if (fighter.hp > estimated_damage){
                    fr.damage = estimated_damage;
                    fr.result = (int)WinOrLose.Giveup;
                    return;
                }

                fr.round = estimated_damage / (enemy.atk - enemy.def) + 1;
                fr.damage = fighter.hp;
                fr.result = (int)WinOrLose.Lose;
                return; 
            }

            fr.round = (int)Math.Ceiling((double)(enemy.hp / (fighter.atk - enemy.def)));

            //无伤
            if(fighter.def >= enemy.atk){
                fr.damage = 0;
                return;
            }

            fr.damage =  (enemy.atk - fighter.def) * fr.round;

            //HP不足
            if(fighter.hp <= fr.damage){
                fr.result = (int)WinOrLose.Lose;
                return;
            }
            fr.result = (int)WinOrLose.Win;
            
            return;
        }

        public FightResult trueResult(){
            if(have_fighted){
                return fr;
            }
            have_estimated = false;
            have_fighted = true;
            
            //beforeFight();

            fighting();

            afterFight();
            
            writeReport();

            return fr;
        }

        private void writeReport(){
            ArrayList rep = new ArrayList();

            rep.Add(string.Format("[{0}]对[{1}]的讨伐结束了", fighter.name, enemy.name));

            switch(fr.result){
                case (int)WinOrLose.Win:
                    rep.Add(string.Format("他奋战了{0}个回合，最终取得了胜利", fr.round));
                    break;
                case (int)WinOrLose.Escape:
                    rep.Add(string.Format("他奋战了{0}个回合，却不敌[{1}]", fr.round, enemy.name));
                    rep.Add("但他幸运地逃了回来");
                    break;
                case (int)WinOrLose.Die:
                    rep.Add(string.Format("他奋战了{0}个回合，却不敌[{1}]", fr.round, enemy.name));
                    rep.Add(string.Format("我们永远怀念[{0}]", fighter.name));
                    break;
                case (int)WinOrLose.Giveup:
                    rep.Add(string.Format("他奋战了{0}个回合，却未能击穿敌人的装甲, 只能无奈地回来", fr.round));
                    break;
                default:
                    break;
            }

            fr.report = rep;
        }
    }
        
    class FightResult{
        public Fighter fighter;
        public Enemy enemy;
        public int result;
        public int round;
        public int damage;
        public ArrayList report;

        public FightResult(Fighter pfighter, Enemy penemy){
            fighter = pfighter;
            enemy = penemy;
            result = 0;
            round = 999;
            damage = 9999;
            
            report = new ArrayList();
        }

    }

}