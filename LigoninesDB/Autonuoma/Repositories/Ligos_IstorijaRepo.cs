namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;



/// <summary>
/// Database operations related to 'Aikstele' entity.
/// </summary>
public class Ligos_IstorijaRepo
{
	public static List<Ligos_Istorija> List()
	{
		var query = $@"SELECT * FROM `ligos_istorijos`";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Ligos_Istorija>(drc, (dre, t) => {
				t.id_Ligos_Istorija = dre.From<int>("id_ligos_istorija");
				t.Susirgimo_Data  = dre.From<DateTime>("susirgimo_data");
			});

		return result;
	}
}