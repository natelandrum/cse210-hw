using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Text.Json;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    // https://khalidabuhakmeh.com/serialize-interface-instances-system-text-json
    private List<Object> _goalList = new List<Object>();

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int option = 0;

        while (option != 6)
        {
            Console.Clear();

            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("     1. Create New Goal");
            Console.WriteLine("     2. List Goals");
            Console.WriteLine("     3. Save Goals");
            Console.WriteLine("     4. Load Goals");
            Console.WriteLine("     5. Record Event");
            Console.WriteLine("     6. Quit");
            Console.Write("Select a choice from the menu: ");
            string index = Console.ReadLine();

            if (int.TryParse(index, out int result)) 
            {
                option = result;
                switch (option)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoalDetails();
                        break;
                    case 3:
                        Save();
                        break;
                    case 4:
                        Load();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Thread.Sleep(3000);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
                Thread.Sleep(3000);
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.\n");
    }

    public void ListGoalNames() 
    {
        int counter = 1;

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{counter}. {goal.GetName()}");
            counter++;
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals. Add One first.");
            Thread.Sleep(3000);
        }
        else
        {
            int counter = 1;

            foreach (Goal goal in _goals)
            {
                Console.WriteLine($"{counter}. {goal.GetDetailsString()}");
                counter++;
            }
            Thread.Sleep(5000);
        }
    }

    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("The types of goals you can create are:");
        Console.WriteLine("     1. Simple Goal");
        Console.WriteLine("     2. Eternal Goal");
        Console.WriteLine("     3. Checklist Goal");
        Console.WriteLine("     4. Negative Goal");
        Console.Write("Which type of goal would you like to create? ");

        string index = Console.ReadLine();
        if (int.TryParse(index, out int result)) 
            {

                Console.Write("\nEnter the name of the goal: ");
                string name = Console.ReadLine();
                Console.Write("Enter a short description of the goal: ");
                string description = Console.ReadLine();
                Console.Write("Enter the number of points the goal is worth: ");
                string points = Console.ReadLine();
                if (int.TryParse(points, out int pointsResult))
                {
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Thread.Sleep(3000);
                    CreateGoal();
                }
                switch(result)
                {
                    case 1:
                    {
                        int pointsInt = pointsResult; 
                        _goals.Add(new SimpleGoal(name, description, pointsInt));
                        break;
                    }
                    case 2:
                    {
                        int pointsInt = pointsResult;
                        _goals.Add(new EternalGoal(name, description, pointsInt));
                        break;
                    }
                    case 3:
                    {
                        Console.Write("Enter the target number of events to complete the goal: ");
                        string target = Console.ReadLine();
                        if (int.TryParse(target, out int targetResult))
                        {
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                            Thread.Sleep(3000);
                            CreateGoal();
                        }
                        Console.Write("Enter the bonus points for completing the goal: ");
                        string bonus = Console.ReadLine();
                        if (int.TryParse(bonus, out int bonusResult))
                        {
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                            Thread.Sleep(3000);
                            CreateGoal();
                        }
                        int pointsInt = pointsResult;
                        int targetInt = targetResult;
                        int bonusInt = bonusResult;
                        _goals.Add(new ChecklistGoal(name, description, pointsInt, targetInt, bonusInt));
                        break;
                    }
                    case 4:
                    {
                        int pointsInt = pointsResult;
                        _goals.Add(new NegativeGoal(name, description, pointsInt));
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid option. Please try again.");
                        Thread.Sleep(3000);
                        break;
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
                Thread.Sleep(3000);
            }
    }
    
    public void RecordEvent()
    {
        Console.Clear();
        Console.WriteLine("Which goal would you like to record an event for?");
        ListGoalNames();
        Console.Write("Enter the number of the goal: ");
        string index = Console.ReadLine();
        if (int.TryParse(index, out int result)) 
        {
            Console.WriteLine($"\nRecording event for {_goals[result-1].GetName()}");
            int points = _goals[result-1].RecordEvent();
            if (points == 0)
            {
                Console.WriteLine("This goal is already complete. No points awarded.");
            }
            else
            {
                _score += points;
                Console.WriteLine($"Event recorded. You now have {_score} points.");
            }
            
            Thread.Sleep(5000);
        }
        else
        {
            Console.WriteLine("Invalid option. Please try again.");
            Thread.Sleep(3000);
        }

    }

    public void Save()
    {
        _goalList.Clear();

        foreach (Goal goal in _goals)
        {
            _goalList.Add(goal.GetStringRepresentation());
        }

        _goalList.Add(new ScoreJSON() { Score = _score });

        string json = JsonSerializer.Serialize(_goalList);

        Console.WriteLine("Saving goals to file.");
        File.WriteAllText("goals.json", json);
        Thread.Sleep(3000);
    }

    public void Load()
    {
        if (File.Exists("goals.json"))
        {
            string json = File.ReadAllText("goals.json");
            _goalList = JsonSerializer.Deserialize<List<Object>>(json);

            _goals.Clear();
            _score = 0;

            for (int i = 0; i < _goalList.Count - 1; i++)
            {
                GoalJSON goal = JsonSerializer.Deserialize<GoalJSON>(_goalList[i].ToString());
                switch (goal.Type)
                {
                    case "SimpleGoal":
                        Goal g = new SimpleGoal(goal.Name, goal.Description, goal.Points);
                        if (goal.Properties[0] == 1)
                        {
                            g.RecordEvent();
                        }
                        _goals.Add(g);
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(goal.Name, goal.Description, goal.Points));
                        break;
                    case "ChecklistGoal":
                        Goal gc = new ChecklistGoal(goal.Name, goal.Description, goal.Points, goal.Properties[1], goal.Properties[2]);
                        if (goal.Properties[0] > 0)
                        {
                            for (int j = 0; j < goal.Properties[0]; j++)
                            {
                                gc.RecordEvent();
                            }
                        }
                        _goals.Add(gc);
                        break;
                }
            }

            ScoreJSON score = JsonSerializer.Deserialize<ScoreJSON>(_goalList[_goalList.Count - 1].ToString());
            _score = score.Score;
        }
        else
        {
            Console.WriteLine("No saved goals found.");
            Thread.Sleep(3000);
        }
    }
}