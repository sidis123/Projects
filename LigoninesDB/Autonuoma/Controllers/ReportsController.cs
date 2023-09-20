namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;


using ContractsReport = Org.Ktu.Isk.P175B602.Autonuoma.Models.ContractsReport;



/// <summary>
/// Controller for producing reports.
/// </summary>
public class ReportsController : Controller
{
	/// <summary>
	/// Produces contracts report.
	/// </summary>
	/// <param name="dateFrom">Starting date. Can be null.</param>
	/// <param name="dateTo">Ending date. Can be null.</param>
	/// <returns>Report view.</returns>
	[HttpGet]
	public ActionResult Contracts(DateTime? dateFrom, DateTime? dateTo)
	{
		var report = new ContractsReport.Report();
		report.DateFrom = dateFrom;
		report.DateTo = dateTo?.AddHours(23).AddMinutes(59).AddSeconds(59); //move time of end date to end of day

		report.Daktarai = AtaskaitaRepo.GetContracts(report.DateFrom, report.DateTo);

		foreach (var item in report.Daktarai)
		{
			report.VisoSumaDaktaru++;
		}

		return View(report);
	}
}
