namespace LoanManagementSystem.Models;

public class Loan
{
    public int LoanID { get; set; }
    public int BorrowerID { get; set; }
    public int LoanAmount { get; set; }
    public int InterestRate { get; set; }
    public int LoanTermInMonths { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public string LoanType { get; set; }
    
}