using DesafioClimaTempo.Repository.Servicos.Implementacao;
using DesafioClimaTempo.Repository.Servicos.Interface;
using System.Threading.Tasks;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;

namespace DesafioClimaTempo.Web.Controllers
{
    public class PrevisaoClimaController : Controller
    {     
        private IPrevisaoClimaRepository _previsaoClimaRepository = null;

        public PrevisaoClimaController()
        {
            // Eu sei que o correto é por injeção de dependencia, venho trabalhando atualmente com projeto .net core usando injeção de depencia, fiz a implementação neste mas tive contratempo
            // e por esse motivo esta desta forma
            this._previsaoClimaRepository = new PrevisaoClimaRepository(new Domain.Context.EFContext());
        }

        [HttpGet]
        public async Task<string> BuscarClima(int id)
        {
            var result = await _previsaoClimaRepository.GetPrevisaoSeteDias(id);
            string html = "<table  align=\"center\" style=\"min-width: 100 %; \"> <tr>";
            if(result != null)
            {
                foreach(var item in result)
                {

                    string diaSemana = item.DataPrevisao.ToString("dddd");

                    html += "     <td style=\" margin-right: 10px;padding-right: 10px; \">";
                    html += "         <div style=\" min-width: 130px; border-style: groove;  \">";
                    html += "             <div class=\"card text-white\">";
                    html += "                 <div class=\"card-header bg-primary text-center\" style=\"padding-top: 5px; padding - bottom: 5px; \">" + diaSemana  + "</div>";
                    html += "                 <div class=\"card-body\">";
                    html += "                 <div >";
                    html += "                    <label style=\"padding-left: 10px;     font-size: 10px;\" >  " + item.Clima + " </label>";
                    html += "                 </div>";
                    html += "                 <div >";
                    html += "                    <label style=\"padding-left: 10px;     font-size: 10px;\" > Minima: " +   item.TemperaturaMinima + " ºC </label>";
                    html += "                 </div>";
                    html += "                 <div >";
                    html += "                    <label style=\"padding-left: 10px;     font-size: 10px;\" > Máxima: " + item.TemperaturaMaxima + " ºC </label>";
                    html += "                 </div>";
                    html += "                 </div>";
                    html += "             </div>";
                    html += "         </div>";
                    html += "     </td>";
                }
            }
            html += "     </tr>";
            html += "     </table>";

            return html; 
        }
    }
}