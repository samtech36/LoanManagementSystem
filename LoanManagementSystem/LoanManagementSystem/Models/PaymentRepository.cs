using Dapper;
using System.Collections.Generic;
using System.Data;

namespace LoanManagementSystem.Models;

public class PaymentRepository : IPaymentRepository
{
    private readonly IDbConnection _conn;

    public PaymentRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Payment> GetAllPayments()
    {
        return _conn.Query<Payment>("SELECT * FROM Payments;");
    }
    
    public Payment GetPayment(int id)
    {
        return _conn.QuerySingleOrDefault<Payment>("SELECT * FROM Payments WHERE PaymentID = @id;", new { id });
    }

    public void UpdatePayment(Payment payment)
    {
        _conn.Execute("UPDATE Payments SET LoanID = @LoanID, PaymentAmount = @PaymentAmount, PaymentDate = @PaymentDate, PaymentMethod = @PaymentMethod WHERE PaymentID = @id;",
            new { loanid = payment.LoanID, paymentamount = payment.PaymentAmount, paymentdate = payment.PaymentDate, paymentmethod = payment.PaymentMethod, id = payment.PaymentID });
    }

    public void InsertPayment(Payment paymentToInsert)
    {
        _conn.Execute("INSERT INTO Payments (LoanID, PaymentAmount, PaymentDate, PaymentMethod) VALUES (@LoanID, @PaymentAmount, @PaymentDate, @PaymentMethod);",
            new { loanid = paymentToInsert.LoanID, paymentamount = paymentToInsert.PaymentAmount, paymentdate = paymentToInsert.PaymentDate, paymentmethod = paymentToInsert.PaymentMethod });
    }

    public void DeletePayment(Payment paymentToDelete)
    {
        _conn.Execute("DELETE FROM Payments WHERE PaymentID = @id;", new { id = paymentToDelete.PaymentID });
    }
}