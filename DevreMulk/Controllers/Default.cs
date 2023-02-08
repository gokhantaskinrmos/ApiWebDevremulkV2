using DevreMulk.DataAccesLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

namespace DevreMulk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Default : ControllerBase
    {
        [HttpPost]//Hatalık Toplam Çağrı Sayısı
        [Route("stringtipinde")]
        public IActionResult GunlukKullaniciSkoru(GunlukSkorModel model)
        {
            using var c = new Context();//
            //var values = c.Sorunlar.ToList();//
            string query = @"exec Dev_DonemCizelgesiGrup @Baslangic='" + model.Baslangic + @"',
@Bitis='" + model.Bitis + @"',@SadeceMusaitDonemler='"+ model.SadeceMusaitDonemler + @"',@Donemler='"+ model.Donemler + @"',
@Oda_Tipi='"+ model.Oda_Tipi+ @"',@Sezon='"+ model.Sezon + @"',@Kat='"+ model.Kat + @"',@Cephe='"+ model.Cephe + @"',
@Manzara='"+ model.Manzara+ @"',@Front_Adres='"+ model.Front_Adres+ @"',@OnburoYili='"+ model.OnburoYili + @"',
@Tesis='"+ model.Tesis + @"'";

            var data = getQueryToDataTable(query, c);
            string json = JsonConvert.SerializeObject(data);
            return Ok(json);
        }

        [HttpPost]//Hatalık Toplam Çağrı Sayısı
        [Route("tesboxtipinde")]
        public IActionResult GunlukKullaniciSkoru(string bas,string bit)
        {
            using var c = new Context();//

            string query = "exec Dev_DonemCizelgesiGrup @Baslangic='"+ bas + "',\r\n@Bitis='"+bit+"',@SadeceMusaitDonemler='True',@Donemler='14',\r\n@Oda_Tipi='101',@Sezon='A03',@Kat='100',@Cephe='001',\r\n@Manzara='10',@Front_Adres='ErzinFront',@OnburoYili='2016',\r\n@Tesis='100'";

            var data = getQueryToDataTable(query, c);
            string json = JsonConvert.SerializeObject(data);
            return Ok(json);
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public DataTable getQueryToDataTable(string query, DbContext context)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
    }
}
