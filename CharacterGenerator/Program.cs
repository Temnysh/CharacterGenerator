// Console.WriteLine("Character Generator");
/*3.1 Генератор персонажей.
 Характеристики:  силы, ловкости, выносливости, интеллекта, мудрости, харизмы
 
 Сразу после  запуска выводить ФИ и, через строчку,
 значение каждой характеристики и её модификатор.
 
 Правила роляния характеристик:
 кидаем 6 раз 4d6, и рандомно распределяем
 получившиеся 6 чисел между характеристиками.
 
 Чтобы вычислить модификатор характеристики,
 нужно из её значения вычесть 10 и разделить на 2 с
 округлением до меньшего целого. */

class Program
{
    public static void Main(string[] args)
    {
        Random rnd = new Random();
        List<string> NameF = File.ReadAllLines("./NameF.txt").ToList(); //Запись в лист всех строчек сразу
        List<string> NameM = File.ReadAllLines("./NameM.txt").ToList();
        List<string> SName = File.ReadAllLines("./SName.txt").ToList();

        List<string> allName = new List<string>();
        allName.AddRange(NameM);
        allName.AddRange(NameF);
        string NameRND = allName[rnd.Next(allName.Count)];
        string SNameRND = SName[rnd.Next(SName.Count)];
        Console.WriteLine(" " + NameRND + " " + SNameRND);

        GenerateFeatures();

        string nameMather = NameF[rnd.Next(NameF.Count)];
        string nameFather = NameM[rnd.Next(NameM.Count)];

        string characterGender; 
        bool isElementInList = NameF.Contains(NameRND);
        if (isElementInList)
        {
            characterGender = "Her";
        }
        else
        {
            characterGender = "His";
        }
        Console.WriteLine(" " + characterGender + " mother - " + nameMather + " " + SNameRND);
        GenerateFeatures();
        Console.WriteLine(" " + characterGender + " father - " + nameFather + " " +  SNameRND);
        GenerateFeatures();
    }

    public static void GenerateFeatures()
    {
        Random rnd = new Random();
        int[] arrCharacteristics = new int[6];
        
        for (int i = 0; i < 6; i++)
        {
            arrCharacteristics[i] = rnd.Next(15) + 4;
        }

        string[] characteristics = new string[]{"strength","dexterity","endurance","intelligence","wisdom","charisma"};
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine(characteristics[i] + " " + arrCharacteristics[i]);
        }

        Console.WriteLine();
    }
}