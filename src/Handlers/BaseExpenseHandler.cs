using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Handlers
{
    /// <summary>
    /// Base class for expense handlers. Implements the chain mechanism.
    /// </summary>
    public abstract class BaseExpenseHandler : IExpenseHandler
    {
        protected IExpenseHandler _nextHandler;

        public IExpenseHandler SetNext(IExpenseHandler nextHandler)
        {
            _nextHandler = nextHandler;
            return nextHandler;
        }

        public virtual void Handle(ExpenseRequest request)
        {
            if (_nextHandler != null)
            {
                _nextHandler.Handle(request);
            }
            else
            {
                Console.WriteLine($"\n[WARNING] End of chain: No one could approve the expense of R$ {request.Amount:N2}.");
            }
        }

        protected bool ValidateReceipt(ExpenseRequest request)
        {
            Console.WriteLine("  → Validating receipt...");
            return true;
        }

        protected bool CheckBudget(string department, decimal amount)
        {
            Console.WriteLine($"  → Checking budget for department {department}...");
            return true;
        }

        protected void RegisterApproval(string approver, ExpenseRequest request)
        {
            Console.WriteLine($"  → Registering approval by {approver} for expense of R$ {request.Amount:N2}...");
        }
    }
}
