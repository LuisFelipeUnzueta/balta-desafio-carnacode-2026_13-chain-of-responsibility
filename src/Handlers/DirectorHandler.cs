using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Handlers
{
    public class DirectorHandler : BaseExpenseHandler
    {
        public override void Handle(ExpenseRequest request)
        {
            if (request.Amount <= 5000)
            {
                Console.WriteLine("[Director] Analyzing request...");
                
                if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount) && 
                    CheckPolicy(request) && CheckStrategicAlignment(request))
                {
                    Console.WriteLine($"✅ [Director] Expense of R$ {request.Amount:N2} APPROVED");
                    RegisterApproval("Director", request);
                }
                else
                {
                    Console.WriteLine($"❌ [Director] Expense REJECTED");
                }
            }
            else
            {
                Console.WriteLine("[Director] Amount exceeds my limit, forwarding...");
                base.Handle(request);
            }
        }

        private bool CheckPolicy(ExpenseRequest request)
        {
            Console.WriteLine("  → Checking policy compliance...");
            return true;
        }

        private bool CheckStrategicAlignment(ExpenseRequest request)
        {
            Console.WriteLine("  → Checking strategic alignment...");
            return true;
        }
    }
}
