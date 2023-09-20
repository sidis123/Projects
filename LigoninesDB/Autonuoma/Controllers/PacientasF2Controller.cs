namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.PacientasF2;


/// <summary>
/// Controller for working with 'Sutartis' entity. Implementation of F2 version.
/// </summary>
public class PacientasF2Controller : Controller
{
	/// <summary>
	/// This is invoked when either 'Index' action is requested or no action is provided.
	/// </summary>
	/// <returns>Entity list view.</returns>
	[HttpGet]
	public ActionResult Index()
	{
		return View(PacientasF2Repo.List());
	}

	/// <summary>
	/// This is invoked when creation form is first opened in a browser.
	/// </summary>
	/// <returns>Entity creation form.</returns>
	[HttpGet]
	public ActionResult Create()
	{
		var pacCE = new PacientasCE();
		
		PopulateLists(pacCE);

		return View(pacCE);
	}


	/// <summary>
	/// This is invoked when buttons are pressed in the creation form.
	/// </summary>
	/// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
	/// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
	/// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
	/// <param name="sutCE">Entity view model filled with latest data.</param>
	/// <returns>Returns creation from view or redirets back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Create(int? save, int? add, int? remove, PacientasCE pacCE)
	{
		//addition of new 'UzsakytosPaslaugos' record was requested?
		if( add != null )
		{
			//add entry for the new record
			var up =
				new PacientasCE.PriskirtasDaktarasM {
					InListId =
						pacCE.PriskirtiDaktarai.Count > 0 ?
						pacCE.PriskirtiDaktarai.Max(it => it.InListId) + 1 :
						0,

					Daktaras = null
				};
			pacCE.PriskirtiDaktarai.Add(up);

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(pacCE);
			return View(pacCE);
		}

		//removal of existing 'UzsakytosPaslaugos' record was requested?
		if( remove != null )
		{
			//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
			pacCE.PriskirtiDaktarai =
				pacCE
					.PriskirtiDaktarai
					.Where(it => it.InListId != remove.Value)
					.ToList();

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(pacCE);
			return View(pacCE);
		}

		//save of the form data was requested?
		if( save != null )
		{
			ModelState.Clear();
			//check for attemps to create duplicate 'UzsakytaPaslauga'records
			for ( var i = 0; i < pacCE.PriskirtiDaktarai.Count-1; i ++ )
			{
				var refUp = pacCE.PriskirtiDaktarai[i];

				for( var j = i+1; j < pacCE.PriskirtiDaktarai.Count; j++ )
				{
					var testUp = pacCE.PriskirtiDaktarai[j];
					
					if( testUp.Daktaras == refUp.Daktaras )
						ModelState.AddModelError($"PriskirtiDaktarai[{j}].Daktaras", "Duplicate of another added service.");
				}
			}
			//ModelState.Clear();
			//form field validation passed?
			if( ModelState.IsValid )
			{
				//create new 'Sutartis'
				pacCE.Pacientai.Asmens_Kod = PacientasF2Repo.InsertPacientas(pacCE);

				//create new 'UzsakytosPaslaugos' records
				foreach( var upVm in pacCE.PriskirtiDaktarai )
					PacientasF2Repo.InsertPacientasDaktaras(pacCE.Pacientai.Asmens_Kod, upVm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			//form field validation failed, go back to the form
			else
			{
				PopulateLists(pacCE);
				return View(pacCE);
			}
		}

		//should not reach here
		throw new Exception("Should not reach here.");
	}

	/// <summary>
	/// This is invoked when editing form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to edit.</param>
	/// <returns>Editing form view.</returns>
	[HttpGet]
	public ActionResult Edit(string id)
	{
		var pacCE = PacientasF2Repo.FindPacientas(id);
		
		pacCE.PriskirtiDaktarai = PacientasF2Repo.ListPriskirtasDaktaras(id);			
		PopulateLists(pacCE);

		return View(pacCE);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the editing form.
	/// </summary>
	/// <param name="id">ID of the entity being edited</param>
	/// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
	/// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
	/// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
	/// <param name="sutCE">Entity view model filled with latest data.</param>
	/// <returns>Returns editing from view or redired back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Edit(int id, int? save, int? add, int? remove, PacientasCE pacCE)
	{
		//addition of new 'UzsakytosPaslaugos' record was requested?
		if( add != null )
		{
			//add entry for the new record
			var up =
				new PacientasCE.PriskirtasDaktarasM {
					InListId =
						pacCE.PriskirtiDaktarai.Count > 0 ?
						pacCE.PriskirtiDaktarai.Max(it => it.InListId) + 1 :
						0,

					Daktaras = null,
				};
			pacCE.PriskirtiDaktarai.Add(up);

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(pacCE);
			return View(pacCE);
		}

		//removal of existing 'UzsakytosPaslaugos' record was requested?
		if( remove != null )
		{
			//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
			pacCE.PriskirtiDaktarai =
				pacCE
					.PriskirtiDaktarai
					.Where(it => it.InListId != remove.Value)
					.ToList();

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(pacCE);
			return View(pacCE);
		}

		//save of the form data was requested?
		if( save != null )
		{
			//check for attemps to create duplicate 'UzsakytaPaslauga'records
			for( var i = 0; i < pacCE.PriskirtiDaktarai.Count-1; i ++ )
			{
				var refUp = pacCE.PriskirtiDaktarai[i];

				for( var j = i+1; j < pacCE.PriskirtiDaktarai.Count; j++ )
				{
					var testUp = pacCE.PriskirtiDaktarai[j];
					
					if( testUp.Daktaras == refUp.Daktaras )
						ModelState.AddModelError($"PriskirtiDaktarai[{j}].Daktaras", "Duplicate of another added song.");
				}
			}

			//form field validation passed?
			if( ModelState.IsValid )
			{
				//update 'Sutartis'
				PacientasF2Repo.UpdatePacientas(pacCE);

				//delete all old 'UzsakytosPaslaugos' records
				PacientasF2Repo.DeleteFromTuri(pacCE.Pacientai.Asmens_Kod);

				//create new 'UzsakytosPaslaugos' records
				foreach( var upVm in pacCE.PriskirtiDaktarai )
					PacientasF2Repo.InsertPacientasDaktaras(pacCE.Pacientai.Asmens_Kod, upVm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			//form field validation failed, go back to the form
			else
			{
				PopulateLists(pacCE);
				return View(pacCE);
			}
		}

		//should not reach here
		throw new Exception("Should not reach here.");
	}

	/// <summary>
	/// This is invoked when deletion form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view.</returns>
	[HttpGet]
	public ActionResult Delete(string id)
	{
		var pacCE = PacientasF2Repo.FindPacientas(id);
		return View(pacCE);
	}

	/// <summary>
	/// This is invoked when deletion is confirmed in deletion form
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view on error, redirects to Index on success.</returns>
	[HttpPost]
	public ActionResult DeleteConfirm(string id)
	{
		var pacCE = PacientasF2Repo.FindPacientas(id);

		PacientasF2Repo.DeleteFromTuri(id);

		PacientasF2Repo.DeletePacientas(id);

		return RedirectToAction("Index");
	}

	/// <summary>
	/// Populates select lists used to render drop down controls.
	/// </summary>
	/// <param name="sutCE">'Sutartis' view model to append to.</param>
	private void PopulateLists(PacientasCE pacCE)
	{
		var daktarai = DaktarasRepo.List();
		var istorijos = Ligos_IstorijaRepo.List();
		var seseles = SeseleRepo.List();

		//build select lists
		pacCE.Lists.Daktarai =
			daktarai
				.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.id_Daktaras),
							Text = $"{it.Vardas}"
						};
				})
				.ToList();

		pacCE.Lists.SusirgimoDatos =
			istorijos
				.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.id_Ligos_Istorija),
							Text = it.Susirgimo_Data.ToString()
						};
				})
				.ToList();

		pacCE.Lists.Seseles =
			seseles
				.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.ID),
							Text = $"{it.Vardas}"
						};
				})
				.ToList();

	}
}

		
			
		
	

