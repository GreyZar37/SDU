using AnswerProgram;


namespace TestProject;

public class Tests
{

    private List<Person> expectedPersons = new List<Person>
    {
        new Person("Jeremy", 25, "Brazil"),
        new Person("Elizabeth", 30, "America"),
        new Person("Demitri", 28, "Russia")
    };

    private List<Person> answerPersons = new List<Person>();

   

    [Test]
    public void TestPeople()
    {
        for (int i = 0; i < 3; i++)
        {
             Assert.That($"{answerPersons[i].name}, {answerPersons[i].age}, {answerPersons[i].country}", Is.EqualTo($"{answerPersons[i].name}, {answerPersons[i].age}, {answerPersons[i].country}"));
        }
    }

    public void AddPerson(Person person)
    {
         answerPersons.Add(person);
    }
}