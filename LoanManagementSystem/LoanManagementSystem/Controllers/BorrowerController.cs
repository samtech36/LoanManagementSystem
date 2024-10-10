using Microsoft.AspNetCore.Mvc;
using LoanManagementSystem.Models;
using ZstdSharp.Unsafe;


namespace LoanManagementSystem.Controllers;

public class BorrowerController: Controller
{
    private readonly IBorrowerRepository repo;

    public BorrowerController(IBorrowerRepository repo)
    {
        this.repo = repo;
    }


    public IActionResult Index()
    {
        var borrowers = repo.GetAllBorrowers();
        return View(borrowers);
    }

    //view borrowers
    public IActionResult ViewBorrower(int id)
    {
        var borrower = repo.GetBorrower(id);
        return View(borrower);
    }
    
    //Update borrowers
    public IActionResult UpdateBorrower(int id)
    {
        Borrower borrow = repo.GetBorrower(id);
        if (borrow == null)
        {
            return View("BorrowerNotFound");
        }

        return View(borrow);
    }

    public IActionResult UpdateBorrowerToDatabase(Borrower borrower)
    {
        if (ModelState.IsValid)
        {
            repo.UpdateBorrower(borrower);
            return RedirectToAction("ViewBorrower", new { id = borrower.BorrowerID });
        }
        return View(borrower);
    }
    
    public IActionResult InsertBorrower()
    {
        return View();
    }

    public IActionResult InsertBorrowerToDatabase(Borrower borrowerToInsert)
    {
        repo.InsertBorrower(borrowerToInsert);
        return RedirectToAction("Index");
    }

    public IActionResult DeleteBorrower(Borrower borrowerToDelete)
    {
        repo.DeleteBorrower(borrowerToDelete);
        return RedirectToAction("Index");
        
    }
    

}
