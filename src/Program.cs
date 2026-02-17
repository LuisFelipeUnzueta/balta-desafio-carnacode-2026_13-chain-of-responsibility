using System;
using DesignPatternChallenge.Models;
using DesignPatternChallenge.Handlers;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CORPORATE EXPENSE APPROVAL SYSTEM (Chain of Responsibility) ===");

            // 1. Setup the chain
            var supervisor = new SupervisorHandler();
            var manager = new ManagerHandler();
            var director = new DirectorHandler();
            var ceo = new CEOHandler();

            supervisor.SetNext(manager)
                      .SetNext(director)
                      .SetNext(ceo);

            // 2. Process requests
            var requests = new[]
            {
                new ExpenseRequest("João Silva", 50.00m, "Office Supplies", "IT"),
                new ExpenseRequest("Maria Santos", 350.00m, "Training Course", "HR"),
                new ExpenseRequest("Pedro Oliveira", 2500.00m, "Laptop", "IT"),
                new ExpenseRequest("Ana Costa", 15000.00m, "Datacenter Server", "IT")
            };

            foreach (var request in requests)
            {
                Console.WriteLine($"\n--- Processing Expense Request ---");
                Console.WriteLine($"Employee: {request.EmployeeName}");
                Console.WriteLine($"Amount: R$ {request.Amount:N2}");
                Console.WriteLine($"Purpose: {request.Purpose}");
                Console.WriteLine($"Department: {request.Department}");
                
                supervisor.Handle(request);
            }

            Console.WriteLine("\n=== REFLECTION QUESTIONS ===");
            Console.WriteLine("1. How to decouple approval levels?");
            Console.WriteLine("   - Each handler only knows about its successor, not the entire chain or specific handlers.");
            Console.WriteLine("2. How to let each level decide whether to process or forward?");
            Console.WriteLine("   - Each handler implements its logic and calls base.Handle(request) only if it cannot process it.");
            Console.WriteLine("3. How to facilitate adding/removing levels?");
            Console.WriteLine("   - Adding a level only requires creating a new handler class and plugging it into the chain setup in Program.cs.");
            Console.WriteLine("4. How to create different chains dynamically?");
            Console.WriteLine("   - The chain is built at runtime, allowing different configurations (e.g., skip Supervisor for certain departments).");
        }
    }
}
