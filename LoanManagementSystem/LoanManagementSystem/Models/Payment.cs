namespace LoanManagementSystem.Models;

public class Payment
{
    public int PaymentID { get; set; }
    public int LoanID { get; set; }
    public decimal PaymentAmount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; }
    
 
    
}