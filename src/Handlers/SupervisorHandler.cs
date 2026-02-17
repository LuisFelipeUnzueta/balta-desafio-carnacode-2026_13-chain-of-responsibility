using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Handlers
{
    public class SupervisorHandler : BaseExpenseHandler
    {
        public override void Handle(ExpenseRequest request)
        {
            if (request.Amount <= 100)
            {
                Console.WriteLine("[Supervisor] Analyzing request...");
                
                if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount))
                {
                    Console.WriteLine($"✅ [Supervisor] Expense of R$ {request.Amount:N2} APPROVED");
                    RegisterApproval("Supervisor", request);
                }
                else
                {
                    Console.WriteLine($"❌ [Supervisor] Expense REJECTED - Invalid documentation");
                }
            }
            else
            {
                Console.WriteLine("[Supervisor] Amount exceeds my limit, forwarding...");
                base.Handle(request);
            }
        }
    }
}
