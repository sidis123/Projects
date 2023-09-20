namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Klientas' entity.
/// </summary>
public class Daktaras
{
	[DisplayName("ID")]
	[Required]
	public int id_Daktaras { get; set; }

	[DisplayName("Daktaro Vardas")]
	[Required]
	public string Vardas { get; set; }
}
