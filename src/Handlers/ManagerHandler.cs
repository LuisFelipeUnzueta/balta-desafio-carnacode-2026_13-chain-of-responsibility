using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Handlers
{
    public class ManagerHandler : BaseExpenseHandler
    {
        public override void Handle(ExpenseRequest request)
        {
            if (request.Amount <= 500)
            {
                Console.WriteLine("[Manager] Analyzing request...");
                
                if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount) && 
                    CheckPolicy(request))
                {
                    Console.WriteLine($"✅ [Manager] Expense of R$ {request.Amount:N2} APPROVED");
                    RegisterApproval("Manager", request);
                }
                else
                {
                    Console.WriteLine($"❌ [Manager] Expense REJECTED");
                }
            }
            else
            {
                Console.WriteLine("[Manager] Amount exceeds my limit, forwarding...");
                base.Handle(request);
            }
        }

        private bool CheckPolicy(ExpenseRequest request)
        {
            Console.WriteLine("  → Checking policy compliance...");
            return true;
        }
    }
}
