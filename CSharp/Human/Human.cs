namespace Human{
    public class Human{
        public string playerName;
        public int str;
        public int intel;
        public int dex;
        public int health;
        public Human(string name){
            playerName = name;
            str = 3;
            intel = 3;
            dex = 3;
            health = 100;
        }
        public Human(string name, int strength, int inteligence, int dexterity, int hp){
            playerName = name;
            str = strength;
            intel = inteligence;
            dex = dexterity;
            health = hp;
        }
        public void attack(Human target){
                target.health -= 5*str;
        }
    }
}