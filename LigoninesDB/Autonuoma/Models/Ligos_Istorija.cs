namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Klientas' entity.
/// </summary>
public class Ligos_Istorija
{
	[DisplayName("ID")]
	[Required]
	public int id_Ligos_Istorija { get; set; }

	[DisplayName("Susirgimo_Data")]
	[Required]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
	public DateTime Susirgimo_Data { get; set; }
}
