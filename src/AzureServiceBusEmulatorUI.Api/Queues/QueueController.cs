using Microsoft.AspNetCore.Mvc;

namespace AzureServiceBusEmulatorUI.Api.Controllers;

public class QueueController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
