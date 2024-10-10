using System;
using System.Collections.Generic;
using LoanManagementSystem.Models;


namespace LoanManagementSystem.Models;

public interface IBorrowerRepository
{
    IEnumerable<Borrower> GetAllBorrowers();
    
    //View Borrower
    public Borrower GetBorrower(int id);
    
    //Update Borrower
    public void UpdateBorrower(Borrower borrowerToUpdate);
    
    //Add Borrower
    public void InsertBorrower(Borrower borrowerToInsert);
    
    //Delete Borrower
    public void DeleteBorrower(Borrower borrowerToDelete);

}