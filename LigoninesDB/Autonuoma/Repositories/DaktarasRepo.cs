namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;



/// <summary>
/// Database operations related to 'Aikstele' entity.
/// </summary>
public class DaktarasRepo
{
	public static List<Daktaras> List()
	{
		var query = $@"SELECT * FROM `daktarai`";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Daktaras>(drc, (dre, t) => {
				t.id_Daktaras = dre.From<int>("id_daktaras");
				t.Vardas = dre.From<string>("vardas");
			});

		return result;
	}
}
