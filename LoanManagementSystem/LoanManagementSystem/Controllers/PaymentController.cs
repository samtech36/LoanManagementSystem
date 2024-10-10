using LoanManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;


namespace LoanManagementSystem.Controllers;

public class PaymentController : Controller
{
    private readonly IPaymentRepository repo;

    public PaymentController(IPaymentRepository repo)
    {
        this.repo = repo;
    }

    // Display a list of all payments
    public IActionResult Index()
    {
        var payments = repo.GetAllPayments();
        return View(payments);
    }
    
    
    //view Loans
    public IActionResult ViewPayment(int id)
    {
        var payment = repo.GetPayment(id);
        return View(payment);
    }
    
    //Update Loans
    public IActionResult UpdatePayment(int id)
    {
        var payment = repo.GetPayment(id);
        if (payment == null)
        {
            return View("PaymentNotFound");
        }
        return View(payment);
    }

    public IActionResult UpdatePaymentToDatabase(Payment payment)
    {
        repo.UpdatePayment(payment);
        return RedirectToAction("ViewPayment", new {id = payment.PaymentID});
    }

    public IActionResult InsertPayment()
    {
        return View(new Payment());
    }

    public IActionResult InsertPaymentToDatabase(Payment paymentToInsert)
    {
        repo.InsertPayment(paymentToInsert);
        return RedirectToAction("Index");
    }

    public IActionResult DeletePayment(Payment paymentToDelete)
    {
        repo.DeletePayment(paymentToDelete);
        return RedirectToAction("Index");
    }
    
    

}