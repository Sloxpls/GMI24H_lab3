namespace LinkedListProject;

public class MainClass {
    private static readonly IListInterface<Person> PeopleList = new ListReferencedBased<Person>();

    public static void Main(string[] args) {
        bool exit = false;
        while (!exit) {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Person to the List");
            Console.WriteLine("2. Remove Person from the List");
            Console.WriteLine("3. Display List of People");
            Console.WriteLine("4. Access Element by Index");
            Console.WriteLine("5. Get Head");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice)) {
                switch (choice) {
                    case 1:
                        AddPerson();
                        break;
                    case 2:
                        RemovePerson();
                        break;
                    case 3:
                        DisplayPeopleList();
                        break;
                    case 4:
                        AccessElementByIndex();
                        break;
                    case 5:
                        GetHead();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            Console.WriteLine();
        }
    }

    private static void AddPerson() {
        Console.Write("Enter person's name: ");
        string? name = Console.ReadLine();
        Console.Write("Enter person's age: ");
        if (int.TryParse(Console.ReadLine(), out int age)) {
            if (name != null) {
                Person person = new Person(name, age);
                Console.Write("Enter index to add (starting from 1): ");
                if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= PeopleList.Size() + 1) {
                    PeopleList.Add(person, index);
                    Console.WriteLine("Person added successfully.");
                }
                else {
                    Console.WriteLine("Invalid index. Please enter a valid index.");
                }
            }
            else {
                Console.WriteLine("Name cannot be null.");
            }
        }
        else {
            Console.WriteLine("Invalid age. Please enter a number.");
        }
    }

    private static void RemovePerson() {
        DisplayPeopleList();
        Console.Write("Enter the index of the person to remove: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= PeopleList.Size()) {
            PeopleList.Remove(index);
            Console.WriteLine("Person removed successfully.");
        }
        else {
            Console.WriteLine("Invalid index. Please enter a valid index.");
        }
    }

    private static void DisplayPeopleList() {
        Console.WriteLine("People: ");
        if (PeopleList.Size() == 0) {
            Console.WriteLine("List is empty.");
        }
        else {
            for (int i = 1; i <= PeopleList.Size(); i++) {
                Console.WriteLine($"[{i}] {PeopleList.Get(i)}");
            }
        }
    }

    private static void AccessElementByIndex() {
        Console.Write("Enter the index of the person to access: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= PeopleList.Size()) {
            try {
                Person person = PeopleList.Get(index);
                Console.WriteLine($"Person at index {index}: {person}");
            }
            catch (ListIndexOutOfBoundsException ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else {
            Console.WriteLine("Invalid index. Please enter a valid index.");
        }
    }

    private static void GetHead() {
        if (PeopleList.Size() > 0) {
            Console.WriteLine($"Head of the list: {PeopleList.Get(1)}");
        }
        else {
            Console.WriteLine("List is empty.");
        }
    }
}

