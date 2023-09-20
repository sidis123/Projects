namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;


using ContractsReport = Org.Ktu.Isk.P175B602.Autonuoma.Models.ContractsReport;



/// <summary>
/// Database operations related to reports.
/// </summary>
public class AtaskaitaRepo
{
	public static List<ContractsReport.Sutartis> GetContracts(DateTime? dateFrom, DateTime? dateTo)
	{var query = @"
	SELECT
		doc.id_Daktaras,
		doc.NuoKadaDirba,
		doc.Vardas as DVardas,
		doc.Pavarde as DPavarde,
		pac.Vardas,
		pac.Pavarde,
		pac.Gimimo_Data,
		pac.Asmens_Kod,
		bs1.bendra_suma
	FROM
		`pacientai` pac
		INNER JOIN `turi` tur ON tur.fk_PacientasAsmens_Kod = pac.Asmens_Kod
		INNER JOIN `daktarai` doc ON doc.id_Daktaras = tur.fk_Daktarasid_Daktaras
		LEFT JOIN
			(
				SELECT
					pac1.Asmens_Kod,
					IFNULL(COUNT(tur1.fk_PacientasAsmens_Kod), 0) as bendra_suma
				FROM `pacientai` pac1
				INNER JOIN `turi` tur1 ON pac1.Asmens_Kod = tur1.fk_PacientasAsmens_Kod
				WHERE
					pac1.Gimimo_Data >= IFNULL(?nuo, pac1.Gimimo_Data)
					AND pac1.Gimimo_Data <= IFNULL(?iki, pac1.Gimimo_Data)
				GROUP BY pac1.Asmens_Kod
			) AS bs1 ON pac.Asmens_Kod = bs1.Asmens_Kod
	WHERE
		pac.Gimimo_Data >= IFNULL(?nuo, pac.Gimimo_Data)
		AND pac.Gimimo_Data <= IFNULL(?iki, pac.Gimimo_Data)
	GROUP BY 
		doc.id_Daktaras, pac.Asmens_Kod
	ORDER BY 
		pac.Gimimo_Data ASC";
		// var query =
		// 	$@"SELECT
		// 		doc.id_Daktaras,
		// 		doc.NuoKadaDirba,
		// 		doc.Vardas as DVardas,
		// 		doc.Pavarde as DPavarde,
		// 		pac.Vardas,
		// 		pac.Pavarde,
		// 		pac.Asmens_Kod,
		// 		bs1.bendra_suma
		// 	FROM
		// 		`pacientai` pac
		// 		INNER JOIN `turi` tur ON tur.fk_PacientasAsmens_Kod = pac.Asmens_Kod
		// 		INNER JOIN `daktarai` doc ON doc.id_Daktaras = tur.fk_Daktarasid_Daktaras
		// 		LEFT JOIN
		// 			(
		// 				SELECT
		// 					pac1.Asmens_Kod,
		// 					IFNULL(COUNT(tur1.fk_PacientasAsmens_Kod),0) as bendra_suma
		// 				FROM `pacientai` pac1, `turi` tur1
		// 				WHERE
		// 					pac1.Asmens_Kod=tur1.fk_PacientasAsmens_Kod
		// 					AND pac1.Gimimo_Data >= IFNULL(?nuo, pac1.Gimimo_Data)
		// 					AND pac1.Gimimo_Data <= IFNULL(?iki, pac1.Gimimo_Data)
		// 					GROUP BY pac1.Asmens_Kod
		// 			) AS bs1
					
		// 	WHERE
		// 		pac.Gimimo_Data >= IFNULL(?nuo, pac.Gimimo_Data)
		// 		AND pac.Gimimo_Data <= IFNULL(?iki, pac.Gimimo_Data)
		// 	GROUP BY 
		// 		doc.id_Daktaras, pac.Asmens_Kod
		// 	ORDER BY 
		// 		pac.Vardas ASC";

		var drc =
			Sql.Query(query, args => {
				args.Add("?nuo", dateFrom);
				args.Add("?iki", dateTo);
			});

		var result = 
			Sql.MapAll<ContractsReport.Sutartis>(drc, (dre, t) => {
				t.id_Daktaras = dre.From<int>("id_Daktaras");
				t.NuoKadaDirba = dre.From<DateTime>("NuoKadaDirba");
				t.PacGim =dre.From<DateTime>("Gimimo_Data");
				t.DOCVardas = dre.From<string>("DVardas");
				t.DOCPavarde = dre.From<string>("DPavarde");
				t.PACVardas = dre.From<string>("Vardas");
				t.PACPavarde = dre.From<string>("Pavarde");
				t.PACAsmens_Kod = dre.From<string>("Asmens_Kod");
				t.BendraDaktaruSuma = dre.From<int>("bendra_suma");
			});

		return result;
	}
}
