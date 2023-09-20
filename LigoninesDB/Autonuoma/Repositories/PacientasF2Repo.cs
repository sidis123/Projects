namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Models.PacientasF2;


/// <summary>
/// Database operations related to 'Sutartis' entity.
/// </summary>
public class PacientasF2Repo
{
	public static List<PacientasL> List()
	{
		var query =
			$@"SELECT
				p.Asmens_Kod as Asmens_Kod,
				p.vardas as vardas,
				p.pavarde as pavarde,
				CONCAT(s.id_Sesele,' ',s.vardas) as sesele
			FROM
				`pacientai` p
				LEFT JOIN `seseles` s ON p.fk_Seseleid_Sesele=s.id_Sesele
			ORDER BY p.Asmens_Kod DESC";

		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<PacientasL>(drc, (dre, t) => {
				t.Asmens_Kod = dre.From<string>("Asmens_Kod");
				t.Vardas = dre.From<string>("vardas");
				t.Pavarde = dre.From<string>("pavarde");
				t.Sesele = dre.From<string>("sesele");
			});

		return result;
	}

	public static PacientasCE FindPacientas(string nr)
	{
		var query = $@"SELECT * FROM `pacientai` WHERE Asmens_Kod=?nr";
		var drc =
			Sql.Query(query, args => {
				args.Add("?nr", nr);
			});

		var result =
			Sql.MapOne<PacientasCE>(drc, (dre, t) => {
				//make a shortcut
				var pac = t.Pacientai;
				pac.Asmens_Kod = nr;
				pac.Adresas = dre.From<string>("Adresas");
				pac.Diabetikas = dre.From<bool>("Diabetikas");
				pac.El_Pastas = dre.From<string>("El_Pastas");
				pac.Gimimo_Data = dre.From<DateTime>("Gimimo_Data");
				pac.Pavarde = dre.From<string>("Pavarde");
				pac.Telefonas = dre.From<string>("Telefonas");
				pac.Vardas = dre.From<string>("Vardas");
				pac.fk_Seseleid_Sesele=dre.From<int>("fk_Seseleid_Sesele");
			});

		return result;
	}

	public static string InsertPacientas(PacientasCE pacCE)
	{
		var query =
			$@"INSERT INTO `pacientai`
			(
				`Asmens_Kod`,
				`Vardas`,
				`Pavarde`,
				`Adresas`,
				`Diabetikas`,
				`Telefonas`,
				`El_Pastas`,
				`Gimimo_Data`,
				`fk_Seseleid_Sesele`
				
			)
			VALUES(
				?kod,
				?vardas,
				?pavarde,
				?adresas,
				?diabetikas,
				?tel,
				?elP,
				?data,
				?ses
				
			)";

		
			Sql.Insert(query, args => {
				//make a shortcut
				var pac = pacCE.Pacientai;
				args.Add("?kod",pac.Asmens_Kod);
				args.Add("?vardas", pac.Vardas);
				args.Add("?pavarde", pac.Pavarde);
				args.Add("?adresas", pac.Adresas);
				args.Add("?diabetikas", pac.Diabetikas);
				args.Add("?tel", pac.Telefonas);
				args.Add("?elP", pac.El_Pastas);
				args.Add("?data", pac.Gimimo_Data);
				args.Add("?ses",pac.fk_Seseleid_Sesele);
			});

		return pacCE.Pacientai.Asmens_Kod;
	}

	public static void UpdatePacientas(PacientasCE pacCE)
	{
		var query =
			$@"UPDATE `pacientai`
			SET
				`Vardas` = ?vardas,
				`Pavarde` = ?pavarde,
				`Gimimo_Data` = ?data,
				`Diabetikas` = ?diabetikas,
				`Adresas` = ?adresas,
				`Telefonas` = ?tel,
				`El_Pastas` = ?elP,
				`fk_Seseleid_Sesele` = ?ses
				
			WHERE Asmens_Kod=?nr";

			

		Sql.Update(query, args => {
			//make a shortcut
			var pac = pacCE.Pacientai;

			//
				args.Add("?vardas", pac.Vardas);
				args.Add("?pavarde", pac.Pavarde);
				args.Add("?adresas", pac.Adresas);
				args.Add("?diabetikas", pac.Diabetikas);
				args.Add("?tel", pac.Telefonas);
				args.Add("?elP", pac.El_Pastas);
				args.Add("?data", pac.Gimimo_Data);
				args.Add("?ses",pac.fk_Seseleid_Sesele);
				args.Add("?nr", pac.Asmens_Kod);
		});
	}

	public static void DeletePacientas(string nr)
	{
		var query = $@"DELETE FROM `pacientai` where Asmens_Kod=?nr";
		Sql.Delete(query, args => {
			args.Add("?nr", nr);
		});
	}

	public static List<PacientasCE.PriskirtasDaktarasM> ListPriskirtasDaktaras(string pacId)
	{
		var query =
			$@"SELECT *
			FROM `turi`
			WHERE fk_PacientasAsmens_Kod = ?pacID";

		var drc =
			Sql.Query(query, args => {
				args.Add("?pacID", pacId);
			});

		var result =
			Sql.MapAll<PacientasCE.PriskirtasDaktarasM>(drc, (dre, t) => {
				t.Daktaras = dre.From<int>("fk_Daktarasid_Daktaras");
			});

		for( int i = 0; i < result.Count; i++ )
			result[i].InListId = i;

		return result;
	}

	public static void InsertPacientasDaktaras(string pacId, PacientasCE.PriskirtasDaktarasM up)
	{
		var query =
			$@"INSERT INTO `turi`
				(
					fk_Daktarasid_Daktaras,
					fk_PacientasAsmens_Kod
				)
				VALUES(
					?fk_dokId,
					?fk_pacId
				)";

		Sql.Insert(query, args => {
			args.Add("?fk_pacId", pacId);
			args.Add("?fk_dokId", up.Daktaras);
		});
	}

	public static void DeleteFromTuri(string pacientas)
	{
		var query =
			$@"DELETE FROM a
			USING `turi` as a
			WHERE a.fk_PacientasAsmens_Kod=?id";

		Sql.Delete(query, args => {
			args.Add("?id", pacientas);
		});
	}
}