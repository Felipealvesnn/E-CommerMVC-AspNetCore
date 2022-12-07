using LancheMVC_Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LancheMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class AdminRelatorioVendasController : Controller
    {
        private readonly RelatorioVendaService relatorioVendasService;

        public AdminRelatorioVendasController(RelatorioVendaService _relatorioVendasService)
        {
            relatorioVendasService = _relatorioVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioVendasSimples(DateTime? minDate,
           DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await relatorioVendasService.ProcuraDAtaASYNC(minDate, maxDate);
            return View(result);
        }

        //public ActionResult report(string tipo)
        //{
        //    string[] streams = null;
        //    byte[] renderedBytes = null;
        //    string mimeType = "";
        //    //LocalReport lr = new LocalReport();
        //    //lr.EnableExternalImages = true;
        //    try
        //    {


        //        ReportViewer rpv = new ReportViewer();
        //        rpv.ShowParameterPrompts = true;
        //        rpv.ProcessingMode = ProcessingMode.Local;
        //        rpv.LocalReport.EnableExternalImages = true;

        //      //  string path = Path.Combine(Server.MapPath("~/Reports"), "HistoricoAnalitico.rdlc");
        //  //      if (System.IO.File.Exists(path))
        //        {
        //     //       rpv.LocalReport.ReportPath = path;

        //       //     var localImagemEsquerda = Path.Combine(Server.MapPath("~/Content/imagens"), "logoAzul.png");
        //       //     var localImagemDireita = Path.Combine(Server.MapPath("~/Content/imagens"), "logoAzul.png");
        //            ReportParameter imgLogoEsq = new ReportParameter("imgLogoEsq", string.Concat("file:///", localImagemEsquerda));
        //            ReportParameter imgLogoDir = new ReportParameter("imgLogoDir", string.Concat("file:///", localImagemDireita));
        //            ReportParameter observacoes = new ReportParameter("observacoes", "");
        //          //  ReportParameter empresa = new ReportParameter("empTitulo1", Sessao.EmpresaNome);
        //            var p = TempData["filtro"].ToString();
        //            ReportParameter pepriodo = new ReportParameter("filtro", p);

        //            rpv.LocalReport.SetParameters(new ReportParameter[] { imgLogoEsq });
        //            rpv.LocalReport.SetParameters(new ReportParameter[] { imgLogoDir });
        //            rpv.LocalReport.SetParameters(new ReportParameter[] { observacoes });
        //            rpv.LocalReport.SetParameters(new ReportParameter[] { empresa });
        //            rpv.LocalReport.SetParameters(new ReportParameter[] { pepriodo });
        //        }
        //        else
        //        {
        //            return View("Index");
        //        }




        //      //  var todos = (List<HistoricoEstacionamento>)TempData["dados"];



        //    //    var ordenado = todos.OrderBy(x => x.dataEvento);

        //  //      TempData["dados"] = ordenado;

        //     //   ReportDataSource rd = new ReportDataSource("DsDados", ordenado);

        //        rpv.LocalReport.DataSources.Add(rd);
        //        string reportType = tipo;

        //        string encoding;
        //        string fileNameExtension;


        //        string deviceInfo =
        //        "<DeviceInfo>" +
        //        "  <OutputFormat>" + tipo + "</OutputFormat>" +
        //        "  <PageWidth>8.5in</PageWidth>" +
        //        "  <PageHeight>11in</PageHeight>" +
        //        "  <MarginTop>0.2in</MarginTop>" +
        //        "  <MarginLeft>0.2in</MarginLeft>" +
        //        "  <MarginRight>0.2in</MarginRight>" +
        //        "  <MarginBottom>0.2in</MarginBottom>" +
        //        "   <EmbedFonts>None</EmbedFonts>" +
        //        "</DeviceInfo>";

        //        Warning[] warnings;


        //        renderedBytes = rpv.LocalReport.Render(
        //            reportType,
        //            deviceInfo,
        //            out mimeType,
        //            out encoding,
        //            out fileNameExtension,
        //            out streams,
        //            out warnings);

        //        return File(renderedBytes, mimeType);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return File(renderedBytes, mimeType);
        //}


    }
}
