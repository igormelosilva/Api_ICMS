using Microsoft.AspNetCore.Mvc;
using Api_ICMS.Global;

namespace Api_ICMS.Controllers
{
    public class IcmsController : Controller
    {
        [HttpGet]
        [Route("CalculateICMS")]
        public JsonResult CalculateICMS(string cod, double valor)
        {
            try
            {
                if ("1234".Contains(cod)) 
                {
                    if (valor != 0)
                    {
                        List<Icms> listIcms = new List<Icms>();
                        Icms icms = new Icms();
                        icms.cod = "1";
                        icms.nome = "Acre";
                        icms.icms = 17;
                        listIcms.Add(icms);

                        icms = new Icms();
                        icms.cod = "2";
                        icms.nome = "Bahia";
                        icms.icms = 18;
                        listIcms.Add(icms);

                        icms = new Icms();
                        icms.cod = "3";
                        icms.nome = "Rondônia";
                        icms.icms = 17.5;
                        listIcms.Add(icms);

                        icms = new Icms();
                        icms.cod = "4";
                        icms.nome = "Sergipe";
                        icms.icms = 18;
                        listIcms.Add(icms);


                        double valorVenda = 0;

                        for (int i = 0; i < listIcms.Count; i++)
                        {
                            if (listIcms[i].cod == cod)
                            {
                                icms = new Icms();
                                icms.cod = listIcms[i].cod;
                                icms.nome = listIcms[i].nome;
                                icms.icms = listIcms[i].icms;
                                valorVenda = Calcular(listIcms[i].icms, valor);
                                icms.valorVenda = valorVenda;

                                Log.Save("Salvo com sucesso ");
                                return new JsonResult(icms);
                                

                            }
                        }
                    }
                    else
                    {
                        return new JsonResult("Valor invalido");
                    }
                    
                    return new JsonResult("Valor Não Encontrado");



                }
                else
                {
                    Log.Save("Cód invalido");
                    return new JsonResult("Cód invalido");

                }
            }
            catch (Exception ex)
            {

                return new JsonResult("Algum erro");
            }
            
        }
        private double Calcular(double icms, double valor)
        {
            return ((icms / 100) * valor) + valor;
        }
    }
}
