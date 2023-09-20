namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.PacientasF2;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// 'Pacientas' in list form.
/// </summary>
public class PacientasL
{
	[DisplayName("Asmens Kodas")]
	public string Asmens_Kod { get; set; }

	[DisplayName("Paciento Vardas")]
	[Required]
	public string Vardas { get; set; }

	[DisplayName("Paciento Pavarde")]
	[Required]
	public string Pavarde { get; set; }

	[DisplayName("Sesele")]
	[Required]
	public string Sesele { get; set; }

}


/// <summary>
/// 'Pacientas' in create and edit forms.
/// </summary>
public class PacientasCE
{
	/// <summary>
	/// Entity data.
	/// </summary>
	public class PacientasM
	{
		[DisplayName("Vardas")]
		[Required]
		public string Vardas { get; set; }

		[DisplayName("Pavarde")]
		[Required]
		public string Pavarde { get; set; }

		[DisplayName("Gimimo_Data")]
		[Required]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime Gimimo_Data { get; set; }

		[DisplayName("Diabetiskumas")]
		[Required]
		public bool Diabetikas{get; set;}

		[DisplayName("Adresas")]
		[Required]
		public string Adresas {get;set;}

		[DisplayName("Telefonas")]
		[Required]
		public string Telefonas { get; set; }

		[DisplayName("Asmens Kodas")]
		[Required]
		public string Asmens_Kod { get; set; }

		[DisplayName("Elektroninis paštas")]
		[EmailAddress]
		[Required]
		public string El_Pastas { get; set; }

		[DisplayName("Sesele")]
		[Required]
		public int fk_Seseleid_Sesele { get; set; }
		
	}

	/// <summary>
	/// Representation of 'UzsakytaPaslauga' entity in 'Sutartis' edit form.
	/// </summary>
	public class PriskirtasDaktarasM
	{
		/// <summary>
		/// ID of the record in the form. Is used when adding and removing records.
		/// </summary>
		public int InListId { get; set; }

		[DisplayName("Daktaro Vardas")]
		[Required]
		public int? Daktaras { get; set; }
	}

	/// <summary>
	/// Select lists for making drop downs for choosing values of entity fields.
	/// </summary>
	public class ListsM
	{
		public IList<SelectListItem> Seseles { get; set; }
		public IList<SelectListItem> Daktarai {get;set;}
		public IList<SelectListItem> SusirgimoDatos {get;set;}
		public IList<(int Id, string Name)> SeselesWithId { get; set; } = new List<(int Id, string Name)>();

	}


	/// <summary>
	/// Sutartis.
	/// </summary>
	public PacientasM Pacientai { get; set; } = new PacientasM();

	/// <summary>
	/// Related 'UzsakytaPaslauga' records.
	/// </summary>
	public IList<PriskirtasDaktarasM> PriskirtiDaktarai { get; set;  } = new List<PriskirtasDaktarasM>();

	/// <summary>
	/// Lists for drop down controls.
	/// </summary>
	public ListsM Lists { get; set; } = new ListsM();
}
