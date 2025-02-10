using System.Data;
using Dapper;


namespace LoanManagementSystem.Models;

public class LoanRepository : ILoanRepository
{
    private readonly IDbConnection _conn;
    
    public LoanRepository(IDbConnection conn)
    {
        _conn = conn;
    }
    
    
    public IEnumerable<Loan> GetAllLoans()
    {
        return _conn.Query<Loan>("SELECT * FROM loans");
    }

    public Loan GetLoan(int id)
    { 
        return _conn.QuerySingleOrDefault<Loan>("SELECT * FROM Loans WHERE LoanID = @id", new { id });
        ;
            
    }

    public void UpdateLoan(Loan loan)
    {

        _conn.Execute("UPDATE Loans SET BorrowerID = @borrowerid, LoanAmount = @loanamount, InterestRate = @interestrate, LoanTermInMonths = @loanterminmonths, StartDate = @startdate, EndDate = @enddate, Status = @status, LoanType = @loantype WHERE LoanID = @id", 
            new { borrowerid = loan.BorrowerID, loanamount = loan.LoanAmount, interestrate = loan.InterestRate, loanterminmonths = loan.LoanTermInMonths, startdate = loan.StartDate, enddate = loan.EndDate, status = loan.Status, loantype = loan.LoanType, id = loan.LoanID });
        
    }

    public void InsertLoan(Loan loanToInsert)
    {
        _conn.Execute("INSERT INTO Loans (BorrowerID, LoanAmount, InterestRate, LoanTermInMonths, StartDate, EndDate, Status, LoanType)  VALUES (@BorrowerID, @LoanAmount, @InterestRate, @LoanTermInMonths, @StartDate, @EndDate, @Status, @LoanType);",
            new { borrowerid = loanToInsert.BorrowerID, loanamount = loanToInsert.LoanAmount, interestrate = loanToInsert.InterestRate, loanterminmonths = loanToInsert.LoanTermInMonths, startdate = loanToInsert.StartDate, enddate = loanToInsert.EndDate, status = loanToInsert.Status, loantype = loanToInsert.LoanType });
    }

    public void DeleteLoan(Loan loanToDelete)
    {
        _conn.Execute("DELETE FROM Loans WHERE LoanID = @id;", new { id = loanToDelete.LoanID });
    }
    
}