using System;

namespace Human{
    public class Person{
        public string playerName { get; set; }
        public int str { get; set; }
        public int intel { get; set; }
        public int dex { get; set; }
        public int health { get; set; }

        public Person(string name){
            playerName = name;
            str = 3;
            intel = 3;
            dex = 3;
            health = 100;
        }

        public Person(string name, int strength, int inteligence, int dexterity, int hp){
            playerName = name;
            str = strength;
            intel = inteligence;
            dex = dexterity;
            health = hp;
        }

        public void attack(object target){
            Person enemy = target as Person;
            if(enemy == null){
                System.Console.WriteLine("Attack Failed");
            }
            else{
                enemy.health -= 5*str;
            }
        }
    }

    public class Wizard : Person{
            
        public Wizard() : base("Steve"){
            health = 50;
            intel = 25;
        }

        public void heal(){
            this.health += 10 * intel;
        }

        public void fireball(object target){
            Person enemy = target as Person;
            Random rnd = new Random();

            if(enemy == null){
                System.Console.WriteLine("Attack Failed");
            }
            else{
                enemy.health -= rnd.Next(20, 50);
            }
        }
    }
    public class Ninja : Person{


        public Ninja() : base("Joe"){
            dex = 175;
        }

        public void steal(object target){
            Person enemy = target as Person;
            if(enemy == null){
                System.Console.WriteLine("Attack Failed");
            }
            else{
                attack(enemy);
                this.health += 10;
            }
        }

        public void getAway(){
            this.health -= 15;
        }
    }

    public class Samurai : Person{

        int maxHealth = 200;

        public Samurai() : base("Mark"){
            health = 200;
        }

        public void deathBlow(object target){
            Person enemy = target as Person;
            if(enemy == null){
                System.Console.WriteLine("Attack Failed");
            }
            if(enemy.health <= 50){
                enemy.health = 0;
            }
            else{
                attack(enemy);
            }
        }

        public void meditate(){
            this.health = this.maxHealth;
        }
    }
}