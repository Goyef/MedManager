using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.HtmlConverter;
using System.IO;

namespace ASPBookProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public IActionResult Index()
        {
            return View();
        }

        public string SecondAction(int id)
        {
            return $"({id})^2 = {id * id}";
        }

        public IActionResult ExportToPDF()
        {
            //Initialize HTML to PDF converter.
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
            //Set Blink viewport size.
            blinkConverterSettings.ViewPortSize = new Syncfusion.Drawing.Size(1280, 0);
            //Assign Blink converter settings to HTML converter.
            htmlConverter.ConverterSettings = blinkConverterSettings;
            //Convert URL to PDF document.
            PdfDocument document = htmlConverter.Convert("http://localhost:5245/Home/Index");
            //Create memory stream.
            MemoryStream stream = new MemoryStream();
            //Save and close the document. 
            document.Save(stream);
            document.Close();
            return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "HTML-to-PDF.pdf");

        }
    }
}
