using Microsoft.AspNetCore.Mvc;
using LoanManagementSystem.Models;
using ZstdSharp.Unsafe;


namespace LoanManagementSystem.Controllers;

public class LoanController : Controller
{
    
    private readonly ILoanRepository repo;

    public LoanController(ILoanRepository repo)
    {
        this.repo = repo;
    }


    public IActionResult Index()
    {
        var loans = repo.GetAllLoans();
        return View(loans);
    }
    
    //view Loans
    public IActionResult ViewLoan(int id)
    {
        var loan = repo.GetLoan(id);
        return View(loan);
    }

    
    //Update Loans
    public IActionResult UpdateLoan(int id)
    {
        Loan loan = repo.GetLoan(id);
        if (loan == null)
        {
            return View("LoanNotFound");
        }
        return View(loan);
    }


    public IActionResult UpdateLoanToDatabase(Loan loan)
    {
        repo.UpdateLoan(loan);
        return RedirectToAction("ViewLoan", new { id = loan.LoanID });
    }

    public IActionResult InsertLoan()
    {
        return View(new Loan());
        
    }
    

    public IActionResult InsertLoanToDatabase(Loan loanToInsert)
    {
        repo.InsertLoan(loanToInsert);
        return RedirectToAction("Index");

    }

    public IActionResult DeleteLoan(Loan loanToDelete)
    {
        repo.DeleteLoan(loanToDelete);
        return RedirectToAction("Index");
    }








}
