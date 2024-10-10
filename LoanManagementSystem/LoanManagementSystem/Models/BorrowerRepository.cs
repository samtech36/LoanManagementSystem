using System.Data;
using Dapper;

namespace LoanManagementSystem.Models;

public class BorrowerRepository : IBorrowerRepository
{
    private readonly IDbConnection _conn;

    public BorrowerRepository(IDbConnection conn)
    {
        _conn = conn;
    }
    
    
    public IEnumerable<Borrower> GetAllBorrowers()
    {
        return _conn.Query<Borrower>("SELECT * FROM borrowers");
    }

    public Borrower GetBorrower(int id)
    {
        return _conn.QuerySingle<Borrower>("SELECT * FROM borrowers WHERE BorrowerID = @id", new { id = id });

    }

    public void UpdateBorrower(Borrower borrower)
    {
        _conn.Execute("UPDATE borrowers SET FirstName = @firstname, LastName = @lastname, Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address WHERE BorrowerID = @id", 
            new {firstname = borrower.FirstName, lastname = borrower.LastName, email = borrower.Email, phonenumber = borrower.PhoneNumber, address = borrower.Address, id = borrower.BorrowerID});
    }

    public void InsertBorrower(Borrower borrowerToInsert)
    {
        _conn.Execute("INSERT INTO Borrowers (FirstName, LastName, Email, PhoneNumber, Address) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Address);",
            new {firstname = borrowerToInsert.FirstName, lastname = borrowerToInsert.LastName, email = borrowerToInsert.Email, phonenumber = borrowerToInsert.PhoneNumber, address = borrowerToInsert.Address, id = borrowerToInsert.BorrowerID});
    }

    public void DeleteBorrower(Borrower borrowerToDelete)
    {
        _conn.Execute("DELETE FROM Borrowers WHERE BorrowerID = @id;", new { id = borrowerToDelete.BorrowerID });
    }
}

