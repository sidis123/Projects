namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;



/// <summary>
/// Database operations related to 'Aikstele' entity.
/// </summary>
public class SeseleRepo
{
	public static List<Sesele> List()
	{
		var query = $@"SELECT * FROM `seseles`";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Sesele>(drc, (dre, t) => {
				t.ID = dre.From<int>("id_Sesele");
				t.Vardas = dre.From<string>("vardas");
			});

		return result;
	}
}