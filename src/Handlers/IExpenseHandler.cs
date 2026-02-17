using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Handlers
{
    /// <summary>
    /// Interface for expense approval handlers in the Chain of Responsibility.
    /// </summary>
    public interface IExpenseHandler
    {
        IExpenseHandler SetNext(IExpenseHandler nextHandler);
        void Handle(ExpenseRequest request);
    }
}
