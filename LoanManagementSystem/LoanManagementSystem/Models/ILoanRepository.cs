using System;
using System.Collections.Generic;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Models;

public interface ILoanRepository
{
    IEnumerable<Loan> GetAllLoans();
    
    //View Loans
    public Loan GetLoan(int id);
    
    //Update Loans
    void UpdateLoan(Loan loan);
    
    //Insert Loan
    void InsertLoan(Loan loanToInsert);
    
    //Delete Loan
    void DeleteLoan(Loan loanToDelete);
}