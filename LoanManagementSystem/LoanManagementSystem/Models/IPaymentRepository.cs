using System;
using System.Collections.Generic;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Models;

public interface IPaymentRepository
{
    IEnumerable<Payment> GetAllPayments();
    
    //View Payments
    Payment GetPayment(int id);
    
    //Update Payments
    void UpdatePayment(Payment payment);
    
    //Insert Payments
    void InsertPayment (Payment paymentToInsert);
    
    //Delete Payments
    public void DeletePayment(Payment paymentToDelete);
}