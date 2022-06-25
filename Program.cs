using System;

using System.Linq;

using System.Dynamic;

using System.Collections.Generic;

using System.Text;

using System.Reflection;

using System.Data;

using Newtonsoft.Json;

namespace Utilityclass

{
//this class was ised to test methods into console app
	public static class Program

	{

		public static void Main()

		{

			List<string> headerList = new List<string>()

			{        "Id","Name","Rollno","Class", "Buisness"

			};

			List<List<string>> dataList = new List<List<string>>(){

				new List<string> (){ "190", "adeel","420","A","IT"},

				new List<string> (){ "191", "alI","320","A","Hoteling" }

			};



			OwnLib ownLib = new OwnLib();

			var res = ownLib.GenerateListofDynamicObjects(headerList, dataList);

			//var xx = res.Any(r => r.id == "190");

			Console.WriteLine("Type of List " + res.GetType().BaseType);

			var dt = ownLib.ListOfObjectsToDataTable(res);

			for (int row = 0; row < dt.Rows.Count; row++)

			{

			Console.WriteLine("\nDATA NO : "+row);

	

               for (int col = 0; col < dt.Columns.Count; col++)

			{



				Console.WriteLine(dt.Columns[col] + " : " + dt.Rows[row][col]);



			}



			}



		}

	}


//comversion methods 
	public class OwnLib

	{





		public List<dynamic> GenerateListofDynamicObjects(List<string> headerList, List<List<string>> dataList)

		{

			List<object> dataObjs = new List<object>();

			for (int i = 0; i < dataList.Count; i++)

			{

				var expando = new ExpandoObject() as IDictionary<string, object>;





				for (int x = 0; x < headerList.Count; x++)

				{

					expando.Add(headerList[x], dataList[i][x]);

				}

				dataObjs.Add(expando);

			}

			dynamic z = dataObjs;

			return z;



		}



		public DataTable ListOfObjectsToDataTable(List<object> listOfObjects)

		{

			var json = JsonConvert.SerializeObject(listOfObjects);

			DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));



			return dt;

		}



	}









}
