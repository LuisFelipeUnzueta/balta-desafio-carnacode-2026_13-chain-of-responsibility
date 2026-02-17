using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Handlers
{
    public class CEOHandler : BaseExpenseHandler
    {
        public override void Handle(ExpenseRequest request)
        {
            Console.WriteLine("[CEO] Analyzing high-value request...");
            
            if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount) && 
                CheckPolicy(request) && CheckStrategicAlignment(request) && CheckBoardApproval(request))
            {
                Console.WriteLine($"✅ [CEO] Expense of R$ {request.Amount:N2} APPROVED");
                RegisterApproval("CEO", request);
            }
            else
            {
                Console.WriteLine($"❌ [CEO] Expense REJECTED");
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

        private bool CheckBoardApproval(ExpenseRequest request)
        {
            Console.WriteLine("  → Checking board approval...");
            return true;
        }
    }
}
