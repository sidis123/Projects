namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Klientas' entity.
/// </summary>
public class Sesele
{
	[DisplayName("ID")]
	[Required]
	public int ID { get; set; }

	[DisplayName("Vardas")]
	[Required]
	public string Vardas { get; set; }

}
