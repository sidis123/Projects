namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.ContractsReport;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


/// <summary>
/// View model for single contract in a report.
/// </summary>
public class Sutartis
{
	[DisplayName("Daktaro ID")]
	public int id_Daktaras { get; set; }

	[DisplayName("Nuo kada dirba")]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime NuoKadaDirba { get; set; }

	[DisplayName("Daktaro Vardas")]
	public string DOCVardas { get; set; }

	[DisplayName("Daktaro Pavarde")]
	public string DOCPavarde { get; set; }

	public string PACVardas { get; set; }
	public string PACPavarde { get; set; }

	[DisplayName("| Gimimo data |")]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime PacGim { get; set; }

	public string PACAsmens_Kod { get; set; }

	public int BendraDaktaruSuma { get; set; }
}

/// <summary>
/// View model for whole report.
/// </summary>
public class Report
{
	[DataType(DataType.DateTime)]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime? DateFrom { get; set; }

	[DataType(DataType.DateTime)]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime? DateTo { get; set; }

	public List<Sutartis> Daktarai { get; set; }

	public int VisoSumaDaktaru { get; set; }

}
